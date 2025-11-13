using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using System.IO;
using ThePatho.Domain.Constants;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevel.Commands;
using ThePatho.Features.Organization.JobLevel.DTO;
using ThePatho.Features.Organization.OrgLevel.DTO;
using ThePatho.Features.Organization.OrgStructure.DTO;
using ThePatho.Infrastructure.Persistance;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ThePatho.Features.Organization.Grade.DTO;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.JobLevel.Service
{
    public class JobLevelService : IJobLevelService
    {
        private readonly DapperContext dapperContext; 

        public JobLevelService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<ApiResponse<JobLevelItemDto>> GetJobLevel(GetJobLevelCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.JobLevel)
                    .Select("*"
                        )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterJobLevelCode),
                        q => q.WhereIn("JobLevelCode", request.FilterJobLevelCode)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterJobLevelName),
                            q => q.WhereContains("FilterJobLevelName", request.FilterJobLevelName)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<JobLevelDto>(query);
                var result = new JobLevelItemDto
                {
                    DataOfRecords = data.Count(),
                    JobLevelList = data.ToList(),
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
                    .Select("*"
                        )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterJobLevelCode),
                        q => q.WhereIn("JobLevelCode", request.FilterJobLevelCode)
                    );

                var data = await db.FirstOrDefaultAsync<JobLevelDto>(query);
                if (data == null)
                {
                    return new ApiResponse<JobLevelDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<JobLevelDto>(HttpStatusCode.OK, data);
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
                        Sort = request.Sort,
                        Remarks = request.Remarks,
                        IsDeleted = false,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow,
                        IsActive = request.IsActive
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.JobLevel)
                        .Where("JobLevelCode", request.JobLevelCode)
                        .AsUpdate(new
                        {
                            JobLevelName = request.JobLevelName,
                            Sort = request.Sort,
                            Remarks = request.Remarks,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow,
                            IsActive = request.IsActive
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
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

                var deleteQuery = new Query(TableOrganization.JobLevel)
                    .Where("job_level_code", request.JobLevelCode)
                    .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.JobLevelCode} successfully");
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
                    .Select("*"
                        )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterJobLevelCode),
                        q => q.WhereIn("JobLevelCode", request.FilterJobLevelCode)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterJobLevelName),
                            q => q.WhereContains("JobLevelName", request.FilterJobLevelName)
                    );

                var data = await db.GetAsync<JobLevelDto>(query);
                var result = new JobLevelItemDto
                {
                    DataOfRecords = data.Count(),
                    JobLevelList = data.ToList(),
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
                    .OrderBy("Sort")
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
                    worksheet.Cell(3, 3).Value = "Sort";
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
                        worksheet.Cell(row, 3).Value = item.Sort;
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
                        FileBytes = fileBytes,
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
                                    string[] headers = { "Job Level Code", "Job Level Name", "Sort", "Remarks",  "Active" };

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
                                        .Text(item.Sort.ToString())
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
                        FileBytes = fileBytes,
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
