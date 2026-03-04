using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeePunishment.Commands;
using ThePatho.Features.PersonalInformation.EmployeePunishment.DTO;
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

namespace ThePatho.Features.PersonalInformation.EmployeePunishment.Service
{
    public class EmployeePunishmentService : IEmployeePunishmentService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeePunishmentService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeePunishmentItemDto>> GetEmployeePunishment(GetEmployeePunishmentCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId);
                parameters.Add("@Punishment", request.FilterPunishment ?? string.Empty);
                parameters.Add("@LetterDateFrom", request.FilterLetterDateFrom);
                parameters.Add("@LetterDateTo", request.FilterLetterDateTo);
                parameters.Add("@ValidFrom", request.FilterValidFrom);
                parameters.Add("@ValidTo", request.FilterValidTo);
                parameters.Add("@RecoveryDateFrom", request.FilterRecoveryDateFrom);
                parameters.Add("@RecoveryDateTo", request.FilterRecoveryDateTo);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePunishment/Sql/get_emp_punishment");
                var data = await db.QueryAsync<EmployeePunishmentDto>(query, parameters);

                var result = new EmployeePunishmentItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeePunishmentList = data.ToList()
                };

                return new ApiResponse<EmployeePunishmentItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeePunishmentItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Punishment list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeePunishmentDto>> GetSingleEmployeePunishment(GetSingleEmployeePunishmentCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmPunishmentId", request.EmPunishmentId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePunishment/Sql/get_single_emp_punishment");
                var data = await db.QueryFirstOrDefaultAsync<EmployeePunishmentDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<EmployeePunishmentDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeePunishmentDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeePunishmentDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Punishment detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeePunishmentItemDto>> GetEmployeePunishmentByCriteria(GetEmployeePunishmentByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@LetterNo", request.LetterNo ?? string.Empty);
                parameters.Add("@LetterDate", request.LetterDate ?? string.Empty);
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@Punishment", request.Punishment ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePunishment/Sql/get_criteria_emp_punishment");
                var data = await db.QueryAsync<EmployeePunishmentDto>(query, parameters);

                var result = new EmployeePunishmentItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeePunishmentList = data.ToList()
                };

                return new ApiResponse<EmployeePunishmentItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeePunishmentItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Punishment data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeePunishment(SubmitEmployeePunishmentCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmPunishmentId", request.EmPunishmentId);
                parameters.Add("@LetterNo", request.LetterNo);
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@LetterDate", request.LetterDate);
                parameters.Add("@PunishmentType", request.PunishmentType);
                parameters.Add("@ValidFrom", request.ValidFrom);
                parameters.Add("@ValidTo", request.ValidTo);
                parameters.Add("@RecoveryDate", request.RecoveryDate);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@Attachment", request.Attachment);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePunishment/Sql/submit_emp_punishment");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeePunishment(DeleteEmployeePunishmentCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmPunishmentId", request.EmPunishmentId);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePunishment/Sql/get_single_emp_punishment");
                var data = await db.QueryFirstOrDefaultAsync<EmployeePunishmentDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<EmployeePunishmentDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePunishment/Sql/delete_emp_punishment");
                await db.ExecuteAsync(query_delete, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message);
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportEmployeePunishmentAsync(string type)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", 0);
                parameters.Add("@PageSize", 1000000);
                parameters.Add("@LetterDate", "");
                parameters.Add("@EmployeeId", 0);
                parameters.Add("@Punishment", "");
                parameters.Add("@SortBy", "EmployeeId");
                parameters.Add("@OrderBy", "ASC");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePunishment/Sql/get_emp_punishment");
                var data = await db.QueryAsync<EmployeePunishmentDto>(query, parameters);

                var fileName = string.Empty;
                byte[] fileBytes;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(type, "xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("EmployeePunishment");

                    ws.Cell("A1").Value = "Employee Punishment List";
                    ws.Range("A1:G1").Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    string[] headers = { "Employee No", "Full Name", "Letter No", "Letter Date", "Type", "Valid From", "Valid To" };
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
                        ws.Cell(row, 3).Value = item.LetterNo;
                        ws.Cell(row, 4).Value = item.LetterDate;
                        ws.Cell(row, 5).Value = item.PunishmentType;
                        ws.Cell(row, 6).Value = item.ValidFrom;
                        ws.Cell(row, 7).Value = item.ValidTo;
                        row++;
                    }

                    ws.Columns(1, 7).AdjustToContents();
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeePunishment_{DateTime.Now:yyyyMMdd}.xlsx";

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
                            page.Header().AlignCenter().Text("Employee Punishment List").SemiBold().FontSize(16);
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
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Letter No").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Type").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Valid To").Bold();
                                });
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeNo ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeName ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.LetterNo ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.PunishmentType ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeName ?? "-");
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeePunishment_{DateTime.Now:yyyyMMdd}.pdf";

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

