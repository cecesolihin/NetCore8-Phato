using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Commands;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.DTO;
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

namespace ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Service
{
    public class EmployeeWorkingExperienceService : IEmployeeWorkingExperienceService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeeWorkingExperienceService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeWorkingExperienceItemDto>> GetEmployeeWorkingExperience(GetEmployeeWorkingExperienceCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeID", request.FilterEmployeeId ?? 0);
                parameters.Add("@WorkExperience", request.FilterWorkExperience ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeWorkingExperience/Sql/get_emp_working_experience");
                var data = await db.QueryAsync<EmployeeWorkingExperienceDto>(query, parameters);

                var result = new EmployeeWorkingExperienceItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeWorkingExperienceList = data.ToList()
                };

                return new ApiResponse<EmployeeWorkingExperienceItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeWorkingExperienceItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Working Experience list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeWorkingExperienceDto>> GetSingleEmployeeWorkingExperience(GetSingleEmployeeWorkingExperienceCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmpWorkExperienceId", request.EmpWorkExperienceId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeWorkingExperience/Sql/get_single_emp_working_experience");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeWorkingExperienceDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeWorkingExperienceDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeeWorkingExperienceDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeWorkingExperienceDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Working Experience detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeWorkingExperienceItemDto>> GetEmployeeWorkingExperienceByCriteria(GetEmployeeWorkingExperienceByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId ?? 0);
                parameters.Add("@Company", request.Company ?? string.Empty);
                parameters.Add("@EmploymentTypeCode", request.EmploymentTypeCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeWorkingExperience/Sql/get_criteria_emp_working_experience");
                var data = await db.QueryAsync<EmployeeWorkingExperienceDto>(query, parameters);

                var result = new EmployeeWorkingExperienceItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeWorkingExperienceList = data.ToList()
                };

                return new ApiResponse<EmployeeWorkingExperienceItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeWorkingExperienceItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Working Experience data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeWorkingExperience(SubmitEmployeeWorkingExperienceCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmpWorkExperienceId", request.EmpWorkExperienceId);
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@StartWorking", request.StartWorking);
                parameters.Add("@EndWorking", request.EndWorking);
                parameters.Add("@EmploymentTypeCode", request.EmploymentTypeCode);
                parameters.Add("@Organization", request.Organization);
                parameters.Add("@Company", request.Company);
                parameters.Add("@BusinessField", request.BusinessField);
                parameters.Add("@Address", request.Address);
                parameters.Add("@CityId", request.CityId);
                parameters.Add("@JobLevel", request.JobLevel);
                parameters.Add("@JobDescription", request.JobDescription);
                parameters.Add("@Phone", request.Phone);
                parameters.Add("@Website", request.Website);
                parameters.Add("@ReferenceName", request.ReferenceName);
                parameters.Add("@ReferencePhone", request.ReferencePhone);
                parameters.Add("@ReferenceEmail", request.ReferenceEmail);
                parameters.Add("@CurrencyCode21", request.CurrencyCode21);
                parameters.Add("@CurrencyCode15", request.CurrencyCode15);
                parameters.Add("@PphA21", request.PphA21);
                parameters.Add("@PphA15", request.PphA15);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeWorkingExperience/Sql/submit_emp_working_experience");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeWorkingExperience(DeleteEmployeeWorkingExperienceCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmpWorkExperienceId", request.EmpWorkExperienceId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeWorkingExperience/Sql/get_single_emp_working_experience");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeWorkingExperienceDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeWorkingExperienceDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeWorkingExperience/Sql/delete_emp_working_experience");
                await db.ExecuteAsync(query_delete, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message);
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportEmployeeWorkingExperienceAsync(string type)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", 0);
                parameters.Add("@PageSize", 1000000);
                parameters.Add("@EmployeeID", 0);
                parameters.Add("@WorkExperience", "");
                parameters.Add("@SortBy", "EmployeeId");
                parameters.Add("@OrderBy", "ASC");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeWorkingExperience/Sql/get_emp_working_experience");
                var data = await db.QueryAsync<EmployeeWorkingExperienceDto>(query, parameters);

                var fileName = string.Empty;
                byte[] fileBytes;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(type, "xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("WorkingExperience");

                    ws.Cell("A1").Value = "Employee Working Experience List";
                    ws.Range("A1:G1").Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    string[] headers = { "Employee No", "Full Name", "Company", "Organization", "Job Level", "Start", "End" };
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
                        ws.Cell(row, 3).Value = item.Company;
                        ws.Cell(row, 4).Value = item.Organization;
                        ws.Cell(row, 5).Value = item.JobLevel;
                        ws.Cell(row, 6).Value = item.StartWorking;
                        ws.Cell(row, 7).Value = item.EndWorking;
                        row++;
                    }

                    ws.Columns(1, 7).AdjustToContents();
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"WorkingExperience_{DateTime.Now:yyyyMMdd}.xlsx";

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
                            page.Header().AlignCenter().Text("Employee Working Experience List").SemiBold().FontSize(16);
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
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Name").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Company").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Job Level").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Period").Bold();
                                });
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeNo ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeName ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.Company ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.JobLevel ?? "-");
                                    table.Cell().Border(1).Padding(5).Text($"{item.StartWorking} - {item.EndWorking}");
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"WorkingExperience_{DateTime.Now:yyyyMMdd}.pdf";

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

