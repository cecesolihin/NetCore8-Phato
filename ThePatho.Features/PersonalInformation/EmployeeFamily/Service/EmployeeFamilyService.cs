using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeFamily.Commands;
using ThePatho.Features.PersonalInformation.EmployeeFamily.DTO;
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

namespace ThePatho.Features.PersonalInformation.EmployeeFamily.Service
{
    public class EmployeeFamilyService : IEmployeeFamilyService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeeFamilyService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeFamilyItemDto>> GetEmployeeFamily(GetEmployeeFamilyCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@Family", request.FilterFamily ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeFamily/Sql/get_emp_family");
                var data = await db.QueryAsync<EmployeeFamilyDto>(query, parameters);

                var result = new EmployeeFamilyItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeFamilyList = data.ToList()
                };

                return new ApiResponse<EmployeeFamilyItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeFamilyItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Family list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeFamilyDto>> GetSingleEmployeeFamily(GetSingleEmployeeFamilyCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeFamilyId", request.EmployeeFamilyId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeFamily/Sql/get_single_emp_family");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeFamilyDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<EmployeeFamilyDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeeFamilyDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeFamilyDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Family detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeFamilyItemDto>> GetEmployeeFamilyByCriteria(GetEmployeeFamilyByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId ?? 0);
                parameters.Add("@RelationCode", request.RelationCode ?? string.Empty);
                parameters.Add("@FamilyName", request.FamilyName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeFamily/Sql/get_criteria_emp_family");
                var data = await db.QueryAsync<EmployeeFamilyDto>(query, parameters);

                var result = new EmployeeFamilyItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeFamilyList = data.ToList()
                };

                return new ApiResponse<EmployeeFamilyItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeFamilyItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Family data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeFamily(SubmitEmployeeFamilyCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeFamilyId", request.EmployeeFamilyId);
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@RelationCode", request.RelationCode);
                parameters.Add("@FamilyName", request.FamilyName);
                parameters.Add("@Gender", request.Gender);
                parameters.Add("@BirthPlace", request.BirthPlace);
                parameters.Add("@BirthDate", request.BirthDate);
                parameters.Add("@Address", request.Address);
                parameters.Add("@Phone", request.Phone);
                parameters.Add("@BloodTypeCode", request.BloodTypeCode);
                parameters.Add("@EduLevelCode", request.EduLevelCode);
                parameters.Add("@MaritalStatusCode", request.MaritalStatusCode);
                parameters.Add("@DependentStatus", request.DependentStatus);
                parameters.Add("@EmergencyContact", request.EmergencyContact);
                parameters.Add("@WorkingStatus", request.WorkingStatus);
                parameters.Add("@VitalStatus", request.VitalStatus);
                parameters.Add("@Company", request.Company);
                parameters.Add("@Position", request.Position);
                parameters.Add("@KkNo", request.KkNo);
                parameters.Add("@IdentityNo", request.IdentityNo);
                parameters.Add("@BpjsNo", request.BpjsNo);
                parameters.Add("@InsuranceName", request.InsuranceName);
                parameters.Add("@PolisNo", request.PolisNo);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeFamily/Sql/submit_emp_family");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeFamily(DeleteEmployeeFamilyCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeFamilyId", request.EmployeeFamilyId);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeFamily/Sql/get_single_emp_family");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeFamilyDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<EmployeeFamilyDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeFamily/Sql/delete_emp_family");
                await db.ExecuteAsync(query_delete, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message);
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportEmployeeFamilyAsync(string type)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", 0);
                parameters.Add("@PageSize", 1000000);
                parameters.Add("@EmployeeId", 0);
                parameters.Add("@Family", "");
                parameters.Add("@SortBy", "EmployeeId");
                parameters.Add("@OrderBy", "ASC");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeFamily/Sql/get_emp_family");
                var data = await db.QueryAsync<EmployeeFamilyDto>(query, parameters);

                var fileName = string.Empty;
                byte[] fileBytes;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(type, "xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("EmployeeFamily");

                    ws.Cell("A1").Value = "Employee Family List";
                    ws.Range("A1:G1").Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    string[] headers = { "Employee No", "Full Name", "Family Name", "Relation", "Gender", "Birth Place", "Birth Date" };
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
                        ws.Cell(row, 3).Value = item.FamilyName;
                        ws.Cell(row, 4).Value = item.RelationCode;
                        ws.Cell(row, 5).Value = item.Gender;
                        ws.Cell(row, 6).Value = item.BirthPlace;
                        ws.Cell(row, 7).Value = item.BirthDate;
                        row++;
                    }

                    ws.Columns(1, 7).AdjustToContents();
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeFamily_{DateTime.Now:yyyyMMdd}.xlsx";

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
                            page.Header().AlignCenter().Text("Employee Family List").SemiBold().FontSize(16);
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
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Family Name").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Relation").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Birth Date").Bold();
                                });
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeNo ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeName ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.FamilyName ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.RelationCode ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.BirthDate);
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeFamily_{DateTime.Now:yyyyMMdd}.pdf";

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

