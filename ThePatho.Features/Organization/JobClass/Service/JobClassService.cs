using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.JobClass.Commands;
using ThePatho.Features.Organization.JobClass.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ClosedXML.Excel;
using System.IO;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.JobClass.Service
{
    public class JobClassService : IJobClassService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public JobClassService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<JobClassItemDto>> GetJobClass(GetJobClassCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.JobClass)
                        .Select("*")
                        .Where("IsDeleted", false)
                        .When(
                            !string.IsNullOrWhiteSpace(request.FilterJobClass),
                            q => q.Where(w => w
                                .WhereContains("JobClassCode", request.FilterJobClass)
                                .OrWhereContains("JobClassName", request.FilterJobClass)
                                .OrWhereContains("GradeCode", request.FilterJobClass)
                                .OrWhereContains("RankCode", request.FilterJobClass)
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

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<JobClassDto>(query);

                var result = new JobClassItemDto
                {
                    DataOfRecords = data.Count(),
                    JobClassList = data.ToList(),
                };
                return new ApiResponse<JobClassItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobClassItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<JobClassItemDto>> GetJobClassByCriteria(GetJobClassByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.JobClass)
                    .Select("*")
                    .Where("IsDeleted", false)
                    .When(
                         !string.IsNullOrWhiteSpace(request.JobClassCode),
                        q => q.WhereContains("JobClassCode", request.JobClassCode)
                    )
                    .When(
                       !string.IsNullOrWhiteSpace(request.JobClassName),
                        q => q.WhereContains("JobClassName", request.JobClassName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.GradeCode),
                        q => q.WhereContains("GradeCode", request.GradeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.RankCode),
                        q => q.WhereContains("RankCode", request.RankCode)
                    );

                var data = await db.GetAsync<JobClassDto>(query);

                var result = new JobClassItemDto
                {
                    DataOfRecords = data.Count(),
                    JobClassList = data.ToList(),
                };
                return new ApiResponse<JobClassItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobClassItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitJobClass(SubmitJobClassCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var existsQuery = new Query(TableOrganization.JobClass)
                    .Where("JobClassCode", request.JobClassCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.JobClass).AsInsert(new
                    {
                        JobClassCode = request.JobClassCode,
                        JobClassName = request.JobClassName,
                        GradeCode = request.GradeCode,
                        RankCode = request.RankCode,
                        Remarks = request.Remarks,
                        IsDeleted = false,
                        IsActive = request.IsActive,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.JobClass)
                        .Where("JobClassCode", request.JobClassCode)
                        .AsUpdate(new
                        {
                            JobClassName = request.JobClassName,
                            GradeCode = request.GradeCode,
                            RankCode = request.RankCode,
                            Remarks = request.Remarks,
                            IsDeleted = false,
                            IsActive = request.IsActive,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.JobClassCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.JobClassCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteJobClass(DeleteJobClassCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.JobClassCode))
                {
                    return new ApiResponse<JobClassDto>(
                        HttpStatusCode.BadRequest,
                        "JobClass is required"
                    );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                // Soft delete (UPDATE IsDeleted = true)
                var updateResult = await db
                    .Query(TableOrganization.JobClass)
                    .Where("JobClassCode", request.JobClassCode)
                    .UpdateAsync(new
                    {
                        IsDeleted = true,
                        ModifiedBy = "system",
                        ModifiedDate = DateTime.UtcNow
                    });

                if (updateResult == 0)
                {
                    return new ApiResponse(
                        HttpStatusCode.NotFound,
                        $"JobClass {request.JobClassCode} not found"
                    );
                }

                return new ApiResponse(
                    HttpStatusCode.OK,
                    $"Delete {request.JobClassCode} successfully"
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.JobClassCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<JobClassDto>> GetSingleJobClass(GetSingleJobClassCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.JobClass)
                    .Select("*")
                    .Where("JobClassCode", request.JobClassCode);

                var data = await db.FirstOrDefaultAsync<JobClassDto>(query);

                if (data == null)
                {
                    return new ApiResponse<JobClassDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<JobClassDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobClassDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        
        public async Task<ApiResponse<AttachmentFileDto>> ExportJobClassAsync(string type)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var data = await db.Query(TableOrganization.JobClass)
                    .Where("IsDeleted", false)
                    .OrderBy("JobClassCode")
                    .GetAsync<JobClassDto>();

                var fileName = $"job-class_{DateTime.Now:yyyyMMddHHmmss}";
                byte[] fileBytes;
                string contentType;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("JobClass");

                    // ===== TITLE =====
                    worksheet.Cell("A1").Value = "Job Class List";
                    worksheet.Range("A1:F1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // ===== HEADER =====
                    worksheet.Cell(3, 1).Value = "Job Class Code";
                    worksheet.Cell(3, 2).Value = "Job Class Name";
                    worksheet.Cell(3, 3).Value = "Grade Code";
                    worksheet.Cell(3, 4).Value = "Rank Code";
                    worksheet.Cell(3, 5).Value = "Remarks";
                    worksheet.Cell(3, 6).Value = "Is Active";

                    worksheet.Range(3, 1, 3, 6).Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));

                    // ===== DATA =====
                    var row = 4;
                    foreach (var item in data)
                    {
                        worksheet.Cell(row, 1).Value = item.JobClassCode;
                        worksheet.Cell(row, 2).Value = item.JobClassName;
                        worksheet.Cell(row, 3).Value = item.GradeCode;
                        worksheet.Cell(row, 4).Value = item.RankCode;
                        worksheet.Cell(row, 5).Value = item.Remarks;
                        worksheet.Cell(row, 6).Value = item.IsActive.HasValue && item.IsActive.Value ? "Active" : "Inactive";
                        row++;
                    }

                    // ===== AUTO FIT =====
                    worksheet.Columns(1, 6).AdjustToContents();

                    // ===== BORDER =====
                    var lastDataRow = row - 1;
                    var tableRange = worksheet.Range(3, 1, lastDataRow, 6);
                    tableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    tableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // ===== EXPORT FILE =====
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();

                    fileName = $"JobClass.xlsx";
                    var dto = new AttachmentFileDto
                    {
                        FileBytes = fileBytes,
                        FileName = fileName,
                        ContentType = MimeTypesConstants.VND_OPENXML_EXCEL
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);

                }
                else if (string.Equals(type, "pdf", StringComparison.OrdinalIgnoreCase))
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
                                    string[] headers = { "Job Class Code", "Job Class Name", "Grade", "Rank", "Remarks", "Active" };

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
                                        .Text(item.JobClassCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.JobClassName ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.GradeCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.RankCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.Remarks ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.IsActive == true ? "Active" : "Inactive")
                                        .Style(normalTextStyle);
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    var bytes = ms.ToArray();

                    var dto = new AttachmentFileDto
                    {
                        FileBytes = bytes,
                        FileName = "JobClassList.pdf",
                        ContentType = MimeTypesConstants.PDF
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);

                }
                else
                {
                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "Tipe file tidak dikenali. Gunakan 'excel' atau 'pdf'.");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "Gagal mengekspor Job Class", ex.Message);
            }
        }
        #endregion
    }
}
