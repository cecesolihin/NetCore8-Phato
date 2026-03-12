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
using ThePatho.Features.Global.Announcement.DTO;
using ThePatho.Features.Global.Bank.Commands;
using ThePatho.Features.Global.Bank.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.Bank.Service
{
    public class BankService : IBankService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;

        public BankService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;

        }

        public async Task<ApiResponse<BankItemDto>> GetBank(GetBankCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@BankCode", request.FilterBankCode ?? string.Empty);
                parameters.Add("@Name", request.FilterName ?? string.Empty);
                parameters.Add("@BranchName", request.FilterBranchName ?? string.Empty);
                parameters.Add("@CurrencyCode", request.FilterCurrencyCode ?? string.Empty);
                parameters.Add("@TransferCode", request.FilterTransferCode ?? string.Empty);
                parameters.Add("@TransdferFee", request.FilterTransdferFee ?? 0);
                parameters.Add("@SwiftCode", request.FilterSwiftCode ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/Bank/Sql/get_bank");
                var data = await db.QueryAsync<BankDto>(query, parameters);

                var result = new BankItemDto
                {
                    DataOfRecords = data.Count(),
                    BankList = data.ToList()
                };

                return new ApiResponse<BankItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<BankItemDto>(HttpStatusCode.BadRequest, "Error retrieving Bank list.", ex.Message);
            }
        }

        public async Task<ApiResponse<BankDto>> GetSingleBank(GetSingleBankCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@BankCode", request.FilterBankCode);

                var query = await queryLoader.LoadQueryAsync("Global/Bank/Sql/get_single_bank");
                var data = await db.QueryFirstOrDefaultAsync<BankDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<BankDto>(HttpStatusCode.NotFound, $"Data not Found", "Data not Found");
                }

                return new ApiResponse<BankDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<BankDto>(HttpStatusCode.BadRequest, "Error retrieving Bank detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<BankItemDto>> GetBankByCriteria(GetBankByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@BankCode", request.BankCode ?? string.Empty);
                parameters.Add("@Name", request.BankName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/Bank/Sql/get_criteria_bank");
                var data = await db.QueryAsync<BankDto>(query, parameters);

                var result = new BankItemDto
                {
                    DataOfRecords = data.Count(),
                    BankList = data.ToList()
                };

                return new ApiResponse<BankItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<BankItemDto>(HttpStatusCode.BadRequest, "Error filtering Bank data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitBank(SubmitBankCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@BankCode", request.BankCode);
                parameters.Add("@Name", request.Name);
                parameters.Add("@BranchName", request.BranchName);
                parameters.Add("@CurrencyCode", request.CurrencyCode);
                parameters.Add("@TransferCode", request.TransferCode);
                parameters.Add("@TransdferFee", request.TransdferFee);
                parameters.Add("@SwiftCode", request.SwiftCode);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/Bank/Sql/submit_bank");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.BankCode} successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.BankCode}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteBank(DeleteBankCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@BankCode", request.BankCode);
                var query_single = await queryLoader.LoadQueryAsync("Global/Bank/Sql/get_single_bank");
                var data_single = await db.QueryFirstOrDefaultAsync<BankDto>(query_single, parameters);
                if (data_single == null)
                {
                    return new ApiResponse(HttpStatusCode.NotFound, $"Failed to delete", "Data not Found");
                }
                var query = await queryLoader.LoadQueryAsync("Global/Bank/Sql/delete_bank");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.BankCode} successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.BankCode}", ex.Message);
            }
        }
        public async Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportBankCommand request)
        {
            try
            {
                var criteriaRequest = new GetBankByCriteriaCommand();
                var response = await GetBankByCriteria(criteriaRequest);
                var data = response.Data?.BankList ?? new System.Collections.Generic.List<BankDto>();

                var type = (request.Type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(type)) type = "excel";

                if (type == "excel" || type == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("BankList");

                    // Title
                    worksheet.Cell("A1").Value = "Bank List";
                    worksheet.Range("A1:F1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // Header
                    worksheet.Cell(3, 1).Value = "No";
                    var properties = typeof(BankDto).GetProperties();
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
                        FileName = "BankList.xlsx",
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
                                    .Text("Bank List Data")
                                    .SemiBold()
                                    .FontSize(18)
                                    .FontColor("#007BFF");
                            });

                            // Content
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                var properties = typeof(BankDto).GetProperties();
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
                        FileName = "BankList.pdf",
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
                return new ApiResponse<AttachmentFileDto>(System.Net.HttpStatusCode.BadRequest, default, "Gagal export Bank", ex.Message);
            }
        }
    }
}

