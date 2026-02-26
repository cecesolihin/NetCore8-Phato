using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.Rank.Commands;
using ThePatho.Features.Organization.Rank.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.Rank.Service
{
    public class RankService : IRankService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public RankService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<RankItemDto>> GetRank(GetRankCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Rank)
                        .Select("*")
                        .Where("IsDeleted", false)
                        .When(
                            !string.IsNullOrWhiteSpace(request.FilterRank),
                            q => q.Where(w => w
                                .WhereContains("RankCode", request.FilterRank)
                                .OrWhereContains("RankName", request.FilterRank)
                            )
                        );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<RankDto>(query);

                var result = new RankItemDto
                {
                    DataOfRecords = data.Count(),
                    RankList = data.ToList(),
                };
                return new ApiResponse<RankItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<RankItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<RankItemDto>> GetRankByCriteria(GetRankByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Rank)
                    .Select("*")
                    .Where("IsDeleted", false)
                    .When(
                        !string.IsNullOrWhiteSpace(request.RankCode),
                        q => q.WhereContains("RankCode", request.RankCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.RankName),
                        q => q.WhereContains("RankName", request.RankName)
                    );

                var data = await db.GetAsync<RankDto>(query);

                var result = new RankItemDto
                {
                    DataOfRecords = data.Count(),
                    RankList = data.ToList(),
                };
                return new ApiResponse<RankItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<RankItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitRank(SubmitRankCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var existsQuery = new Query(TableOrganization.Rank)
                    .Where("RankCode", request.RankCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.Rank).AsInsert(new
                    {
                        RankCode = request.RankCode,
                        RankName = request.RankName,
                        SortOrder = request.SortOrder,
                        Remarks = request.Remarks,
                        IsDeleted = false,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.Rank)
                        .Where("RankCode", request.RankCode)
                        .AsUpdate(new
                        {
                            RankName = request.RankName,
                            SortOrder = request.SortOrder,
                            Remarks = request.Remarks,
                            IsDeleted = false,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.RankCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.RankCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteRank(DeleteRankCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.RankCode))
                {
                    return new ApiResponse<RankDto>(
                         HttpStatusCode.BadRequest,
                         "Rank is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var updateResult = await db
                                 .Query(TableOrganization.Rank)
                                 .Where("RankCode", request.RankCode)
                                 .UpdateAsync(new
                                 {
                                     IsDeleted = true,
                                     ModifiedBy = "system",
                                     ModifiedDate = DateTime.UtcNow           // optional
                                 });

                if (updateResult == 0)
                {
                    return new ApiResponse(
                        HttpStatusCode.NotFound,
                        $"Rank {request.RankCode} not found"
                    );
                }

                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.RankCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.RankCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<RankDto>> GetSingleRank(GetSingleRankCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Rank)
                    .Select("*")
                    .Where("RankCode", request.RankCode);

                var data = await db.FirstOrDefaultAsync<RankDto>(query);

                if (data == null)
                {
                    return new ApiResponse<RankDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<RankDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<RankDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion

        public async Task<ApiResponse<AttachmentFileDto>> ExportRankAsync(string type)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var data = await db.Query(TableOrganization.Rank)
                    .OrderBy("Order")
                    .GetAsync<RankDto>();

                var exportType = (type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(exportType)) exportType = "excel";

                byte[] fileBytes;
                string fileName;
                string contentType;

                if (exportType == "excel" || exportType == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("Rank");

                    // ===== TITLE =====
                    ws.Cell("A1").Value = "Rank Master List";
                    ws.Range("A1:D1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // ===== HEADER =====
                    var headers = new[] { "Rank Code", "Rank Name", "Order", "Remarks" };
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
                        ws.Cell(row, 1).Value = item.RankCode;
                        ws.Cell(row, 2).Value = item.RankName;
                        ws.Cell(row, 3).Value = item.SortOrder;
                        ws.Cell(row, 4).Value = item.Remarks ?? string.Empty;
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
                        FileBytes = fileBytes,
                        FileName = $"Rank.xlsx",
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
                                .Text("Rank")
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
                                    columns.RelativeColumn(1.2f); // RankCode
                                    columns.RelativeColumn(1.8f); // RankName
                                    columns.RelativeColumn(0.8f); // Order
                                    columns.RelativeColumn(1.2f); // Remarks
                                });

                                // Header
                                table.Header(header =>
                                {
                                    string[] headers = {
                                        "Rank Code", "Rank Name", "Order", "Remarks"
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
                                        .Text(item.RankCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.RankName ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.SortOrder.ToString())
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.Remarks ?? "-")
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
                        FileBytes = fileBytes,
                        FileName = "Rank.pdf",
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
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "Gagal mengekspor Rank", ex.Message);
            }
        }
    }
}
