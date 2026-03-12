using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Organization.ResignType.Commands;
using ThePatho.Features.Organization.ResignType.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Organization.ResignType.Service
{
    public class ResignTypeService : IResignTypeService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;
        private readonly ICurrentUserService currentUserService;

        public ResignTypeService(DapperContext _dapperContext, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<ResignTypeItemDto>> GetResignType(GetResignTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.ResignType)
                        .Select("*")
                        .When(
                            !string.IsNullOrWhiteSpace(request.FilterResignType),
                            q => q.Where(w => w
                                .WhereContains("ResignTypeCode", request.FilterResignType)
                                .OrWhereContains("ResignTypeName", request.FilterResignType)
                            )
                        );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<ResignTypeDto>(query);

                var result = new ResignTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    ResignTypeList = data.ToList(),
                };
                return new ApiResponse<ResignTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ResignTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<ResignTypeItemDto>> GetResignTypeByCriteria(GetResignTypeByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.ResignType)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.ResignTypeCode),
                        q => q.WhereContains("ResignTypeCode", request.ResignTypeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.ResignTypeName),
                        q => q.WhereContains("ResignTypeName", request.ResignTypeName)
                    );

                var data = await db.GetAsync<ResignTypeDto>(query);

                var result = new ResignTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    ResignTypeList = data.ToList(),
                };
                return new ApiResponse<ResignTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ResignTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitResignType(SubmitResignTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var existsQuery = new Query(TableOrganization.ResignType)
                    .Where("ResignTypeCode", request.ResignTypeCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.ResignType).AsInsert(new
                    {
                        ResignTypeCode = request.ResignTypeCode,
                        ResignTypeName = request.ResignTypeName,
                        IsDeleted = false,
                        InsertedBy = currentUserService.GetUserName() ?? "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.ResignType)
                        .Where("ResignTypeCode", request.ResignTypeCode)
                        .AsUpdate(new
                        {
                            ResignTypeName = request.ResignTypeName,
                            IsDeleted = false,
                            ModifiedBy  = currentUserService.GetUserName() ?? "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.ResignTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.ResignTypeCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteResignType(DeleteResignTypeCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.ResignTypeCode))
                {
                    return new ApiResponse<ResignTypeDto>(
                         HttpStatusCode.BadRequest,
                         "ResignType is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.ResignType)
                                .Where("ResignTypeCode", request.ResignTypeCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.ResignTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.ResignTypeCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<ResignTypeDto>> GetSingleResignType(GetSingleResignTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.ResignType)
                    .Select("*")
                    .Where("ResignTypeCode", request.ResignTypeCode);

                var data = await db.FirstOrDefaultAsync<ResignTypeDto>(query);

                if (data == null)
                {
                    return new ApiResponse<ResignTypeDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<ResignTypeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ResignTypeDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion

        public async Task<ApiResponse<AttachmentFileDto>> ExportResignTypeAsync(string type)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var data = await db.Query(TableOrganization.ResignType)
                    .OrderBy("ResignTypeCode")
                    .GetAsync<ResignTypeDto>();

                var exportType = (type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(exportType)) exportType = "excel";

                byte[] fileBytes;
                string fileName;
                string contentType;

                if (exportType == "excel" || exportType == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("ResignType");

                    // ===== TITLE =====
                    ws.Cell("A1").Value = "Resign Type Master List";
                    ws.Range("A1:B1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // ===== HEADER =====
                    var headers = new[] { "Resign Type Code", "Resign Type Name" };
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
                        ws.Cell(row, 1).Value = item.ResignTypeCode;
                        ws.Cell(row, 2).Value = item.ResignTypeName;
                        row++;
                    }

                    // ===== BORDER =====
                    var lastRow = row - 1;
                    var range = ws.Range(3, 1, lastRow, headers.Length);
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    range.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // ===== AUTO FIT =====
                    ws.Columns(1, headers.Length).AdjustToContents();

                    // ===== EXPORT =====
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();

                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(fileBytes),
                        FileName = $"ResignType.xlsx",
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

                            // Title
                            page.Header()
                                .AlignCenter()
                                .Text("Resign Type")
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
                                    columns.RelativeColumn(1.2f); // ResignTypeCode
                                    columns.RelativeColumn(2.8f); // ResignTypeName
                                });

                                // Header
                                table.Header(header =>
                                {
                                    string[] headers = {
                                        "Resign Type Code", "Resign Type Name"
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
                                        .Text(item.ResignTypeCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.ResignTypeName ?? "-")
                                        .Style(normalTextStyle);
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();

                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(fileBytes),
                        FileName = "ResignType.pdf",
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
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "Gagal mengekspor Resign Type", ex.Message);
            }
        }
    }
}
