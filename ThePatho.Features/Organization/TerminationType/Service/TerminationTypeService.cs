using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Organization.TerminationType.Commands;
using ThePatho.Features.Organization.TerminationType.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Organization.TerminationType.Service
{
    public class TerminationTypeService : ITerminationTypeService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;
        private readonly ICurrentUserService currentUserService;

        public TerminationTypeService(DapperContext _dapperContext, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<TerminationTypeItemDto>> GetTerminationType(GetTerminationTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.TerminationType)
                        .Select("*")
                        .When(
                            !string.IsNullOrWhiteSpace(request.FilterTerminationType),
                            q => q.Where(w => w
                                .WhereContains("TerminationTypeCode", request.FilterTerminationType)
                                .OrWhereContains("TerminationTypeName", request.FilterTerminationType)
                            )
                        );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<TerminationTypeDto>(query);

                var result = new TerminationTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    TerminationTypeList = data.ToList(),
                };
                return new ApiResponse<TerminationTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TerminationTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<TerminationTypeItemDto>> GetTerminationTypeByCriteria(GetTerminationTypeByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.TerminationType)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.TerminationTypeCode),
                        q => q.WhereContains("TerminationTypeCode", request.TerminationTypeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.TerminationTypeName),
                        q => q.WhereContains("TerminationTypeName", request.TerminationTypeName)
                    );

                var data = await db.GetAsync<TerminationTypeDto>(query);

                var result = new TerminationTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    TerminationTypeList = data.ToList(),
                };
                return new ApiResponse<TerminationTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TerminationTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitTerminationType(SubmitTerminationTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var existsQuery = new Query(TableOrganization.TerminationType)
                    .Where("TerminationTypeCode", request.TerminationTypeCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.TerminationType).AsInsert(new
                    {
                        TerminationTypeCode = request.TerminationTypeCode,
                        TerminationTypeName = request.TerminationTypeName,
                        IsDeleted = false,
                        InsertedBy = currentUserService.GetUserName() ?? "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.TerminationType)
                        .Where("TerminationTypeCode", request.TerminationTypeCode)
                        .AsUpdate(new
                        {
                            TerminationTypeName = request.TerminationTypeName,
                            IsDeleted = false,
                            ModifiedBy  = currentUserService.GetUserName() ?? "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.TerminationTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.TerminationTypeCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteTerminationType(DeleteTerminationTypeCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.TerminationTypeCode))
                {
                    return new ApiResponse<TerminationTypeDto>(
                         HttpStatusCode.BadRequest,
                         "TerminationType is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.TerminationType)
                                .Where("TerminationTypeCode", request.TerminationTypeCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.TerminationTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.TerminationTypeCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<TerminationTypeDto>> GetSingleTerminationType(GetSingleTerminationTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.TerminationType)
                    .Select("*")
                    .Where("TerminationTypeCode", request.TerminationTypeCode);

                var data = await db.FirstOrDefaultAsync<TerminationTypeDto>(query);

                if (data == null)
                {
                    return new ApiResponse<TerminationTypeDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<TerminationTypeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TerminationTypeDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportTerminationTypeAsync(string type)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.TerminationType)
                    .Select("TerminationTypeCode", "TerminationTypeName")
                    .OrderBy("TerminationTypeCode");

                var data = await db.GetAsync<TerminationTypeDto>(query);

                var exportType = (type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(exportType)) exportType = "excel";

                // ===== Excel Export =====
                if (exportType == "excel" || exportType == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("TerminationType");

                    // ===== TITLE =====
                    ws.Cell("A1").Value = "Termination Type Master List";
                    ws.Range("A1:B1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                    ws.Row(1).Height = 24;

                    // ===== HEADER =====
                    var headers = new[] { "Termination Type Code", "Termination Type Name" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        ws.Cell(3, i + 1).Value = headers[i];
                    }
                    ws.Range(3, 1, 3, headers.Length).Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));

                    // ===== DATA =====
                    int row = 4;
                    foreach (var item in data)
                    {
                        ws.Cell(row, 1).Value = item.TerminationTypeCode;
                        ws.Cell(row, 2).Value = item.TerminationTypeName;
                        row++;
                    }

                    // ===== BORDER & ALIGNMENT =====
                    var lastRow = row - 1;
                    var tableRange = ws.Range(3, 1, lastRow, headers.Length);
                    tableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    tableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    tableRange.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // ===== AUTO FIT =====
                    ws.Columns(1, headers.Length).AdjustToContents();

                    // ===== EXPORT =====
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    var fileBytes = ms.ToArray();

                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(fileBytes),
                        FileName = $"TerminationType.xlsx",
                        ContentType = MimeTypesConstants.VND_OPENXML_EXCEL
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);

                }
                // ===== PDF Export =====
                else if (exportType == "pdf")
                {
                    var document = Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Margin(30);
                            page.Size(PageSizes.A4.Landscape());

                            // Title
                            page.Header()
                                .AlignCenter()
                                .Text("Termination Type")
                                .SemiBold()
                                .FontSize(16)
                                .FontColor(Colors.Black);

                            // Define text styles
                            var headerStyle = TextStyle.Default.FontSize(12).Bold();
                            var normalTextStyle = TextStyle.Default.FontSize(8);

                            // Table
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                // Column definitions
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1.2f); // TerminationTypeCode
                                    columns.RelativeColumn(2.8f); // TerminationTypeName
                                });

                                // Header
                                table.Header(header =>
                                {
                                    string[] headers = {
                                        "Termination Type Code", "Termination Type Name"
                                    };

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
                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.TerminationTypeCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.TerminationTypeName ?? "-")
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
                        Base64Data = Convert.ToBase64String(bytes),
                        FileName = "TerminationType.pdf",
                        ContentType = MimeTypesConstants.PDF
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);
                }
                else
                {
                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "Type harus 'excel' atau 'pdf'");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "Gagal export termination type", ex.Message);
            }
        }
        #endregion
    }
}
