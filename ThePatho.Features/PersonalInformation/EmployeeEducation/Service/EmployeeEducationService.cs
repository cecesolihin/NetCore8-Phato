using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeEducation.Commands;
using ThePatho.Features.PersonalInformation.EmployeeEducation.DTO;
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

namespace ThePatho.Features.PersonalInformation.EmployeeEducation.Service
{
    public class EmployeeEducationService : IEmployeeEducationService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeeEducationService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeEducationItemDto>> GetEmployeeEducation(GetEmployeeEducationCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@EduLevel", request.FilterEduLevel ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeEducation/Sql/get_emp_education");
                var data = await db.QueryAsync<EmployeeEducationDto>(query, parameters);

                var result = new EmployeeEducationItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeEducationList = data.ToList()
                };

                return new ApiResponse<EmployeeEducationItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeEducationItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Education list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeEducationDto>> GetSingleEmployeeEducation(GetSingleEmployeeEducationCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeEducationId", request.EmployeeEducationId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeEducation/Sql/get_single_emp_education");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeEducationDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<EmployeeEducationDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeeEducationDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeEducationDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Education detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeEducationItemDto>> GetEmployeeEducationByCriteria(GetEmployeeEducationByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId ?? 0);
                parameters.Add("@EduLevelCode", request.MajorCode ?? string.Empty);
                parameters.Add("@Institution", request.Institution ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeEducation/Sql/get_criteria_emp_education");
                var data = await db.QueryAsync<EmployeeEducationDto>(query, parameters);

                var result = new EmployeeEducationItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeEducationList = data.ToList()
                };

                return new ApiResponse<EmployeeEducationItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeEducationItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Education data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeEducation(SubmitEmployeeEducationCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeEducationId", request.EmployeeEducationId);
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@EduLevelCode", request.EduLevelCode);
                parameters.Add("@Faculty", request.Faculty);
                parameters.Add("@MajorCode", request.MajorCode);
                parameters.Add("@OtherMajor", request.OtherMajor);
                parameters.Add("@StartYear", request.StartYear);
                parameters.Add("@EndYear", request.EndYear);
                parameters.Add("@Gpa", request.Gpa);
                parameters.Add("@MaxGpa", request.MaxGpa);
                parameters.Add("@Institution", request.Institution);
                parameters.Add("@Address", request.Address);
                parameters.Add("@CityCode", request.CityCode);
                parameters.Add("@GradTypeCode", request.GradTypeCode);
                parameters.Add("@CertificateNo", request.CertificateNo);
                parameters.Add("@CertificateDate", request.CertificateDate);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeEducation/Sql/submit_emp_education");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeEducation(DeleteEmployeeEducationCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeEducationId", request.EmployeeEducationId);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeEducation/Sql/get_single_emp_education");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeEducationDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<EmployeeEducationDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeEducation/Sql/delete_emp_education");
                await db.ExecuteAsync(query_delete, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message);
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportEmployeeEducationAsync(string type)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", 0);
                parameters.Add("@PageSize", 1000000);
                parameters.Add("@EmployeeId", 0);
                parameters.Add("@EduLevel", "");
                parameters.Add("@SortBy", "EmployeeId");
                parameters.Add("@OrderBy", "ASC");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeEducation/Sql/get_emp_education");
                var data = await db.QueryAsync<EmployeeEducationDto>(query, parameters);

                var fileName = string.Empty;
                byte[] fileBytes;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(type, "xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("EmployeeEducation");

                    ws.Cell("A1").Value = "Employee Education List";
                    ws.Range("A1:G1").Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    string[] headers = { "Employee No", "Full Name", "Edu Level", "Institution", "Faculty", "Major", "Grad Year" };
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
                        ws.Cell(row, 3).Value = item.EduLevelCode;
                        ws.Cell(row, 4).Value = item.Institution;
                        ws.Cell(row, 5).Value = item.Faculty;
                        ws.Cell(row, 6).Value = item.MajorCode;
                        ws.Cell(row, 7).Value = item.EndYear;
                        row++;
                    }

                    ws.Columns(1, 7).AdjustToContents();
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeEducation_{DateTime.Now:yyyyMMdd}.xlsx";

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
                            page.Header().AlignCenter().Text("Employee Education List").SemiBold().FontSize(16);
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(80);
                                    columns.RelativeColumn();
                                    columns.ConstantColumn(100);
                                    columns.RelativeColumn();
                                    columns.ConstantColumn(60);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("No").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Name").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Level").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Institution").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Year").Bold();
                                });
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeNo ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeName ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.EduLevelCode ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.Institution ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.EndYear ?? "-");
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeEducation_{DateTime.Now:yyyyMMdd}.pdf";

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

