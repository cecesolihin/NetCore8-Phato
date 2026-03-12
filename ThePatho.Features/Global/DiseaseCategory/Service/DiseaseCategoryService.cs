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
using ThePatho.Features.Global.DiseaseCategory.Commands;
using ThePatho.Features.Global.DiseaseCategory.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.DiseaseCategory.Service
{
    public class DiseaseCategoryService : IDiseaseCategoryService
    {
        private readonly DapperContext dapperContext;

        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public DiseaseCategoryService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<DiseaseCategoryItemDto>> GetDiseaseCategory(GetDiseaseCategoryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@DiseaseCategoryCode", request.FilterDiseaseCategoryCode ?? string.Empty);
                parameters.Add("@DiseaseCategoryName", request.FilterDiseaseCategoryName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/DiseaseCategory/Sql/get_diseasecategory");
                var data = await dbConnection.QueryAsync<DiseaseCategoryDto>(query, parameters);
                var result = new DiseaseCategoryItemDto
                {
                    DataOfRecords = data.Count(),
                    DiseaseCategoryList = data.ToList(),
                };
                return new ApiResponse<DiseaseCategoryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<DiseaseCategoryItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<DiseaseCategoryDto>> GetSingleDiseaseCategory(GetSingleDiseaseCategoryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DiseaseCategoryCode", request.FilterDiseaseCategoryCode);

                var query = await queryLoader.LoadQueryAsync("Global/DiseaseCategory/Sql/get_single_diseasecategory");

                var data = await dbConnection.QueryFirstOrDefaultAsync<DiseaseCategoryDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<DiseaseCategoryDto>(HttpStatusCode.OK, "data not found");
                }
                return new ApiResponse<DiseaseCategoryDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<DiseaseCategoryDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<DiseaseCategoryItemDto>> GetDiseaseCategoryByCriteria(GetDiseaseCategoryByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DiseaseCategoryCode", request.DiseaseCategoryCode ?? string.Empty);
                parameters.Add("@DiseaseCategoryName", request.DiseaseCategoryName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/DiseaseCategory/Sql/get_criteria_diseasecategory");
                var data = await dbConnection.QueryAsync<DiseaseCategoryDto>(query, parameters);
                var result = new DiseaseCategoryItemDto
                {
                    DataOfRecords = data.Count(),
                    DiseaseCategoryList = data.ToList(),
                };
                return new ApiResponse<DiseaseCategoryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<DiseaseCategoryItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitDiseaseCategory(SubmitDiseaseCategoryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DiseaseCategoryCode", request.DiseaseCategoryCode);
                parameters.Add("@DiseaseCategoryName", request.DiseaseCategoryName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/DiseaseCategory/Sql/submit_diseasecategory");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.DiseaseCategoryName} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.DiseaseCategoryName}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteDiseaseCategory(DeleteDiseaseCategoryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DiseaseCategoryCode", request.DiseaseCategoryCode);
                var query = await queryLoader.LoadQueryAsync("Global/DiseaseCategory/Sql/get_single_diseasecategory");

                var data = await dbConnection.QueryFirstOrDefaultAsync<DiseaseCategoryDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse(HttpStatusCode.OK, "data not found");
                }
                var query_delete = await queryLoader.LoadQueryAsync("Global/DiseaseCategory/Sql/delete_diseasecategory");
                await dbConnection.ExecuteAsync(query_delete, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"Delete successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message.ToString());
            }
        }
        public async Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportDiseaseCategoryCommand request)
        {
            try
            {
                var criteriaRequest = new GetDiseaseCategoryByCriteriaCommand();
                var response = await GetDiseaseCategoryByCriteria(criteriaRequest);
                var data = response.Data?.DiseaseCategoryList ?? new System.Collections.Generic.List<DiseaseCategoryDto>();

                var type = (request.Type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(type)) type = "excel";

                if (type == "excel" || type == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("DiseaseCategoryList");

                    // Title
                    worksheet.Cell("A1").Value = "DiseaseCategory List";
                    worksheet.Range("A1:F1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // Header
                    worksheet.Cell(3, 1).Value = "No";
                    var properties = typeof(DiseaseCategoryDto).GetProperties();
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
                        FileName = "DiseaseCategoryList.xlsx",
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
                                    .Text("DiseaseCategory List Data")
                                    .SemiBold()
                                    .FontSize(18)
                                    .FontColor("#007BFF");
                            });

                            // Content
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                var properties = typeof(DiseaseCategoryDto).GetProperties();
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
                        FileName = "DiseaseCategoryList.pdf",
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
                return new ApiResponse<AttachmentFileDto>(System.Net.HttpStatusCode.BadRequest, default, "Gagal export DiseaseCategory", ex.Message);
            }
        }
    }
}

