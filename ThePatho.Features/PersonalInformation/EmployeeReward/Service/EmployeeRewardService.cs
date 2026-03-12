using Azure.Core;
using ClosedXML.Excel;
using Dapper;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Data;
using System.IO;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.PersonalInformation.EmployeeReward.Commands;
using ThePatho.Features.PersonalInformation.EmployeeReward.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.PersonalInformation.EmployeeReward.Service
{
    public class EmployeeRewardService : IEmployeeRewardService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeeRewardService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeRewardItemDto>> GetEmployeeReward(GetEmployeeRewardCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@Reward", request.FilterReward ?? string.Empty);
                parameters.Add("@LetterDateFrom", request.FilterLetterDateFrom);
                parameters.Add("@LetterDateTo", request.FilterLetterDateTo);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeReward/Sql/get_emp_reward");
                var data = await db.QueryAsync<EmployeeRewardDto>(query, parameters);

                var result = new EmployeeRewardItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeRewardList = data.ToList()
                };

                return new ApiResponse<EmployeeRewardItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeRewardItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Reward list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeRewardDto>> GetSingleEmployeeReward(GetSingleEmployeeRewardCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmRewardId", request.EmRewardId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeReward/Sql/get_single_emp_reward");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeRewardDto>(query, parameters);

                return new ApiResponse<EmployeeRewardDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeRewardDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Reward detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeRewardItemDto>> GetEmployeeRewardByCriteria(GetEmployeeRewardByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId ?? 0);
                parameters.Add("@LetterNo", request.LetterNo ?? string.Empty);
                parameters.Add("@RewardTypeCode", request.RewardTypeCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeReward/Sql/get_criteria_emp_reward");
                var data = await db.QueryAsync<EmployeeRewardDto>(query, parameters);

                var result = new EmployeeRewardItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeRewardList = data.ToList()
                };

                return new ApiResponse<EmployeeRewardItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeRewardItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Reward data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeReward(SubmitEmployeeRewardCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmRewardId", request.EmRewardId);
                parameters.Add("@LetterNo", request.LetterNo);
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@LetterDate", request.LetterDate);
                parameters.Add("@RewardTypeCode", request.RewardTypeCode);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@CurrencyCode", request.CurrencyCode);
                parameters.Add("@Amount", request.Amount);
                parameters.Add("@Attachment", request.Attachment);
                parameters.Add("@Action", request.Action);
                var userName = currentUserService.GetUserName();
                parameters.Add("@User", string.IsNullOrWhiteSpace(userName) ? "admin" : userName);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeReward/Sql/submit_emp_reward");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeReward(DeleteEmployeeRewardCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmRewardId", request.EmRewardId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeReward/Sql/delete_emp_reward");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message);
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportEmployeeRewardAsync(string type)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", 1);
                parameters.Add("@PageSize", 1000000);
                parameters.Add("@EmployeeId", 0);
                parameters.Add("@Reward", null);
                parameters.Add("@LetterDateFrom", null);
                parameters.Add("@LetterDateTo", null);
                parameters.Add("@SortBy", "InsertedDate");
                parameters.Add("@OrderBy", "ASC");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeReward/Sql/get_emp_reward");
                var data = await db.QueryAsync<EmployeeRewardDto>(query, parameters);

                var fileName = string.Empty;
                byte[] fileBytes;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(type, "xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("EmployeeReward");

                    ws.Cell("A1").Value = "Employee Reward List";
                    ws.Range("A1:G1").Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    string[] headers = { "Employee No", "Full Name", "Letter No", "Letter Date", "Type", "Currency", "Amount" };
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
                        ws.Cell(row, 5).Value = item.RewardTypeCode;
                        ws.Cell(row, 6).Value = item.CurrencyCode;
                        ws.Cell(row, 7).Value = item.Amount;
                        row++;
                    }

                    ws.Columns(1, 7).AdjustToContents();
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeReward_{DateTime.Now:yyyyMMdd}.xlsx";

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
                            page.Header().AlignCenter().Text("Employee Reward List").SemiBold().FontSize(16);
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(80);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.ConstantColumn(80);
                                    columns.ConstantColumn(100);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("No").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Employee").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Letter No").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Type").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Currency").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Amount").Bold();
                                });
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeNo ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeName ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.LetterNo ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.RewardTypeCode ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.CurrencyCode ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.Amount?.ToString("N2") ?? "0.00");
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeReward_{DateTime.Now:yyyyMMdd}.pdf";

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

