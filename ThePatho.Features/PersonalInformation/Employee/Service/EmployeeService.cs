using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.Employee.Commands;
using ThePatho.Features.PersonalInformation.Employee.DTO;
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

namespace ThePatho.Features.PersonalInformation.Employee.Service
{
    public class EmployeeService : IEmployeeService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeeService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeItemDto>> GetEmployee(GetEmployeeCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeNo", request.FilterEmployeeNo ?? string.Empty);
                parameters.Add("@Fullname", request.FilterFullname ?? string.Empty);
                parameters.Add("@EmploymentType", request.FilterEmploymentType ?? string.Empty);
                parameters.Add("@JobClass", request.FilterJobClass ?? string.Empty);
                parameters.Add("@Position", request.FilterPosition ?? string.Empty);
                parameters.Add("@WorkLocation", request.FilterWorkLocation ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/Employee/Sql/get_employee");
                var data = await db.QueryAsync<EmployeeDto>(query, parameters);

                var result = new EmployeeItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeList = data.ToList()
                };

                return new ApiResponse<EmployeeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeDto>> GetSingleEmployee(GetSingleEmployeeCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/Employee/Sql/get_single_employee");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeDto>(query, parameters);

                return new ApiResponse<EmployeeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeDto>(HttpStatusCode.BadRequest, "Error retrieving Employee detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeItemDto>> GetEmployeeByCriteria(GetEmployeeByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeNo", request.EmployeeNo ?? string.Empty);
                parameters.Add("@Fullname", request.Fullname ?? string.Empty);
                parameters.Add("@EmploymentType", request.EmploymentType ?? string.Empty);
                parameters.Add("@JobClass", request.JobClass ?? string.Empty);
                parameters.Add("@Position", request.Position ?? string.Empty);
                parameters.Add("@WorkLocation", request.WorkLocation ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/Employee/Sql/get_criteria_employee");
                var data = await db.QueryAsync<EmployeeDto>(query, parameters);

                var result = new EmployeeItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeList = data.ToList()
                };

                return new ApiResponse<EmployeeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployee(SubmitEmployeeCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@EmployeeNo", request.EmployeeNo);
                parameters.Add("@CompanyCode", request.CompanyCode);

                parameters.Add("@Firstname", request.Firstname);
                parameters.Add("@MiddleName", request.MiddleName);
                parameters.Add("@LastName", request.LastName);
                parameters.Add("@Fullname", request.Fullname);
                parameters.Add("@Gender", request.Gender);
                parameters.Add("@BirthPlace", request.BirthPlace);
                parameters.Add("@BirthDate", request.BirthDate);

                parameters.Add("@JoinDate", request.JoinDate);
                parameters.Add("@TerminateDate", request.TerminateDate);
                parameters.Add("@PermanentDate", request.PermanentDate);
                parameters.Add("@PensionDate", request.PensionDate);
                parameters.Add("@ContractEndDate", request.ContractEndDate);

                parameters.Add("@PositionCode", request.PositionCode);
                parameters.Add("@JobClassCode", request.JobClassCode);
                parameters.Add("@EmploymentTypeCode", request.EmploymentTypeCode);
                parameters.Add("@CostCenterCode", request.CostCenterCode);
                parameters.Add("@WorkLocationCode", request.WorkLocationCode);
                parameters.Add("@JabatanId", request.JabatanId);
                parameters.Add("@IsEligibleRehire", request.IsEligibleRehire);

                parameters.Add("@TaxType", request.TaxType);
                parameters.Add("@TaxStatusCode", request.TaxStatusCode);
                parameters.Add("@NPWP", request.Npwp);
                parameters.Add("@TaxLocationId", request.TaxLocationId);
                parameters.Add("@NeedReplacement", request.NeedReplacement);
                parameters.Add("@PayGroup", request.PayGroup);
             
                parameters.Add("@NationalityId", request.NationalityId);
                parameters.Add("@ReligionId", request.ReligionId);
                parameters.Add("@MaritalStatus", request.MaritalStatus);
                parameters.Add("@MarriedDate", request.MarriedDate);
                parameters.Add("@BPJSTK", request.BPJSTK);
                parameters.Add("@BPJSKES", request.BPJSKES);
                parameters.Add("@NickName", request.NickName);
                parameters.Add("@Phone", request.Phone);
                parameters.Add("@MobilePhone", request.MobilePhone);
                parameters.Add("@Email", request.Email);
                parameters.Add("@BloodType", request.BloodType);
                parameters.Add("@Height", request.Height);
                parameters.Add("@Weight", request.Weight);

                parameters.Add("@OfficePhone", request.OfficePhone);
                parameters.Add("@OfficeEmail", request.OfficeEmail);
                parameters.Add("@BuildingCode", request.BuildingCode);
                parameters.Add("@RoomCode", request.RoomCode);
                parameters.Add("@ComputerName", request.ComputerName);
                parameters.Add("@StaticIPAddress", request.StaticIPAddress);

                parameters.Add("@Glasses", request.Glasses);
                parameters.Add("@LeftEye", request.LeftEye);
                parameters.Add("@RightEye", request.RightEye);
                parameters.Add("@Hat", request.Hat);
                parameters.Add("@Helmet", request.Helmet);
                parameters.Add("@Clothes", request.Clothes);
                parameters.Add("@Jacket", request.Jacket);
                parameters.Add("@Pants", request.Pants);
                parameters.Add("@Shoes", request.Shoes);
                parameters.Add("@Boots", request.Boots);

                parameters.Add("@PhotoPath", request.PhotoPath);
                parameters.Add("@RFID", request.RFID);
                parameters.Add("@Recruiter", request.Recruiter);
                parameters.Add("@HireOrigin", request.HireOrigin);
                parameters.Add("@BPJSTKLocation", request.BPJSTKLocation);
                parameters.Add("@BPJSKesLocation", request.BPJSKesLocation);
                parameters.Add("@CapColorId", request.CapColorId);
                parameters.Add("@PickUpId", request.PickUpId);
                parameters.Add("@FaskesId", request.FaskesId);

                parameters.Add("@Action", request.Action);
                var userName = currentUserService.GetUserName();
                parameters.Add("@User", string.IsNullOrWhiteSpace(userName) ? "admin" : userName);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/Employee/Sql/submit_employee");
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

        public async Task<ApiResponse> DeleteEmployee(DeleteEmployeeCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                var userName = currentUserService.GetUserName();
                parameters.Add("@User", string.IsNullOrWhiteSpace(userName) ? "admin" : userName);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/Employee/Sql/delete_employee");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message);
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportEmployeeAsync(string type)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                // We use empty filters to get all (non-deleted) employees for export, or we could pass filters from a command if needed.
                // For simplicity and matching EmploymentType, we'll export all.
                parameters.Add("@PageNumber", 0);
                parameters.Add("@PageSize", 1000000); 
                parameters.Add("@EmployeeNo", "");
                parameters.Add("@Fullname", "");
                parameters.Add("@EmploymentType", "");
                parameters.Add("@JobClass", "");
                parameters.Add("@Position", "");
                parameters.Add("@WorkLocation", "");
                parameters.Add("@SortBy", "EmployeeNo");
                parameters.Add("@OrderBy", "ASC");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/Employee/Sql/get_employee");
                var data = await db.QueryAsync<EmployeeDto>(query, parameters);

                var fileName = string.Empty;
                byte[] fileBytes;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(type, "xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("Employee");

                    // Judul
                    ws.Cell("A1").Value = "Employee List";
                    ws.Range("A1:G1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // Header
                    string[] headers = { "Employee No", "Full Name", "Company", "Position", "Job Class", "Employment Type", "Work Location" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        var cell = ws.Cell(3, i + 1);
                        cell.Value = headers[i];
                        cell.Style.Font.SetBold()
                            .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                            .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                            .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));
                    }

                    // Data
                    var row = 4;
                    foreach (var item in data)
                    {
                        ws.Cell(row, 1).Value = item.EmployeeNo;
                        ws.Cell(row, 2).Value = item.Fullname;
                        ws.Cell(row, 3).Value = item.CompanyName;
                        ws.Cell(row, 4).Value = item.PositionName;
                        ws.Cell(row, 5).Value = item.JobClassName;
                        ws.Cell(row, 6).Value = item.EmploymentTypeName;
                        ws.Cell(row, 7).Value = item.WorkLocationName;
                        row++;
                    }

                    ws.Columns(1, 7).AdjustToContents();
                    var tableRange = ws.Range(3, 1, row - 1, 7);
                    tableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    tableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeList_{DateTime.Now:yyyyMMdd}.xlsx";

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
                            page.Header().AlignCenter().Text("Employee List").SemiBold().FontSize(16);

                            page.Content().PaddingTop(10).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(80);  // No
                                    columns.RelativeColumn();    // Name
                                    columns.RelativeColumn();    // Position
                                    columns.RelativeColumn();    // Dept/Org
                                    columns.ConstantColumn(100); // Type
                                });

                                table.Header(header =>
                                {
                                    string[] pdfHeaders = { "Employee No", "Full Name", "Position", "Work Location", "Type" };
                                    foreach (var h in pdfHeaders)
                                    {
                                        header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2)
                                            .AlignCenter().Text(h).Bold().FontSize(10);
                                    }
                                });

                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeNo ?? "-").FontSize(9);
                                    table.Cell().Border(1).Padding(5).Text(item.Fullname ?? "-").FontSize(9);
                                    table.Cell().Border(1).Padding(5).Text(item.PositionName ?? "-").FontSize(9);
                                    table.Cell().Border(1).Padding(5).Text(item.WorkLocationName ?? "-").FontSize(9);
                                    table.Cell().Border(1).Padding(5).Text(item.EmploymentTypeName ?? "-").FontSize(9);
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeList_{DateTime.Now:yyyyMMdd}.pdf";

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

