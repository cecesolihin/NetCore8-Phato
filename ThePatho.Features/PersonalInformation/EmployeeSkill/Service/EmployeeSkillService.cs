using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeSkill.Commands;
using ThePatho.Features.PersonalInformation.EmployeeSkill.DTO;
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

namespace ThePatho.Features.PersonalInformation.EmployeeSkill.Service
{
    public class EmployeeSkillService : IEmployeeSkillService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeeSkillService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeSkillItemDto>> GetEmployeeSkill(GetEmployeeSkillCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@Skill", request.FilterSkill ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeSkill/Sql/get_emp_skill");
                var data = await db.QueryAsync<EmployeeSkillDto>(query, parameters);

                var result = new EmployeeSkillItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeSkillList = data.ToList()
                };

                return new ApiResponse<EmployeeSkillItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeSkillItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Skill list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeSkillDto>> GetSingleEmployeeSkill(GetSingleEmployeeSkillCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@SkillCode", request.SkillCode);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeSkill/Sql/get_single_emp_skill");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeSkillDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeSkillDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeeSkillDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeSkillDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Skill detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeSkillItemDto>> GetEmployeeSkillByCriteria(GetEmployeeSkillByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@SkillCode", request.SkillCode ?? string.Empty);
                parameters.Add("@ProfiencyCode", request.ProfiencyCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeSkill/Sql/get_criteria_emp_skill");
                var data = await db.QueryAsync<EmployeeSkillDto>(query, parameters);

                var result = new EmployeeSkillItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeSkillList = data.ToList()
                };

                return new ApiResponse<EmployeeSkillItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeSkillItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Skill data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeSkill(SubmitEmployeeSkillCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@SkillCode", request.SkillCode);
                parameters.Add("@ProfiencyCode", request.ProfiencyCode);
                parameters.Add("@Description", request.Description);
                parameters.Add("@TakenDate", request.TakenDate);
                parameters.Add("@ExpiredDate", request.ExpiredDate);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@IsDeleted", request.IsDeleted);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeSkill/Sql/submit_emp_skill");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeSkill(DeleteEmployeeSkillCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@SkillCode", request.SkillCode);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeSkill/Sql/get_single_emp_skill");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeSkillDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeSkillDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeSkill/Sql/delete_emp_skill");
                await db.ExecuteAsync(query_delete, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message);
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportEmployeeSkillAsync(string type)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", 0);
                parameters.Add("@PageSize", 1000000);
                parameters.Add("@EmployeeId", 0);
                parameters.Add("@Skill", "");
                parameters.Add("@SortBy", "EmployeeId");
                parameters.Add("@OrderBy", "ASC");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeSkill/Sql/get_emp_skill");
                var data = await db.QueryAsync<EmployeeSkillDto>(query, parameters);

                var fileName = string.Empty;
                byte[] fileBytes;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(type, "xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("EmployeeSkill");

                    ws.Cell("A1").Value = "Employee Skill List";
                    ws.Range("A1:G1").Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    string[] headers = { "Employee No", "Full Name", "Skill Name", "Proficiency", "Description", "Taken Date", "Expired Date" };
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
                        ws.Cell(row, 3).Value = item.SkillCode;
                        ws.Cell(row, 4).Value = item.ProfiencyCode;
                        ws.Cell(row, 5).Value = item.Description;
                        ws.Cell(row, 6).Value = item.TakenDate;
                        ws.Cell(row, 7).Value = item.ExpiredDate;
                        row++;
                    }

                    ws.Columns(1, 7).AdjustToContents();
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeSkill_{DateTime.Now:yyyyMMdd}.xlsx";

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
                            page.Header().AlignCenter().Text("Employee Skill List").SemiBold().FontSize(16);
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
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Skill").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Proficiency").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Taken Date").Bold();
                                });
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeNo ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeName ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.SkillCode ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.ProfiencyCode ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.TakenDate);
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeSkill_{DateTime.Now:yyyyMMdd}.pdf";

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

