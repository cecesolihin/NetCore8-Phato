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
using ThePatho.Features.Organization.CostCenter.Commands;
using ThePatho.Features.Organization.CostCenter.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Organization.CostCenter.Service
{
    public class CostCenterService : ICostCenterService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;
        private readonly ICurrentUserService currentUserService;

        public CostCenterService(DapperContext _dapperContext, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<CostCenterItemDto>> GetCostCenter(GetCostCenterCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.CostCenter)
                    .Select("*")
                    .Where("IsDeleted", false)
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterCostCenter),
                        q => q.Where(w => w
                            .WhereContains("CostCenterCode", request.FilterCostCenter)
                            .OrWhereContains("CostCenterName", request.FilterCostCenter)
                            .OrWhereContains("CostCenterType", request.FilterCostCenter)
                        )
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<CostCenterDto>(query);

                var result = new CostCenterItemDto
                {
                    DataOfRecords = data.Count(),
                    CostCenterList = data.ToList(),
                };
                return new ApiResponse<CostCenterItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CostCenterItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<CostCenterItemDto>> GetCostCenterByCriteria(GetCostCenterByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.CostCenter)
                    .Select("*")
                    .Where("IsDeleted", false)
                    .When(
                        !string.IsNullOrWhiteSpace(request.CostCenterCode),
                        q => q.WhereContains("CostCenterCode", request.CostCenterCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.CostCenterName),
                        q => q.WhereContains("CostCenterName", request.CostCenterName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.CostCenterType),
                        q => q.Where("CostCenterType", request.CostCenterType)
                    );

                var data = await db.GetAsync<CostCenterDto>(query);

                var result = new CostCenterItemDto
                {
                    DataOfRecords = data.Count(),
                    CostCenterList = data.ToList(),
                };
                return new ApiResponse<CostCenterItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CostCenterItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitCostCenter(SubmitCostCenterCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var argumentException = new List<string>();
                
                // Cek apakah CostCenterCode sudah exists
                var existsQuery = new Query(TableOrganization.CostCenter)
                    .Where("CostCenterCode", request.CostCenterCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.CostCenter).AsInsert(new
                    {
                        CostCenterCode = request.CostCenterCode,
                        CostCenterName = request.CostCenterName,
                        SortOrder = request.SortOrder,
                        CostCenterType = request.CostCenterType,
                        IsDeleted = 0,
                        InsertedBy = currentUserService.GetUserName() ?? "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.CostCenter)
                        .Where("CostCenterCode", request.CostCenterCode) 
                        .AsUpdate(new
                        {
                            CostCenterName = request.CostCenterName,
                            SortOrder = request.SortOrder,
                            CostCenterType = request.CostCenterType,
                            ModifiedBy  = currentUserService.GetUserName() ?? "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.CostCenterCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.CostCenterCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteCostCenter(DeleteCostCenterCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.CostCenterCode))
                {
                    return new ApiResponse(
                        HttpStatusCode.BadRequest,
                        "CostCenter is required"
                    );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var updateResult = await db
                    .Query(TableOrganization.CostCenter)
                    .Where("CostCenterCode", request.CostCenterCode)
                    .WhereFalse("IsDeleted") // optional: prevent double delete
                    .UpdateAsync(new
                    {
                        IsDeleted = true,
                        ModifiedBy  = currentUserService.GetUserName() ?? "system",
                        ModifiedDate = DateTime.UtcNow
                    });

                if (updateResult == 0)
                {
                    return new ApiResponse(
                        HttpStatusCode.NotFound,
                        $"CostCenter {request.CostCenterCode} not found"
                    );
                }

                return new ApiResponse(
                    HttpStatusCode.OK,
                    $"Delete {request.CostCenterCode} successfully"
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse(
                    HttpStatusCode.InternalServerError,
                    $"Failed to delete {request.CostCenterCode}",
                    ex.Message
                );
            }

        }

        public async Task<ApiResponse<CostCenterDto>> GetSingleCostCenter(GetSingleCostCenterCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.CostCenter)
                    .Select("*")
                    .Where("CostCenterCode", request.CostCenterCode);
                   
                var data = await db.FirstOrDefaultAsync<CostCenterDto>(query);
                return new ApiResponse<CostCenterDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CostCenterDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        
        public async Task<ApiResponse<AttachmentFileDto>> ExportCostCenterAsync(string type)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.CostCenter)
                    .Select(
                        "CostCenterCode",
                        "CostCenterName",
                        "SortOrder",
                        "CostCenterType"
                    )
                    .Where("IsDeleted", 0)
                    .OrderBy("CostCenterCode");

                var data = await db.GetAsync<CostCenterDto>(query);

                var exportType = (type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(exportType)) exportType = "excel";

                if (exportType == "excel" || exportType == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("CostCenter");

                    worksheet.Cell("A1").Value = "Cost Center List";
                    worksheet.Range("A1:D1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    worksheet.Cell(3, 1).Value = "Cost Center Code";
                    worksheet.Cell(3, 2).Value = "Cost Center Name";
                    worksheet.Cell(3, 3).Value = "SortOrder";
                    worksheet.Cell(3, 4).Value = "Type";

                    worksheet.Range(3, 1, 3, 4).Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));

                    var row = 4;
                    foreach (var item in data)
                    {
                        worksheet.Cell(row, 1).Value = item.CostCenterCode;
                        worksheet.Cell(row, 2).Value = item.CostCenterName;
                        worksheet.Cell(row, 3).Value = item.SortOrder;
                        worksheet.Cell(row, 4).Value = item.CostCenterType;
                        row++;
                    }

                    worksheet.Columns(1, 4).AdjustToContents();

                    var lastDataRow = row - 1;
                    var tableRange = worksheet.Range(3, 1, lastDataRow, 4);
                    tableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    tableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    using var stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    var bytes = stream.ToArray();

                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(bytes),
                        FileName = "CostCenter.xlsx",
                        ContentType = MimeTypesConstants.VND_OPENXML_EXCEL
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);
                }
                else if (exportType == "pdf")
                {
                    var doc = Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Margin(30);
                            page.Size(PageSizes.A4.Landscape());

                            // Title
                            page.Header()
                                .AlignCenter()
                                .Text("Cost Center List")
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
                                    columns.RelativeColumn(1.2f); // Code
                                    columns.RelativeColumn(2f);   // Name
                                    columns.RelativeColumn(0.8f); // Sort
                                    columns.RelativeColumn(1.2f); // Type
                                });

                                // Header
                                table.Header(header =>
                                {
                                    string[] headers = { "Cost Center Code", "Cost Center Name", "SortOrder", "Type" };

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
                                        .Text(item.CostCenterCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.CostCenterName ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.SortOrder.ToString())
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.CostCenterType ?? "-")
                                        .Style(normalTextStyle);
                                }
                            });
                        });
                    });

                    using var stream = new MemoryStream();
                    doc.GeneratePdf(stream);
                    var bytes = stream.ToArray();

                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(bytes),
                        FileName = "CostCenter.pdf",
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
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "Gagal export cost center", ex.Message);
            }
        }
        #endregion
    }
}
