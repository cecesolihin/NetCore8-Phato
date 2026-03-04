using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeePickUp.Commands;
using ThePatho.Features.PersonalInformation.EmployeePickUp.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ThePatho.Features.Common.DTO;
using ThePatho.Domain.Constants;
using System.IO;

namespace ThePatho.Features.PersonalInformation.EmployeePickUp.Service
{
    public class EmployeePickUpService : IEmployeePickUpService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeePickUpService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeePickUpItemDto>> GetEmployeePickUp(GetEmployeePickUpCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@PickUpId", request.FilterPickUpId ?? (object)DBNull.Value);
                parameters.Add("@PickUpLocation", request.FilterPickUpLocation ?? (object)DBNull.Value);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePickUp/Sql/get_employeepickup");
                var data = await db.QueryAsync<EmployeePickUpDto>(query, parameters);

                var result = new EmployeePickUpItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeePickUpList = data.ToList()
                };

                return new ApiResponse<EmployeePickUpItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeePickUpItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Pick Up list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeePickUpDto>> GetSingleEmployeePickUp(GetSingleEmployeePickUpCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PickUpId", request.FilterPickUpId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePickUp/Sql/get_single_employeepickup");
                var data = await db.QueryFirstOrDefaultAsync<EmployeePickUpDto>(query, parameters);

                return new ApiResponse<EmployeePickUpDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeePickUpDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Pick Up detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeePickUpItemDto>> GetEmployeePickUpByCriteria(GetEmployeePickUpByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PickUpId", request.FilterPickUpId ?? (object)DBNull.Value);
                parameters.Add("@PickUpLocation", request.FilterPickUpLocation ?? (object)DBNull.Value);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePickUp/Sql/get_criteria_employeepickup");
                var data = await db.QueryAsync<EmployeePickUpDto>(query, parameters);

                var result = new EmployeePickUpItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeePickUpList = data.ToList()
                };

                return new ApiResponse<EmployeePickUpItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeePickUpItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Pick Up data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeePickUp(SubmitEmployeePickUpCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.PickUpId);
                parameters.Add("@TrainingCourseCode", request.PickUpLocation);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePickUp/Sql/submit_employeepickup");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeePickUp(DeleteEmployeePickUpCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PickUpId", request.FilterPickUpId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePickUp/Sql/delete_employeepickup");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message);
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportEmployeePickUpAsync(string type)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", 0);
                parameters.Add("@PageSize", 1000000);
                parameters.Add("@PickUpId", (object)DBNull.Value);
                parameters.Add("@PickUpLocation", (object)DBNull.Value);
                parameters.Add("@SortBy", "EmployeeId");
                parameters.Add("@OrderBy", "ASC");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePickUp/Sql/get_employeepickup");
                var data = await db.QueryAsync<EmployeePickUpDto>(query, parameters);

                var fileName = string.Empty;
                byte[] fileBytes;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(type, "xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("EmployeePickUp");

                    ws.Cell("A1").Value = "Employee Pick Up List";
                    ws.Range("A1:D1").Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    string[] headers = { "Employee No", "Full Name", "Pick Up ID", "Pick Up Location" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        var cell = ws.Cell(3, i + 1);
                        cell.Value = headers[i];
                        cell.Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));
                    }

                    var row = 4;
                    foreach (var item in data)
                    {
                        ws.Cell(row, 1).Value = item.EmployeeNo;
                        ws.Cell(row, 2).Value = item.EmployeeName;
                        ws.Cell(row, 3).Value = item.PickUpId;
                        ws.Cell(row, 4).Value = item.PickUpLocation;
                        row++;
                    }

                    ws.Columns(1, 4).AdjustToContents();
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeePickUp_{DateTime.Now:yyyyMMdd}.xlsx";

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(fileBytes),
                        FileName = fileName,
                        ContentType = MimeTypesConstants.VND_OPENXML_EXCEL
                    });
                }
                else if (string.Equals(type, "pdf", StringComparison.OrdinalIgnoreCase))
                {
                    var document = Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Margin(30);
                            page.Size(PageSizes.A4);
                            page.Header().AlignCenter().Text("Employee Pick Up List").SemiBold().FontSize(16);
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(80);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("No").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Employee").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Pick Up ID").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Location").Bold();
                                });
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeNo ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeName ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.PickUpId.ToString());
                                    table.Cell().Border(1).Padding(5).Text(item.PickUpLocation ?? "-");
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeePickUp_{DateTime.Now:yyyyMMdd}.pdf";

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(fileBytes),
                        FileName = fileName,
                        ContentType = MimeTypesConstants.PDF
                    });
                }

                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, null, "Invalid export type.");
            }
            catch (Exception ex)
            {
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.InternalServerError, null, ex.Message);
            }
        }
        #endregion
    }
}

