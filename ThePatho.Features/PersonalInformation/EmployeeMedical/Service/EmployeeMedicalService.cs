using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeMedical.Commands;
using ThePatho.Features.PersonalInformation.EmployeeMedical.DTO;
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

namespace ThePatho.Features.PersonalInformation.EmployeeMedical.Service
{
    public class EmployeeMedicalService : IEmployeeMedicalService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeeMedicalService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeMedicalItemDto>> GetEmployeeMedical(GetEmployeeMedicalCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@Medical", request.FilterMedical ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeMedical/Sql/get_emp_medical");
                var data = await db.QueryAsync<EmployeeMedicalDto>(query, parameters);

                var result = new EmployeeMedicalItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeMedicalList = data.ToList()
                };

                return new ApiResponse<EmployeeMedicalItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeMedicalItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Medical list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeMedicalDto>> GetSingleEmployeeMedical(GetSingleEmployeeMedicalCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@DiseaseCategoryCode", request.DiseaseCategoryCode);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeMedical/Sql/get_single_emp_medical");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeMedicalDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeMedicalDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeeMedicalDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeMedicalDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Medical detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeMedicalItemDto>> GetEmployeeMedicalByCriteria(GetEmployeeMedicalByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId ?? 0);
                parameters.Add("@DiseaseName", request.DiseaseName ?? string.Empty);
                parameters.Add("@Hospital", request.Hospital ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeMedical/Sql/get_criteria_emp_medical");
                var data = await db.QueryAsync<EmployeeMedicalDto>(query, parameters);

                var result = new EmployeeMedicalItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeMedicalList = data.ToList()
                };

                return new ApiResponse<EmployeeMedicalItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeMedicalItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Medical data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeMedical(SubmitEmployeeMedicalCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@DiseaseCategoryCode", request.DiseaseCategoryCode);
                parameters.Add("@DiseaseName", request.DiseaseName);
                parameters.Add("@StartDate", request.StartDate);
                parameters.Add("@EndDate", request.EndDate);
                parameters.Add("@Therapy", request.Therapy);
                parameters.Add("@Hospital", request.Hospital);
                parameters.Add("@CountryId", request.CountryId);
                parameters.Add("@ProvinceId", request.ProvinceId);
                parameters.Add("@CityCode", request.CityCode);
                parameters.Add("@Doctor", request.Doctor);
                parameters.Add("@Phone", request.Phone);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@IsDeleted", request.IsDeleted);
                parameters.Add("@InsertedBy", request.InsertedBy);
                parameters.Add("@InsertedDate", request.InsertedDate);
                parameters.Add("@ModifiedBy", request.ModifiedBy);
                parameters.Add("@ModifiedDate", request.ModifiedDate);
                parameters.Add("@TimeIn", request.TimeIn);
                parameters.Add("@TimeOut", request.TimeOut);
                parameters.Add("@Obat", request.Obat);
                parameters.Add("@TindakanPertama", request.TindakanPertama);
                parameters.Add("@TindakanKedua", request.TindakanKedua);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeMedical/Sql/submit_emp_medical");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeMedical(DeleteEmployeeMedicalCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@DiseaseCategoryCode", request.DiseaseCategoryCode);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeMedical/Sql/get_single_emp_medical");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeMedicalDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeMedicalDto>(HttpStatusCode.NotFound, "data not found");
                }
                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeMedical/Sql/delete_emp_medical");
                await db.ExecuteAsync(query_delete, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message);
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportEmployeeMedicalAsync(string type)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", 0);
                parameters.Add("@PageSize", 1000000);
                parameters.Add("@EmployeeId", 0);
                parameters.Add("@Medical", "");
                parameters.Add("@SortBy", "EmployeeId");
                parameters.Add("@OrderBy", "ASC");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeMedical/Sql/get_emp_medical");
                var data = await db.QueryAsync<EmployeeMedicalDto>(query, parameters);

                var fileName = string.Empty;
                byte[] fileBytes;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(type, "xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("EmployeeMedical");

                    ws.Cell("A1").Value = "Employee Medical List";
                    ws.Range("A1:G1").Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    string[] headers = { "Employee No", "Full Name", "Disease Name", "Hospital", "Doctor", "Start Date", "End Date" };
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
                        ws.Cell(row, 3).Value = item.DiseaseName;
                        ws.Cell(row, 4).Value = item.Hospital;
                        ws.Cell(row, 5).Value = item.Doctor;
                        ws.Cell(row, 6).Value = item.StartDate;
                        ws.Cell(row, 7).Value = item.EndDate;
                        row++;
                    }

                    ws.Columns(1, 7).AdjustToContents();
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeMedical_{DateTime.Now:yyyyMMdd}.xlsx";

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
                            page.Header().AlignCenter().Text("Employee Medical List").SemiBold().FontSize(16);
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
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Disease Name").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Hospital").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("End Date").Bold();
                                });
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeNo ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeName ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.DiseaseName ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.Hospital ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.EndDate);
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeMedical_{DateTime.Now:yyyyMMdd}.pdf";

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

