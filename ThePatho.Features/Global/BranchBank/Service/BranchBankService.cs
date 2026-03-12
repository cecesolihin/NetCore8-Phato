using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.IO;
using System.Reflection;
using ThePatho.Domain.Constants;
using ThePatho.Features.Common.DTO;

using Dapper;
using System.Net;
using ThePatho.Features.Global.BloodType.DTO;
using ThePatho.Features.Global.BranchBank.Commands;
using ThePatho.Features.Global.BranchBank.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.BranchBank.Service
{
    public class BranchBankService : IBranchBankService
    {
        private readonly DapperContext dapperContext;
        private readonly SqlQueryLoader queryLoader;
        private readonly ICurrentUserService currentUserService;

        public BranchBankService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<BranchBankItemDto>> GetBranchBank(GetBranchBankCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@BranchBankCode", request.FilterBranchBankCode ?? string.Empty);
                parameters.Add("@BranchBankName", request.FilterBranchBankName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/BranchBank/Sql/get_branch_bank");
                var data = await db.QueryAsync<BranchBankDto>(query, parameters);

                var result = new BranchBankItemDto
                {
                    DataOfRecords = data.Count(),
                    BranchBankList = data.ToList()
                };

                return new ApiResponse<BranchBankItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<BranchBankItemDto>(
                    HttpStatusCode.BadRequest,
                    "An error occurred while retrieving Branch Bank list.",
                    ex.Message
                );
            }
        }

        public async Task<ApiResponse<BranchBankDto>> GetSingleBranchBank(GetSingleBranchBankCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@BranchBankCode", request.FilterBranchBankCode);

                var query = await queryLoader.LoadQueryAsync("Global/BranchBank/Sql/get_single_branch_bank");
                var data = await db.QueryFirstOrDefaultAsync<BranchBankDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<BranchBankDto>(HttpStatusCode.NotFound, $"Data not Found", "Data not Found");
                }
                return new ApiResponse<BranchBankDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<BranchBankDto>(
                    HttpStatusCode.BadRequest,
                    "An error occurred while retrieving Branch Bank data.",
                    ex.Message
                );
            }
        }

        public async Task<ApiResponse<BranchBankItemDto>> GetBranchBankByCriteria(GetBranchBankByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@BranchBankCode", request.FilterBranchBankCode ?? string.Empty);
                parameters.Add("@BranchBankName", request.FilterBranchBankName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/BranchBank/Sql/get_criteria_branch_bank");
                var data = await db.QueryAsync<BranchBankDto>(query, parameters);

                var result = new BranchBankItemDto
                {
                    DataOfRecords = data.Count(),
                    BranchBankList = data.ToList()
                };

                return new ApiResponse<BranchBankItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<BranchBankItemDto>(
                    HttpStatusCode.BadRequest,
                    "An error occurred while filtering Branch Bank data.",
                    ex.Message
                );
            }
        }

        public async Task<ApiResponse> SubmitBranchBank(SubmitBranchBankCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();

                var ArgumentException = new List<string>();

                if (string.IsNullOrWhiteSpace(request.BranchBankCode))
                    ArgumentException.Add("Branch Bank Code Code is required.");

                if (string.IsNullOrWhiteSpace(request.BranchBankName))
                    ArgumentException.Add("Branch Bank Name Name is required.");

                if (ArgumentException.Any())
                {
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.BranchBankName}", string.Join(", ", ArgumentException.ToArray()));
                }
                var parameters = new DynamicParameters();
                parameters.Add("@BranchBankCode", request.BranchBankCode);
                parameters.Add("@BranchBankName", request.BranchBankName);
                parameters.Add("@Action", request.Action);
                var userName = currentUserService.GetUserName();
                parameters.Add("@User", string.IsNullOrWhiteSpace(userName) ? "admin" : userName);

                var query = await queryLoader.LoadQueryAsync("Global/BranchBank/Sql/submit_branch_bank");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.BranchBankCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.BranchBankCode}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteBranchBank(DeleteBranchBankCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@BranchBankCode", request.BranchBankCode);
                var query_single = await queryLoader.LoadQueryAsync("Global/BranchBank/Sql/get_single_branch_bank");
                var data = await db.QueryFirstOrDefaultAsync<BranchBankDto>(query_single, parameters);
                if (query_single == null)
                {
                    return new ApiResponse<BranchBankDto>(HttpStatusCode.NotFound, $"Data not Found", "Data not Found");
                }
                var query = await queryLoader.LoadQueryAsync("Global/BranchBank/Sql/delete_branch_bank");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.BranchBankCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.BranchBankCode}", ex.Message);
            }
        }
        public async Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportBranchBankCommand request)
        {
            try
            {
                var criteriaRequest = new GetBranchBankByCriteriaCommand();
                var response = await GetBranchBankByCriteria(criteriaRequest);
                var data = response.Data?.BranchBankList ?? new System.Collections.Generic.List<BranchBankDto>();

                var type = (request.Type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(type)) type = "excel";

                if (type == "excel" || type == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("BranchBankList");

                    // Title
                    worksheet.Cell("A1").Value = "BranchBank List";
                    worksheet.Range("A1:F1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // Header
                    worksheet.Cell(3, 1).Value = "No";
                    var properties = typeof(BranchBankDto).GetProperties();
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
                        FileName = "BranchBankList.xlsx",
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
                                    .Text("BranchBank List Data")
                                    .SemiBold()
                                    .FontSize(18)
                                    .FontColor("#007BFF");
                            });

                            // Content
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                var properties = typeof(BranchBankDto).GetProperties();
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
                        FileName = "BranchBankList.pdf",
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
                return new ApiResponse<AttachmentFileDto>(System.Net.HttpStatusCode.BadRequest, default, "Gagal export BranchBank", ex.Message);
            }
        }
    }
}

