using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Commands;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.QueryExecute;
using ThePatho.Provider.UserContext;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ThePatho.Features.Common.DTO;
using ThePatho.Domain.Constants;
using System.IO;

namespace ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Service
{
    public class EmployeeCareerHistoryService : IEmployeeCareerHistoryService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeeCareerHistoryService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeCareerHistoryItemDto>> GetEmployeeCareerHistory(GetEmployeeCareerHistoryCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@CareerHistory", request.FilterCareerHistory ?? string.Empty);
                parameters.Add("@EffectiveDateFrom", request.FilterEffectiveDateFrom);
                parameters.Add("@EffectiveDateTo", request.FilterEffectiveDateTo);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeCareerHistory/Sql/get_emp_career");
                var data = await db.QueryAsync<EmployeeCareerHistoryDto>(query, parameters);

                var result = new EmployeeCareerHistoryItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeCareerHistoryList = data.ToList()
                };

                return new ApiResponse<EmployeeCareerHistoryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeCareerHistoryItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Career History list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeCareerHistoryDto>> GetSingleEmployeeCareerHistory(GetSingleEmployeeCareerHistoryCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                //parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@CareerHistoryNo", request.CareerHistoryNo);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeCareerHistory/Sql/get_single_emp_career");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeCareerHistoryDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeCareerHistoryDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeeCareerHistoryDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeCareerHistoryDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Career History detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeCareerHistoryItemDto>> GetEmployeeCareerHistoryByCriteria(GetEmployeeCareerHistoryByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId ?? 0);
                parameters.Add("@CareerHistoryNo", request.CareerHistoryNo ?? string.Empty);
                parameters.Add("@CareerType", request.CareerType ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeCareerHistory/Sql/get_criteria_emp_career");
                var data = await db.QueryAsync<EmployeeCareerHistoryDto>(query, parameters);

                var result = new EmployeeCareerHistoryItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeCareerHistoryList = data.ToList()
                };

                return new ApiResponse<EmployeeCareerHistoryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeCareerHistoryItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Career History data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeCareerHistory(SubmitEmployeeCareerHistoryCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@CareerHistoryNo", request.CareerHistoryNo);
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@EmployeeNo", request.EmployeeNo);
                parameters.Add("@CompanyCode", request.CompanyCode);
                parameters.Add("@EmploymentTypeCode", request.EmploymentTypeCode);
                parameters.Add("@ChangeType", request.ChangeType);
                parameters.Add("@PositionCode", request.PositionCode);
                parameters.Add("@OrgStructureId", request.OrgStructureId);
                parameters.Add("@JobLevelCode", request.JobLevelCode);
                parameters.Add("@JobClassCode", request.JobClassCode);
                parameters.Add("@GradeCode", request.GradeCode);
                parameters.Add("@RankCode", request.RankCode);
                parameters.Add("@CostCenterCode", request.CostCenterCode);
                parameters.Add("@StartDate", request.StartDate);
                parameters.Add("@EndDate", request.EndDate);
                parameters.Add("@Remark", request.Remark);
                parameters.Add("@IsDeleted", request.IsDeleted);
                parameters.Add("@WorkLocationCode", request.WorkLocationCode);
                parameters.Add("@ResignTypeCode", request.ResignTypeCode);
                parameters.Add("@TerminationTypeCode", request.TerminationTypeCode);
                parameters.Add("@PensionTypeCode", request.PensionTypeCode);
                parameters.Add("@AssignmentLocation", request.AssignmentLocation);
                parameters.Add("@EffectiveDateTo", request.EffectiveDateTo);
                parameters.Add("@TaxLocationId", request.TaxLocationId);
                parameters.Add("@IsIncludeSalary", request.IsIncludeSalary);
                parameters.Add("@EmpSalCompId", request.EmpSalCompId);
                parameters.Add("@MutationTypeCode", request.MutationTypeCode);
                parameters.Add("@UsePayrollData", request.UsePayrollData);
                parameters.Add("@UseOldJoinDate", request.UseOldJoinDate);
                parameters.Add("@JoinDate", request.JoinDate);
                parameters.Add("@OldEmployeeId", request.OldEmployeeId);
                parameters.Add("@Path", request.Path);
                parameters.Add("@JabatanId", request.JabatanId);
                parameters.Add("@IsEligibleRehire", request.IsEligibleRehire);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeCareerHistory/Sql/submit_emp_career");
                await db.ExecuteAsync(query, parameters);

                var result = await db.QueryFirstOrDefaultAsync<ExecuteResult>(query, parameters);

                if (result != null && result.Success)
                    return new ApiResponse(HttpStatusCode.OK, result.Message);
                else
                    return new ApiResponse(HttpStatusCode.BadRequest, result?.Message ?? "Unknown error", result?.ErrorNote);
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeCareerHistory(DeleteEmployeeCareerHistoryCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeID", request.EmployeeId);
                parameters.Add("@CareerHistoryNo", request.CareerHistoryNo);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeCareerHistory/Sql/get_single_emp_career");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeCareerHistoryDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeCareerHistoryDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeCareerHistory/Sql/delete_emp_career");
                await db.ExecuteAsync(query_delete, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message);
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportEmployeeCareerHistoryAsync(string type)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", 0);
                parameters.Add("@PageSize", 1000000);
                parameters.Add("@EmployeeId", 0);
                parameters.Add("@CareerHistory", "");
                parameters.Add("@EffectiveDateFrom", null);
                parameters.Add("@EffectiveDateTo", null);
                parameters.Add("@SortBy", "EmployeeId");
                parameters.Add("@OrderBy", "ASC");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeCareerHistory/Sql/get_emp_career");
                var data = await db.QueryAsync<EmployeeCareerHistoryDto>(query, parameters);

                var fileName = string.Empty;
                byte[] fileBytes;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(type, "xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("CareerHistory");

                    ws.Cell("A1").Value = "Employee Career History List";
                    ws.Range("A1:H1").Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    string[] headers = { "Employee No", "Full Name", "Company", "Position", "Job Level", "Start Date", "End Date", "Remark" };
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
                        ws.Cell(row, 3).Value = item.CompanyName;
                        ws.Cell(row, 4).Value = item.PositionName;
                        ws.Cell(row, 5).Value = item.JobLevelName;
                        ws.Cell(row, 6).Value = item.StartDate;
                        ws.Cell(row, 7).Value = item.Remark;
                        row++;
                    }

                    ws.Columns(1, 8).AdjustToContents();
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeCareerHistory_{DateTime.Now:yyyyMMdd}.xlsx";

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
                            page.Header().AlignCenter().Text("Employee Career History List").SemiBold().FontSize(16);
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
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Position").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Company").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Start Date").Bold();
                                });
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeNo ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeName ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.PositionName ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.CompanyName ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.StartDate);
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeCareerHistory_{DateTime.Now:yyyyMMdd}.pdf";

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

