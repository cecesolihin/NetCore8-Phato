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
using ThePatho.Features.Global.CareerType.Commands;
using ThePatho.Features.Global.CareerType.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.CareerType.Service
{
    public class CareerTypeService : ICareerTypeService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public CareerTypeService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<CareerTypeItemDto>> GetCareerType(GetCareerTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@CareerTypeCode", request.FilterCareerTypeCode ?? (object)DBNull.Value);
                parameters.Add("@CareerTypeName", request.FilterCareerTypeName ?? (object)DBNull.Value);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/CareerType/Sql/get_careertype");
                var data = await dbConnection.QueryAsync<CareerTypeDto>(query, parameters);
                var result = new CareerTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    CareerTypeList = data.ToList(),
                };
                return new ApiResponse<CareerTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CareerTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<CareerTypeDto>> GetSingleCareerType(GetSingleCareerTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CareerTypeCode", request.FilterCareerTypeCode ?? (object)DBNull.Value);

                var query = await queryLoader.LoadQueryAsync("Global/CareerType/Sql/get_single_careertype");

                var data = await dbConnection.QueryFirstOrDefaultAsync<CareerTypeDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<CareerTypeDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<CareerTypeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CareerTypeDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<CareerTypeItemDto>> GetCareerTypeByCriteria(GetCareerTypeByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CareerTypeCode", request.CareerTypeCode ?? "");
                parameters.Add("@CareerTypeName", request.CareerTypeName ?? "");


                var query = await queryLoader.LoadQueryAsync("Global/CareerType/Sql/get_criteria_careertype");
                var data = await dbConnection.QueryAsync<CareerTypeDto>(query, parameters);
                var result = new CareerTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    CareerTypeList = data.ToList(),
                };
                return new ApiResponse<CareerTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CareerTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitCareerType(SubmitCareerTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CareerTypeCode", request.CareerTypeCode);
                parameters.Add("@CareerTypeName", request.CareerTypeName);
                parameters.Add("@Action", request.Action);
                var userName = currentUserService.GetUserName();
                parameters.Add("@User", string.IsNullOrWhiteSpace(userName) ? "admin" : userName);

                var query = await queryLoader.LoadQueryAsync("Global/CareerType/Sql/submit_careertype");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.CareerTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.CareerTypeCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteCareerType(DeleteCareerTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CareerTypeCode", request.CareerTypeCode);

                var query_single = await queryLoader.LoadQueryAsync("Global/CareerType/Sql/get_single_careertype");

                var data_single = await dbConnection.QueryFirstOrDefaultAsync<CareerTypeDto>(query_single, parameters);

                if (data_single == null)
                {
                    return new ApiResponse<CareerTypeDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query = await queryLoader.LoadQueryAsync("Global/CareerType/Sql/delete_careertype");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"Delete successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message.ToString());
            }
        }
        public async Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportCareerTypeCommand request)
        {
            try
            {
                var criteriaRequest = new GetCareerTypeByCriteriaCommand();
                var response = await GetCareerTypeByCriteria(criteriaRequest);
                var data = response.Data?.CareerTypeList ?? new System.Collections.Generic.List<CareerTypeDto>();

                var type = (request.Type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(type)) type = "excel";

                if (type == "excel" || type == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("CareerTypeList");

                    // Title
                    worksheet.Cell("A1").Value = "CareerType List";
                    worksheet.Range("A1:F1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // Header
                    worksheet.Cell(3, 1).Value = "No";
                    var properties = typeof(CareerTypeDto).GetProperties();
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
                        FileName = "CareerTypeList.xlsx",
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
                                    .Text("CareerType List Data")
                                    .SemiBold()
                                    .FontSize(18)
                                    .FontColor("#007BFF");
                            });

                            // Content
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                var properties = typeof(CareerTypeDto).GetProperties();
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
                        FileName = "CareerTypeList.pdf",
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
                return new ApiResponse<AttachmentFileDto>(System.Net.HttpStatusCode.BadRequest, default, "Gagal export CareerType", ex.Message);
            }
        }
    }
}

