using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeTraining.Commands;
using ThePatho.Features.PersonalInformation.EmployeeTraining.DTO;
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

namespace ThePatho.Features.PersonalInformation.EmployeeTraining.Service
{
    public class EmployeeTrainingService : IEmployeeTrainingService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeeTrainingService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeTrainingItemDto>> GetEmployeeTraining(GetEmployeeTrainingCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@Training", request.FilterTraining ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeTraining/Sql/get_emp_training");
                var data = await db.QueryAsync<EmployeeTrainingDto>(query, parameters);

                var result = new EmployeeTrainingItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeTrainingList = data.ToList()
                };

                return new ApiResponse<EmployeeTrainingItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeTrainingItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Training list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeTrainingDto>> GetSingleEmployeeTraining(GetSingleEmployeeTrainingCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmpTrainingId", request.EmpTrainingId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeTraining/Sql/get_single_emp_training");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeTrainingDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeTrainingDto>(HttpStatusCode.NotFound, "data not found");
                }

                return new ApiResponse<EmployeeTrainingDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeTrainingDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Training detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeTrainingItemDto>> GetEmployeeTrainingByCriteria(GetEmployeeTrainingByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@TrainingCourseCode", request.TrainingCourseCode ?? string.Empty);
                parameters.Add("@TrainingTypeCode", request.TrainingTypeCode ?? string.Empty);
                parameters.Add("@TrainingFieldCode", request.TrainingFieldCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeTraining/Sql/get_criteria_emp_training");
                var data = await db.QueryAsync<EmployeeTrainingDto>(query, parameters);

                var result = new EmployeeTrainingItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeTrainingList = data.ToList()
                };

                return new ApiResponse<EmployeeTrainingItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeTrainingItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Training data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeTraining(SubmitEmployeeTrainingCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmpTrainingId", request.EmpTrainingId);
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@TrainingCourseCode", request.TrainingCourseCode);
                parameters.Add("@StartDate", request.StartDate);
                parameters.Add("@TrainingTypeCode", request.TrainingTypeCode);
                parameters.Add("@TrainingFieldCode", request.TrainingFieldCode);
                parameters.Add("@Institution", request.Institution);
                parameters.Add("@Address", request.Address);
                parameters.Add("@CityCode", request.CityCode);
                parameters.Add("@CertificateNo", request.CertificateNo);
                parameters.Add("@CertificateDate", request.CertificateDate);
                parameters.Add("@EndDate", request.EndDate);
                parameters.Add("@TrainingPayerCode", request.TrainingPayerCode);
                parameters.Add("@CompanyBondDate", request.CompanyBondDate);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@TrainingBatchCode", request.TrainingBatchCode);
                parameters.Add("@IsDeleted", request.IsDeleted);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeTraining/Sql/submit_emp_training");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeTraining(DeleteEmployeeTrainingCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmpTrainingId", request.EmpTrainingId);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeTraining/Sql/get_single_emp_training");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeTrainingDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeTrainingDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeTraining/Sql/delete_emp_training");
                await db.ExecuteAsync(query_delete, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message);
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportEmployeeTrainingAsync(string type)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", 0);
                parameters.Add("@PageSize", 1000000);
                parameters.Add("@EmployeeId", 0);
                parameters.Add("@Training", "");
                parameters.Add("@SortBy", "EmployeeId");
                parameters.Add("@OrderBy", "ASC");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeTraining/Sql/get_emp_training");
                var data = await db.QueryAsync<EmployeeTrainingDto>(query, parameters);

                var fileName = string.Empty;
                byte[] fileBytes;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(type, "xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("EmployeeTraining");

                    ws.Cell("A1").Value = "Employee Training List";
                    ws.Range("A1:G1").Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    string[] headers = { "Employee No", "Full Name", "Course", "Institution", "Start Date", "End Date", "Certificate No" };
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
                        ws.Cell(row, 3).Value = item.TrainingCourseCode;
                        ws.Cell(row, 4).Value = item.Institution;
                        ws.Cell(row, 5).Value = item.StartDate;
                        ws.Cell(row, 6).Value = item.EndDate;
                        ws.Cell(row, 7).Value = item.CertificateNo;
                        row++;
                    }

                    ws.Columns(1, 7).AdjustToContents();
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeTraining_{DateTime.Now:yyyyMMdd}.xlsx";

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
                            page.Header().AlignCenter().Text("Employee Training List").SemiBold().FontSize(16);
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
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Course").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Institution").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("End Date").Bold();
                                });
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeNo ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeName ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.TrainingCourseCode ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.Institution ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.EndDate);
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeTraining_{DateTime.Now:yyyyMMdd}.pdf";

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

