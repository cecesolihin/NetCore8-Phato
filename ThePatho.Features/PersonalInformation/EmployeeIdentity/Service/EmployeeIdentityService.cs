using Dapper;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Net;
using System.IO;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.Commands;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.UserContext;
using ThePatho.Provider.ApiResponse;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ThePatho.Features.Common.DTO;
using ThePatho.Domain.Constants;
using System.IO;

namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.Service
{
    public class EmployeeIdentityService : IEmployeeIdentityService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly IHostEnvironment env;
        private readonly IConfiguration configuration;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeeIdentityService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, IHostEnvironment _env, IConfiguration _configuration, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            env = _env;
            configuration = _configuration;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeIdentityItemDto>> GetEmployeeIdentity(GetEmployeeIdentityCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@Identity", request.FilterIdentity ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeIdentity/Sql/get_emp_identity");
                var data = await db.QueryAsync<EmployeeIdentityDto>(query, parameters);

                var result = new EmployeeIdentityItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeIdentityList = data.ToList()
                };

                return new ApiResponse<EmployeeIdentityItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeIdentityItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Identity list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeIdentityDto>> GetSingleEmployeeIdentity(GetSingleEmployeeIdentityCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@IdentityCode", request.IdentityCode);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeIdentity/Sql/get_single_emp_identity");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeIdentityDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeIdentityDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeeIdentityDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeIdentityDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Identity detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeIdentityItemDto>> GetEmployeeIdentityByCriteria(GetEmployeeIdentityByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId ?? 0);
                parameters.Add("@IdentityNo", request.IdentityNo ?? string.Empty);
                parameters.Add("@IdentityCode", request.IdentityCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeIdentity/Sql/get_criteria_emp_identity");
                var data = await db.QueryAsync<EmployeeIdentityDto>(query, parameters);

                var result = new EmployeeIdentityItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeIdentityList = data.ToList()
                };

                return new ApiResponse<EmployeeIdentityItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeIdentityItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Identity data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeIdentity(SubmitEmployeeIdentityCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();

                // Get EmployeeNo from EmployeeId
                var employeeQuery = "SELECT EmployeeNo FROM TEPMEmployee WHERE EmployeeID = @EmployeeId";
                var employeeNo = await db.QuerySingleOrDefaultAsync<string>(employeeQuery, new { request.EmployeeId });

                if (string.IsNullOrEmpty(employeeNo))
                {
                    return new ApiResponse(HttpStatusCode.NotFound, "Employee not found.");
                }

                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@IdentityCode", request.IdentityCode);
                parameters.Add("@CompanyCode", request.CompanyCode);
                parameters.Add("@IdentityNo", request.IdentityNo);
                parameters.Add("@IssuedDate", request.IssuedDate);
                parameters.Add("@ExpiredDate", request.ExpiredDate);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                if (!string.IsNullOrEmpty(request.FileUpload))
                {
                    var fileBytes = Convert.FromBase64String(request.FileUpload);
                    var fileExtension = Path.GetExtension(request.FileName);
                    var configuredRoot = configuration["DocumentRootPath"];
                    var baseRoot = string.IsNullOrWhiteSpace(configuredRoot) ? env.ContentRootPath : configuredRoot;

                    var directoryPath = Path.Combine(baseRoot, "Document", "EmployeeIdentity", employeeNo, request.IdentityCode);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    var fileName = $"{employeeNo}_{request.IdentityCode}{fileExtension}";
                    var filePath = Path.Combine(directoryPath, fileName);
                    await File.WriteAllBytesAsync(filePath, fileBytes);

                    var fileFullPath = $"~\\Document\\EmployeeIdentity\\{employeeNo}\\{request.IdentityCode}\\{fileName}";

                    parameters.Add("@FileFullPath", fileFullPath);
                    parameters.Add("@FileName", fileName);
                    parameters.Add("@FileUpload", null);
                }
                else
                {
                    parameters.Add("@FileFullPath", null);
                    parameters.Add("@FileName", null);
                    parameters.Add("@FileUpload", null);
                }


                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeIdentity/Sql/submit_emp_identity");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeIdentity(DeleteEmployeeIdentityCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@IdentityCode", request.IdentityCode);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeIdentity/Sql/get_single_emp_identity");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeIdentityDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeIdentityDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeIdentity/Sql/delete_emp_identity");
                await db.ExecuteAsync(query_delete, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message);
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportEmployeeIdentityAsync(string type)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", 0);
                parameters.Add("@PageSize", 1000000);
                parameters.Add("@EmployeeId", 0);
                parameters.Add("@Identity", "");
                parameters.Add("@SortBy", "EmployeeId");
                parameters.Add("@OrderBy", "ASC");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeIdentity/Sql/get_emp_identity");
                var data = await db.QueryAsync<EmployeeIdentityDto>(query, parameters);

                var fileName = string.Empty;
                byte[] fileBytes;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(type, "xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("EmployeeIdentity");

                    ws.Cell("A1").Value = "Employee Identity List";
                    ws.Range("A1:G1").Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    string[] headers = { "Employee No", "Full Name", "Identity Type", "Identity No", "Issued Date", "Expired Date", "Remarks" };
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
                        ws.Cell(row, 3).Value = item.IdentityCode;
                        ws.Cell(row, 4).Value = item.IdentityNo;
                        ws.Cell(row, 5).Value = item.IssuedDate;
                        ws.Cell(row, 6).Value = item.ExpiredDate;
                        ws.Cell(row, 7).Value = item.Remarks;
                        row++;
                    }

                    ws.Columns(1, 7).AdjustToContents();
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeIdentity_{DateTime.Now:yyyyMMdd}.xlsx";

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
                            page.Header().AlignCenter().Text("Employee Identity List").SemiBold().FontSize(16);
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
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Identity Type").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Identity No").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Expired Date").Bold();
                                });
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeNo ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeName ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.IdentityCode ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.IdentityNo ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.ExpiredDate ?? "-");
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeIdentity_{DateTime.Now:yyyyMMdd}.pdf";

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

