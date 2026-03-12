using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SqlKata;
using SqlKata.Execution;
using System.IO;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Organization.JobLevelJobClass.Commands;
using ThePatho.Features.Organization.JobLevelJobClass.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Organization.JobLevelJobClass.Service
{
    public class JobLevelJobClassService : IJobLevelJobClassService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;
        private readonly ICurrentUserService currentUserService;

        public JobLevelJobClassService(DapperContext _dapperContext, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<JobLevelJobClassItemDto>> GetJobLevelJobClass(GetJobLevelJobClassCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.JobLevelJobClass)
                        .Select("*")
                        .When(
                            !string.IsNullOrWhiteSpace(request.FilterJobLevelJobClass),
                            q => q.Where(w => w
                                .WhereContains("JobLevelCode", request.FilterJobLevelJobClass)
                                .OrWhereContains("JobClassCode", request.FilterJobLevelJobClass)
                            )
                        );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<JobLevelJobClassDto>(query);

                var result = new JobLevelJobClassItemDto
                {
                    DataOfRecords = data.Count(),
                    JobLevelJobClassList = data.ToList(),
                };
                return new ApiResponse<JobLevelJobClassItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobLevelJobClassItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<JobLevelJobClassItemDto>> GetJobLevelJobClassByCriteria(GetJobLevelJobClassByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.JobLevelJobClass)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.JobLevelCode),
                        q => q.WhereContains("JobLevelCode", request.JobLevelCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.JobClassCode),
                        q => q.WhereContains("JobClassCode", request.JobClassCode)
                    );

                var data = await db.GetAsync<JobLevelJobClassDto>(query);

                var result = new JobLevelJobClassItemDto
                {
                    DataOfRecords = data.Count(),
                    JobLevelJobClassList = data.ToList(),
                };
                return new ApiResponse<JobLevelJobClassItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobLevelJobClassItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitJobLevelJobClass(SubmitJobLevelJobClassCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var existsQuery = new Query(TableOrganization.JobLevelJobClass)
                    .Where("JobLevelCode", request.JobLevelCode)
                    .Where("JobClassCode", request.JobClassCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert relasi baru
                    var insertQuery = new Query(TableOrganization.JobLevelJobClass).AsInsert(new
                    {
                        JobLevelCode = request.JobLevelCode,
                        JobClassCode = request.JobClassCode,
                        IsDeleted = request.IsDeleted,
                        InsertedBy = currentUserService.GetUserName() ?? "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update relasi yang sudah ada
                    var updateQuery = new Query(TableOrganization.JobLevelJobClass)
                        .Where("JobLevelCode", request.JobLevelCode)
                        .Where("JobClassCode", request.JobClassCode)
                        .AsUpdate(new
                        {
                            IsDeleted = request.IsDeleted,
                            ModifiedBy  = currentUserService.GetUserName() ?? "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} JobLevel-JobClass relation successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} JobLevel-JobClass relation", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteJobLevelJobClass(DeleteJobLevelJobClassCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.JobClassCode))
                {
                    return new ApiResponse<JobLevelJobClassDto>(
                         HttpStatusCode.BadRequest,
                         "JobLevelJobClass is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.JobLevelJobClass)
                                .Where("JobLevelCode", request.JobLevelCode)
                                .Where("JobClassCode", request.JobClassCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete  successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete ", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<JobLevelJobClassDto>> GetSingleJobLevelJobClass(GetSingleJobLevelJobClassCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.JobLevelJobClass)
                    .Select("*")
                    .Where("JobLevelCode", request.JobLevelCode)
                    .Where("JobClassCode", request.JobClassCode);

                var data = await db.FirstOrDefaultAsync<JobLevelJobClassDto>(query);

                if (data == null)
                {
                    return new ApiResponse<JobLevelJobClassDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<JobLevelJobClassDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobLevelJobClassDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion

        public async Task<ApiResponse<AttachmentFileDto>> ExportJobLevelJobClassAsync(string type)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var data = await db.Query(TableOrganization.JobLevelJobClass)
                    .Where("IsDeleted", false)
                    .OrderBy("JobLevelCode")
                    .GetAsync<JobLevelJobClassDto>();

                var exportType = (type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(exportType)) exportType = "excel";

                if (exportType == "excel" || exportType == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("JobLevelJobClass");

                    // ===== TITLE =====
                    worksheet.Cell("A1").Value = "Job Level Job Class List";
                    worksheet.Range("A1:F1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // ===== HEADER =====
                    worksheet.Cell(3, 1).Value = "Job Level Code";
                    worksheet.Cell(3, 2).Value = "Job Class Code";

                    worksheet.Range(3, 1, 3, 2).Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));

                    // ===== DATA =====
                    var row = 4;
                    foreach (var item in data)
                    {
                        worksheet.Cell(row, 1).Value = item.JobLevelCode;
                        worksheet.Cell(row, 2).Value = item.JobClassCode;
                        row++;
                    }

                    // ===== BORDER =====
                    var lastDataRow = row - 1;
                    var range = worksheet.Range(3, 1, lastDataRow, 2);
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // ===== AUTO FIT =====
                    worksheet.Columns(1, 6).AdjustToContents();

                    // ===== EXPORT =====
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    var bytes = ms.ToArray();

                    var fileName = $"JobLevel-JobClass.xlsx";

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(bytes),
                        FileName = fileName,
                        ContentType = MimeTypesConstants.VND_OPENXML_EXCEL
                    });

                }
                else if (exportType == "pdf")
                {
                    var document = Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Margin(20);
                            page.Size(PageSizes.A4);
                            page.DefaultTextStyle(x => x.FontSize(10));

                            // Header Title
                            page.Header()
                                .Text("JobLevel - JobClass Relation")
                                .SemiBold()
                                .FontSize(14)
                                .AlignCenter();

                            // Table Content
                            page.Content().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(100); // JobLevelCode
                                    columns.ConstantColumn(100); // JobClassCode
                                });

                                var headerStyle = TextStyle.Default.FontSize(12).Bold();
                                var normalTextStyle = TextStyle.Default.FontSize(8); 
                                // Header row
                                table.Header(header =>
                                {

                                    string[] headers = { "Job Level Code", "Job Class Name"};

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

                                // Data rows
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).AlignMiddle().Text(item.JobLevelCode ?? "").Style(normalTextStyle);
                                    table.Cell().Border(1).Padding(5).AlignMiddle().Text(item.JobClassCode ?? "").Style(normalTextStyle);
                                }
                            });
                        });
                    });

                    // === Generate PDF ===
                    var bytes = document.GeneratePdf();

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(bytes),
                        FileName = $"JobLevel-JobClass.pdf",
                        ContentType = MimeTypesConstants.PDF
                    });

                }

                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, "Unsupported export type");
            }
            catch (Exception ex)
            {
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, "Failed to export JobLevel-JobClass", ex.Message);
            }
        }
    }
}
