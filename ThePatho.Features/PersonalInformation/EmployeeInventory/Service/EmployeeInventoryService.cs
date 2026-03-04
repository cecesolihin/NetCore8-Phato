using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeInventory.Commands;
using ThePatho.Features.PersonalInformation.EmployeeInventory.DTO;
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

namespace ThePatho.Features.PersonalInformation.EmployeeInventory.Service
{
    public class EmployeeInventoryService : IEmployeeInventoryService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeeInventoryService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeInventoryItemDto>> GetEmployeeInventory(GetEmployeeInventoryCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@Inventory", request.FilterInventory ?? string.Empty);
                parameters.Add("@ReceivedDateFrom", request.FilterReceivedDateFrom);
                parameters.Add("@ReceivedDateTo", request.FilterReceivedDateTo);
                parameters.Add("@ReturnDateFrom", request.FilterReturnDateFrom);
                parameters.Add("@ReturnDateTo", request.FilterReturnDateTo);
                parameters.Add("@ReturnPlanDateFrom", request.FilterReturnPlanDateFrom);
                parameters.Add("@ReturnPlanDateTo", request.FilterReturnPlanDateTo);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeInventory/Sql/get_emp_inventory");
                var data = await db.QueryAsync<EmployeeInventoryDto>(query, parameters);

                var result = new EmployeeInventoryItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeInventoryList = data.ToList()
                };

                return new ApiResponse<EmployeeInventoryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeInventoryItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Inventory list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeInventoryDto>> GetSingleEmployeeInventory(GetSingleEmployeeInventoryCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@InventoryNo", request.InventoryNo);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeInventory/Sql/get_single_emp_inventory");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeInventoryDto>(query, parameters);

                return new ApiResponse<EmployeeInventoryDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeInventoryDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Inventory detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeInventoryItemDto>> GetEmployeeInventoryByCriteria(GetEmployeeInventoryByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryNo", request.InventoryNo ?? string.Empty);
                parameters.Add("@InventoryTypeCode", request.InventoryTypeCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeInventory/Sql/get_criteria_emp_inventory");
                var data = await db.QueryAsync<EmployeeInventoryDto>(query, parameters);

                var result = new EmployeeInventoryItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeInventoryList = data.ToList()
                };

                return new ApiResponse<EmployeeInventoryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeInventoryItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Inventory data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeInventory(SubmitEmployeeInventoryCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@InventoryNo", request.InventoryNo);
                parameters.Add("@InventoryTpyeCode", request.InventoryTypeCode);
                parameters.Add("@InventoryName", request.InventoryName);
                parameters.Add("@ReceivedDate", request.ReceivedDate);
                parameters.Add("@ReceivedQty", request.ReceivedQty);
                parameters.Add("@ReceivedCondition", request.ReceivedCondition);
                parameters.Add("@ReceivedRemark", request.ReceivedRemark);
                parameters.Add("@ReturnPlanDate", request.ReturnPlanDate);
                parameters.Add("@Size", request.Size);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeInventory/Sql/submit_emp_inventory");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeInventory(DeleteEmployeeInventoryCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@InventoryNo", request.InventoryNo);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeInventory/Sql/delete_emp_inventory");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message);
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportEmployeeInventoryAsync(string type)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", 1);
                parameters.Add("@PageSize", 1000000);
                parameters.Add("@EmployeeId", 0);
                parameters.Add("@Inventory", "");
                parameters.Add("@SortBy", "EmployeeId");
                parameters.Add("@OrderBy", "ASC");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeInventory/Sql/get_emp_inventory");
                var data = await db.QueryAsync<EmployeeInventoryDto>(query, parameters);

                var fileName = string.Empty;
                byte[] fileBytes;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(type, "xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("EmployeeInventory");

                    ws.Cell("A1").Value = "Employee Inventory List";
                    ws.Range("A1:G1").Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    string[] headers = { "Employee No", "Employee Name", "Inventory No", "Inventory Name", "Received Date", "Return Plan Date", "Qty" };
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
                        ws.Cell(row, 3).Value = item.InventoryNo;
                        ws.Cell(row, 4).Value = item.InventoryName;
                        ws.Cell(row, 5).Value = item.ReceivedDate;
                        ws.Cell(row, 6).Value = item.ReturnPlanDate;
                        ws.Cell(row, 7).Value = item.ReceivedQty;
                        row++;
                    }

                    ws.Columns(1, 7).AdjustToContents();
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeInventory_{DateTime.Now:yyyyMMdd}.xlsx";

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
                            page.Size(PageSizes.A4.Landscape());
                            page.Header().AlignCenter().Text("Employee Inventory List").SemiBold().FontSize(16);
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(80);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.ConstantColumn(100);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("No").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Employee").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Inventory").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Received Date").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Return Plan").Bold();
                                });
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeNo ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeName ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.InventoryName ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.ReceivedDate ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.ReturnPlanDate ?? "-");
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeInventory_{DateTime.Now:yyyyMMdd}.pdf";

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
