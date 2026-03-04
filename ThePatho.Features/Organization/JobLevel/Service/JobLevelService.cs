using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SqlKata;
using SqlKata.Execution;
using System.IO;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Organization.Grade.DTO;
using ThePatho.Features.Organization.JobClass.DTO;
using ThePatho.Features.Organization.JobLevel.Commands;
using ThePatho.Features.Organization.JobLevel.DTO;
using ThePatho.Features.Organization.JobLevelJobClass.DTO;
using ThePatho.Features.Organization.OrgLevel.DTO;
using ThePatho.Features.Organization.OrgStructure.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThePatho.Features.Organization.JobLevel.Service
{
    public class JobLevelService : IJobLevelService
    {
        private readonly DapperContext dapperContext; 
        private readonly ICurrentUserService currentUserService;

        public JobLevelService(DapperContext _dapperContext, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<JobLevelItemDto>> GetJobLevel(GetJobLevelCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                // 1. Ambil data JobLevel dengan filter dan pagination
                var query = new Query(TableOrganization.JobLevel)
                    .Select("*")
                    .Where("IsDeleted", false)
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterJobLevel),
                        q => q.Where(w => w
                            .WhereContains("JobLevelCode", request.FilterJobLevel)
                            .OrWhereContains("JobLevelName", request.FilterJobLevel)
                        )
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterStatus)
                        && request.FilterStatus.ToLower() != "all",
                        q =>
                        {
                            bool isActive = request.FilterStatus == "1";
                            return q.Where("IsActive", isActive);
                        }
                    );

                // Sorting
                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                // Pagination
                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                // Eksekusi query JobLevel
                var jobLevels = await db.GetAsync<JobLevelDto>(query);

                // 2. Ambil JobClass untuk semua JobLevel sekaligus
                var jobLevelCodes = jobLevels.Select(j => j.JobLevelCode).ToList();

                var jobClassQuery = new Query(TableOrganization.JobLevelJobClass)
                    .Select("JobLevelCode", "JobClassCode")
                    .WhereIn("JobLevelCode", jobLevelCodes)
                    .Where("IsDeleted", false);

                var jobClassMappings = await db.GetAsync<JobLevelJobClassDto>(jobClassQuery);

                // 3. Gabungkan hasilnya
                var jobLevelList = jobLevels.Select(jobLevel => {
                    var jobClasses = jobClassMappings
                        .Where(jc => jc.JobLevelCode == jobLevel.JobLevelCode)
                        .Select(jc => jc.JobClassCode)
                        .ToList();

                    return new JobLevelDto
                    {
                        JobLevelCode = jobLevel.JobLevelCode,
                        JobLevelName = jobLevel.JobLevelName,
                        Remarks = jobLevel.Remarks,
                        SortOrder = jobLevel.SortOrder,
                        IsActive = jobLevel.IsActive,
                        JobClassCodes = jobClasses,
                        JobClass = string.Join(", ", jobClasses)
                    };
                }).ToList();

                var result = new JobLevelItemDto
                {
                    DataOfRecords = jobLevelList.Count(),
                    JobLevelList = jobLevelList
                };

                return new ApiResponse<JobLevelItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobLevelItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }

        }

        public async Task<ApiResponse<JobLevelDto>> GetSingleJobLevel(GetSingleJobLevelCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.JobLevel)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.JobLevelCode),
                        q => q.WhereIn("JobLevelCode", request.JobLevelCode)
                    );

                var data = await db.FirstOrDefaultAsync<JobLevelDto>(query);
                if (data == null)
                {
                    return new ApiResponse<JobLevelDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                // 2. Ambil JobClass untuk JobLevel tersebut
                var jobClassQuery = new Query(TableOrganization.JobLevelJobClass)
                    .Select("JobClassCode")
                    .Where("JobLevelCode", data.JobLevelCode)
                    .Where("IsDeleted", false);

                var jobClasses = await db.GetAsync<JobLevelJobClassDto>(jobClassQuery);

                // 3. Map ke DTO dengan informasi JobClass
                var result = new JobLevelDto
                {
                    JobLevelCode = data.JobLevelCode,
                    JobLevelName = data.JobLevelName,
                    Remarks = data.Remarks,
                    SortOrder = data.SortOrder,
                    IsActive = data.IsActive,
                    JobClassCodes = jobClasses.Select(jc => jc.JobClassCode).ToList(),
                    JobClass = string.Join(", ", jobClasses.Select(jc => jc.JobClassCode))
                };
                return new ApiResponse<JobLevelDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobLevelDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }

        }
        public async Task<ApiResponse> SubmitJobLevel(SubmitJobLevelCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
               
                var existsQuery = new Query(TableOrganization.JobLevel)
                    .Where("JobLevelCode", request.JobLevelCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.JobLevel).AsInsert(new
                    {
                        JobLevelCode = request.JobLevelCode,
                        JobLevelName = request.JobLevelName,
                        SortOrder = request.SortOrder,
                        Remarks = request.Remarks,
                        IsDeleted = false,
                        InsertedBy = currentUserService.GetUserName() ?? "system",
                        InsertedDate = DateTime.UtcNow,
                        IsActive = request.IsActive
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);

                    // INSERT JobLevelJobClass (relasi)
                    if (request.JobClassCodes != null && request.JobClassCodes.Any())
                    {
                        foreach (var jobClassCode in request.JobClassCodes)
                        {
                            var insertJobClassQuery = new Query(TableOrganization.JobLevelJobClass).AsInsert(new
                            {
                                JobLevelCode = request.JobLevelCode,
                                JobClassCode = jobClassCode,
                                IsDeleted = false,
                                InsertedBy = currentUserService.GetUserName() ?? "system",
                                InsertedDate = DateTime.UtcNow
                            });

                            await db.ExecuteAsync(insertJobClassQuery);
                        }
                    }
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.JobLevel)
                        .Where("JobLevelCode", request.JobLevelCode)
                        .AsUpdate(new
                        {
                            JobLevelName = request.JobLevelName,
                            SortOrder = request.SortOrder,
                            Remarks = request.Remarks,
                            ModifiedBy  = currentUserService.GetUserName() ?? "system",
                            ModifiedDate = DateTime.UtcNow,
                            IsActive = request.IsActive
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);

                    // UPDATE JobLevelJobClass (relasi)
                    // Hapus semua relasi lama
                    var deleteQuery = new Query(TableOrganization.JobLevelJobClass)
                        .Where("JobLevelCode", request.JobLevelCode)
                        .AsDelete();

                    await db.ExecuteAsync(deleteQuery);

                    // Insert relasi baru
                    if (request.JobClassCodes != null && request.JobClassCodes.Any())
                    {
                        foreach (var jobClassCode in request.JobClassCodes)
                        {
                            var insertJobClassQuery = new Query(TableOrganization.JobLevelJobClass).AsInsert(new
                            {
                                JobLevelCode = request.JobLevelCode,
                                JobClassCode = jobClassCode,
                                IsDeleted = false,
                                InsertedBy = currentUserService.GetUserName() ?? "system",
                                InsertedDate = DateTime.UtcNow
                            });

                            await db.ExecuteAsync(insertJobClassQuery);
                        }
                    }
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.JobLevelCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.JobLevelCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteJobLevel(DeleteJobLevelCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.JobLevelCode))
                {
                    return new ApiResponse<GradeDto>(
                        HttpStatusCode.BadRequest,
                        "Job level is required"
                    );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                // Soft delete: UPDATE IsDeleted = true
                var updateResult = await db
                    .Query(TableOrganization.JobLevel)
                    .Where("JobLevelCode", request.JobLevelCode)
                    .UpdateAsync(new
                    {
                        IsDeleted = true,
                        ModifiedBy  = currentUserService.GetUserName() ?? "system",
                        ModifiedDate = DateTime.UtcNow,
                    });
                await db
                    .Query(TableOrganization.JobLevelJobClass)
                    .Where("JobLevelCode", request.JobLevelCode)
                    .UpdateAsync(new
                    {
                        IsDeleted = true,
                        ModifiedBy  = currentUserService.GetUserName() ?? "system",
                        ModifiedDate = DateTime.UtcNow,
                    });

                if (updateResult == 0)
                {
                    return new ApiResponse(
                        HttpStatusCode.NotFound,
                        $"Job level {request.JobLevelCode} not found"
                    );
                }

                return new ApiResponse(
                    HttpStatusCode.OK,
                    $"Delete {request.JobLevelCode} successfully"
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.JobLevelCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<JobLevelItemDto>> GetJobLevelByCriteria(GetJobLevelByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.JobLevel)
                    .Select("*")
                    .Where("IsDeleted", false)
                    .Where("IsActive", true)
                    .When(
                        !string.IsNullOrWhiteSpace(request.JobLevelCode),
                        q => q.WhereIn("JobLevelCode", request.JobLevelCode)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.JobLevelName),
                            q => q.WhereContains("JobLevelName", request.JobLevelName)
                    );

                // Eksekusi query JobLevel
                var jobLevels = await db.GetAsync<JobLevelDto>(query);

                // 2. Ambil JobClass untuk semua JobLevel sekaligus
                var jobLevelCodes = jobLevels.Select(j => j.JobLevelCode).ToList();

                var jobClassQuery = new Query(TableOrganization.JobLevelJobClass)
                    .Select("JobLevelCode", "JobClassCode")
                    .WhereIn("JobLevelCode", jobLevelCodes)
                    .Where("IsDeleted", false);

                var jobClassMappings = await db.GetAsync<JobLevelJobClassDto>(jobClassQuery);

                // 3. Gabungkan hasilnya
                var jobLevelList = jobLevels.Select(jobLevel => {
                    var jobClasses = jobClassMappings
                        .Where(jc => jc.JobLevelCode == jobLevel.JobLevelCode)
                        .Select(jc => jc.JobClassCode)
                        .ToList();

                    return new JobLevelDto
                    {
                        JobLevelCode = jobLevel.JobLevelCode,
                        JobLevelName = jobLevel.JobLevelName,
                        Remarks = jobLevel.Remarks,
                        SortOrder = jobLevel.SortOrder,
                        IsActive = jobLevel.IsActive,
                        JobClassCodes = jobClasses,
                        JobClass = string.Join(", ", jobClasses)
                    };
                }).ToList();

                var result = new JobLevelItemDto
                {
                    DataOfRecords = jobLevelList.Count(),
                    JobLevelList = jobLevelList
                };
                return new ApiResponse<JobLevelItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobLevelItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportJobLevelAsync(string type)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var data = await db.Query(TableOrganization.JobLevel)
                    .Where("IsDeleted", false)
                    .OrderBy("SortOrder")
                    .GetAsync<JobLevelDto>();

                var exportType = (type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(exportType)) exportType = "excel";

                if (exportType == "excel" || exportType == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("JobLevel");

                    // ===== TITLE =====
                    worksheet.Cell("A1").Value = "Job Level List";
                    worksheet.Range("A1:E1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // ===== HEADER =====
                    worksheet.Cell(3, 1).Value = "Job Level Code";
                    worksheet.Cell(3, 2).Value = "Job Level Name";
                    worksheet.Cell(3, 3).Value = "SortOrder";
                    worksheet.Cell(3, 4).Value = "Remarks";
                    worksheet.Cell(3, 5).Value = "Is Active";

                    worksheet.Range(3, 1, 3, 5).Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));

                    // ===== DATA =====
                    var row = 4;
                    foreach (var item in data)
                    {
                        worksheet.Cell(row, 1).Value = item.JobLevelCode;
                        worksheet.Cell(row, 2).Value = item.JobLevelName;
                        worksheet.Cell(row, 3).Value = item.SortOrder;
                        worksheet.Cell(row, 4).Value = item.Remarks;
                        worksheet.Cell(row, 5).Value = item.IsActive.HasValue && item.IsActive.Value ? "Active" : "Inactive";
                        row++;
                    }

                    // ===== AUTO FIT =====
                    worksheet.Columns(1, 5).AdjustToContents();

                    // ===== BORDER =====
                    var lastDataRow = row - 1;
                    var tableRange = worksheet.Range(3, 1, lastDataRow, 5);
                    tableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    tableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // ===== EXPORT FILE =====
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    var fileBytes = ms.ToArray();

                    var fileName = $"JobLevel.xlsx";

                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(fileBytes),
                        FileName = fileName,
                        ContentType = MimeTypesConstants.VND_OPENXML_EXCEL
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);

                }
                else if (exportType == "pdf")
                {
                    var document = Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Margin(30);
                            page.Size(PageSizes.A4.Landscape());

                            // ===== TITLE =====
                            page.Header().Element(header =>
                            {
                                header.AlignCenter()
                                    .PaddingBottom(10)
                                    .Text("Job Class List")
                                    .SemiBold()
                                    .FontSize(18);
                                    //.FontColor("#007BFF"); // Warna biru profesional
                            });

                            // ===== CONTENT =====
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                // ===== COLUMN DEFINITIONS =====
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(100);  // Code
                                    columns.ConstantColumn(200);  // Name
                                    columns.ConstantColumn(100);  // Grade
                                    columns.ConstantColumn(100);  // Rank
                                    columns.RelativeColumn(2f);   // Remarks
                                    columns.ConstantColumn(80);   // Active
                                });

                                var headerStyle = TextStyle.Default.FontSize(12).Bold();
                                var normalTextStyle = TextStyle.Default.FontSize(8);

                                // ===== TABLE HEADER =====
                                table.Header(header =>
                                {
                                    string[] headers = { "Job Level Code", "Job Level Name", "SortOrder", "Remarks",  "Active" };

                                    foreach (var title in headers)
                                    {
                                        header.Cell()
                                            .Border(1)
                                            .PaddingVertical(4)
                                            .PaddingHorizontal(6)
                                            .Background(Colors.BlueGrey.Lighten2)
                                            .AlignCenter()
                                            .AlignMiddle()
                                            .Text(title)
                                            .Style(headerStyle);
                                    }
                                });

                                // ===== TABLE DATA ROWS =====
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.JobLevelCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.JobLevelName ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.SortOrder.ToString())
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.Remarks ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.IsActive.Value ? "True" : "False")
                                        .Style(normalTextStyle);
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    var fileBytes = ms.ToArray();

                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(fileBytes),
                        FileName = "JobLevel.pdf",
                        ContentType = MimeTypesConstants.PDF
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);
                }

                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, "Unsupported export type");
            }
            catch (Exception ex)
            {
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, "Failed to export Job Level", ex.Message);
            }
        }
    }
}
