using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.IO;
using System.Reflection;
using ThePatho.Domain.Constants;
using ThePatho.Features.Common.DTO;

using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.TaxStatus.Commands;
using ThePatho.Features.Global.TaxStatus.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.TaxStatus.Service
{
    public class TaxStatusService : ITaxStatusService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public TaxStatusService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<TaxStatusItemDto>> GetTaxStatus(GetTaxStatusCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@TaxStatusCode", request.FilterTaxStatusCode ?? string.Empty);
                parameters.Add("@TaxStatusName", request.FilterTaxStatusName ?? string.Empty);
                parameters.Add("@Married", request.FilterMarried ?? string.Empty);
                parameters.Add("@TotalDependents", request.FilterTotalDependents ?? 0);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/TaxStatus/Sql/get_tax_status");
                var data = await db.QueryAsync<TaxStatusDto>(query, parameters);

                var result = new TaxStatusItemDto
                {
                    DataOfRecords = data.Count(),
                    TaxStatusList = data.ToList()
                };

                return new ApiResponse<TaxStatusItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TaxStatusItemDto>(HttpStatusCode.BadRequest, "Error retrieving Tax Status list.", ex.Message);
            }
        }

        public async Task<ApiResponse<TaxStatusDto>> GetSingleTaxStatus(GetSingleTaxStatusCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@TaxStatusCode", request.FilterTaxStatusCode);

                var query = await queryLoader.LoadQueryAsync("Global/TaxStatus/Sql/get_single_tax_status");
                var data = await db.QueryFirstOrDefaultAsync<TaxStatusDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<TaxStatusDto>(HttpStatusCode.NotFound, $"Data not Found", "Data not Found");
                }

                return new ApiResponse<TaxStatusDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TaxStatusDto>(HttpStatusCode.BadRequest, "Error retrieving Tax Status detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<TaxStatusItemDto>> GetTaxStatusByCriteria(GetTaxStatusByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@TaxStatusCode", request.TaxStatusCode);
                parameters.Add("@TaxStatusName", request.TaxStatusName);
                parameters.Add("@Married", request.Married ?? string.Empty);
                parameters.Add("@TotalDependents", request.TotalDependents ?? 0);

                var query = await queryLoader.LoadQueryAsync("Global/TaxStatus/Sql/get_criteria_tax_status");
                var data = await db.QueryAsync<TaxStatusDto>(query, parameters);

                var result = new TaxStatusItemDto
                {
                    DataOfRecords = data.Count(),
                    TaxStatusList = data.ToList()
                };

                return new ApiResponse<TaxStatusItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TaxStatusItemDto>(HttpStatusCode.BadRequest, "Error filtering Tax Status data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitTaxStatus(SubmitTaxStatusCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var ArgumentException = new List<string>();

                if (string.IsNullOrWhiteSpace(request.TaxStatusCode))
                    ArgumentException.Add("Tax Status Code is required.");

                if (string.IsNullOrWhiteSpace(request.TaxStatusName))
                    ArgumentException.Add("Tax Status Name is required.");

                if (ArgumentException.Any())
                {
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.TaxStatusName}", string.Join(", ", ArgumentException.ToArray()));
                }

                var parameters = new DynamicParameters();
                parameters.Add("@TaxStatusCode", request.TaxStatusCode);
                parameters.Add("@TaxStatusName", request.TaxStatusName);
                parameters.Add("@Married", request.Married);
                parameters.Add("@TotalDependents", request.TotalDependents);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/TaxStatus/Sql/submit_tax_status");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.TaxStatusCode} successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.TaxStatusCode}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteTaxStatus(DeleteTaxStatusCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@TaxStatusCode", request.TaxStatusCode);
                var query_single = await queryLoader.LoadQueryAsync("Global/TaxStatus/Sql/get_single_tax_status");
                var data_single = await db.QueryFirstOrDefaultAsync<TaxStatusDto>(query_single, parameters);
                if (data_single == null)
                {
                    return new ApiResponse(HttpStatusCode.NotFound, $"Failed to delete", "Data not Found");
                }
                var query = await queryLoader.LoadQueryAsync("Global/TaxStatus/Sql/delete_tax_status");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.TaxStatusCode} successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.TaxStatusCode}", ex.Message);
            }
        }
        public async Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportTaxStatusCommand request)
        {
            try
            {
                var criteriaRequest = new GetTaxStatusByCriteriaCommand();
                var response = await GetTaxStatusByCriteria(criteriaRequest);
                var data = response.Data?.TaxStatusList ?? new System.Collections.Generic.List<TaxStatusDto>();

                var type = (request.Type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(type)) type = "excel";

                if (type == "excel" || type == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("TaxStatusList");

                    // Title
                    worksheet.Cell("A1").Value = "TaxStatus List";
                    worksheet.Range("A1:F1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // Header
                    worksheet.Cell(3, 1).Value = "No";
                    var properties = typeof(TaxStatusDto).GetProperties();
                    int col = 2;
                    foreach (var prop in properties)
                    {
                        worksheet.Cell(3, col).Value = prop.Name;
                        col++;
                    }

                    worksheet.Range(3, 1, 3, col - 1).Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));

                    // Data
                    var row = 4;
                    int no = 1;

                    foreach (var item in data)
                    {
                        worksheet.Cell(row, 1).Value = no++;
                        int dataCol = 2;
                        foreach (var prop in properties)
                        {
                            var val = prop.GetValue(item);
                            if (val is bool b)
                            {
                                worksheet.Cell(row, dataCol).Value = b ? "Active" : "Inactive";
                            }
                            else
                            {
                                worksheet.Cell(row, dataCol).Value = val?.ToString() ?? "";
                            }
                            dataCol++;
                        }
                        row++;
                    }

                    worksheet.Columns(1, col - 1).AdjustToContents();

                    var lastDataRow = row > 4 ? row - 1 : 3;
                    if (col > 1)
                    {
                        var tableRange = worksheet.Range(3, 1, lastDataRow, col - 1);
                        tableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        tableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    }

                    using var stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    var bytes = stream.ToArray();

                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(bytes),
                        FileName = "TaxStatusList.xlsx",
                        ContentType = MimeTypesConstants.VND_OPENXML_EXCEL
                    };

                    return new ApiResponse<AttachmentFileDto>(System.Net.HttpStatusCode.OK, dto);
                }
                else if (type == "pdf")
                {
                    var doc = Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Margin(30);
                            page.Size(PageSizes.A4.Landscape());

                            // Title
                            page.Header().Element(header =>
                            {
                                header.AlignCenter()
                                    .PaddingBottom(10)
                                    .Text("TaxStatus List Data")
                                    .SemiBold()
                                    .FontSize(18)
                                    .FontColor("#007BFF");
                            });

                            // Content
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                var properties = typeof(TaxStatusDto).GetProperties();
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(30);
                                    foreach (var prop in properties)
                                    {
                                        columns.RelativeColumn();
                                    }
                                });

                                var headerStyle = TextStyle.Default.FontSize(10).Bold();
                                var normalTextStyle = TextStyle.Default.FontSize(8);

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).PaddingVertical(4).PaddingHorizontal(6).Background(Colors.BlueGrey.Lighten2).AlignCenter().AlignMiddle().Text("No").Style(headerStyle);
                                    foreach (var prop in properties)
                                    {
                                        header.Cell().Border(1).PaddingVertical(4).PaddingHorizontal(6).Background(Colors.BlueGrey.Lighten2).AlignCenter().AlignMiddle().Text(prop.Name).Style(headerStyle);
                                    }
                                });

                                var no = 1;
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(3).AlignCenter().Text(no.ToString()).Style(normalTextStyle);
                                    foreach (var prop in properties)
                                    {
                                        var val = prop.GetValue(item);
                                        var textVal = "";
                                        if (val is bool b)
                                        {
                                            textVal = b ? "Active" : "Inactive";
                                        }
                                        else
                                        {
                                            textVal = val?.ToString() ?? "-";
                                        }
                                        table.Cell().Border(1).Padding(3).Text(textVal).Style(normalTextStyle);
                                    }
                                    no++;
                                }
                            });
                        });
                    });

                    var bytes = doc.GeneratePdf();
                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(bytes),
                        FileName = "TaxStatusList.pdf",
                        ContentType = MimeTypesConstants.PDF
                    };

                    return new ApiResponse<AttachmentFileDto>(System.Net.HttpStatusCode.OK, dto);
                }
                else
                {
                    return new ApiResponse<AttachmentFileDto>(System.Net.HttpStatusCode.BadRequest, default, "Type harus 'excel' atau 'pdf'");
                }
            }
            catch (System.Exception ex)
            {
                return new ApiResponse<AttachmentFileDto>(System.Net.HttpStatusCode.BadRequest, default, "Gagal export TaxStatus", ex.Message);
            }
        }
    }
}

