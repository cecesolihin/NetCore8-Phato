using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.DTO;
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

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Service
{
    public class SuperiorSubordinateService : ISuperiorSubordinateService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public SuperiorSubordinateService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<SuperiorSubordinateItemDto>> GetSuperiorSubordinate(GetSuperiorSubordinateCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@Employee", request.FilterEmployee ?? 0);
                parameters.Add("@Superior", request.FilterSuperior ?? string.Empty);
                parameters.Add("@EffectiveDateFrom", request.FilterEffectiveDateFrom);
                parameters.Add("@EffectiveDateTo", request.FilterEffectiveDateTo);
                //parameters.Add("@Status", request.FilterStatus ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/get_superior_subordinate");
                var data = await db.QueryAsync<SuperiorSubordinateDto>(query, parameters);

                var result = new SuperiorSubordinateItemDto
                {
                    DataOfRecords = data.Count(),
                    SuperiorSubordinateList = data.ToList()
                };

                return new ApiResponse<SuperiorSubordinateItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<SuperiorSubordinateItemDto>(HttpStatusCode.BadRequest, "Error retrieving Superior Subordinate list.", ex.Message);
            }
        }

        public async Task<ApiResponse<SuperiorSubordinateDto>> GetSingleSuperiorSubordinate(GetSingleSuperiorSubordinateCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeSuperiorID", request.EmployeeSuperiorID);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/get_single_superior_subordinate");
                var data = await db.QueryFirstOrDefaultAsync<SuperiorSubordinateDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<SuperiorSubordinateDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<SuperiorSubordinateDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<SuperiorSubordinateDto>(HttpStatusCode.BadRequest, "Error retrieving Superior Subordinate detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<SuperiorSubordinateItemDto>> GetSuperiorSubordinateByCriteria(GetSuperiorSubordinateByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@Employee", request.Employee ?? string.Empty);
                parameters.Add("@Superior", request.Superior ?? string.Empty);
                parameters.Add("@Status", request.Status ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/get_criteria_superior_subordinate");
                var data = await db.QueryAsync<SuperiorSubordinateDto>(query, parameters);

                var result = new SuperiorSubordinateItemDto
                {
                    DataOfRecords = data.Count(),
                    SuperiorSubordinateList = data.ToList()
                };

                return new ApiResponse<SuperiorSubordinateItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<SuperiorSubordinateItemDto>(HttpStatusCode.BadRequest, "Error filtering Superior Subordinate data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitSuperiorSubordinate(SubmitSuperiorSubordinateCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeSuperiorID", request.EmployeeSuperiorId);
                parameters.Add("@EmployeeID", request.EmployeeId);
                parameters.Add("@EffectiveDate", request.EffectiveDate);
                parameters.Add("@Remarks", request.Remarks);

                parameters.Add("@Superior1ID", request.Superior1Id);
                parameters.Add("@Superior2ID", request.Superior2Id);
                parameters.Add("@Superior3ID", request.Superior3Id);
                parameters.Add("@Superior4ID", request.Superior4Id);
                parameters.Add("@Superior5ID", request.Superior5Id);
                parameters.Add("@Superior6ID", request.Superior6Id);
                parameters.Add("@Superior7ID", request.Superior7Id);
                parameters.Add("@Superior8ID", request.Superior8Id);
                parameters.Add("@Superior9ID", request.Superior9Id);
                parameters.Add("@Superior10ID", request.Superior10Id);

                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/submit_superior_subordinate");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }
        public async Task<ApiResponse> SubmitMultiSuperiorSubordinate(SubmitMultiSuperiorSubordinateCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeList", string.Join(",", request.EmployeeList));
                parameters.Add("@EffectiveDate", request.EffectiveDate);
                parameters.Add("@Remarks", request.Remarks);

                parameters.Add("@Superior1ID", request.Superior1Id);
                parameters.Add("@Superior2ID", request.Superior2Id);
                parameters.Add("@Superior3ID", request.Superior3Id);
                parameters.Add("@Superior4ID", request.Superior4Id);
                parameters.Add("@Superior5ID", request.Superior5Id);
                parameters.Add("@Superior6ID", request.Superior6Id);
                parameters.Add("@Superior7ID", request.Superior7Id);
                parameters.Add("@Superior8ID", request.Superior8Id);
                parameters.Add("@Superior9ID", request.Superior9Id);
                parameters.Add("@Superior10ID", request.Superior10Id);

                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/submit_multi_superior_subordinate");
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
        public async Task<ApiResponse> DeleteSuperiorSubordinate(DeleteSuperiorSubordinateCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeSuperiorID", request.EmployeeSuperiorID);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/get_single_superior_subordinate");
                var data = await db.QueryFirstOrDefaultAsync<SuperiorSubordinateDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<SuperiorSubordinateDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/delete_superior_subordinate");
                await db.ExecuteAsync(query_delete, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message);
            }
        }

        public async Task<ApiResponse> GenerateSuperiorSubordinate(GenerateSuperiorSubordinateCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EffectiveDate", request.EffectiveDate);
                parameters.Add("@IsOverWrite", request.OverWrite ?? false);
                parameters.Add("@EmployeeList", string.Join(",",request.EmployeeList));
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@Action", "Generate");
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/generate_superior_subordinate");
                var result = await db.QueryFirstOrDefaultAsync<ExecuteResult>(query, parameters);

                if (result != null && result.Success)
                    return new ApiResponse(HttpStatusCode.OK, result.Message);
                else
                    return new ApiResponse(HttpStatusCode.BadRequest, result?.Message ?? "Unknown error", result?.ErrorNote);
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to generate", ex.Message);
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportSuperiorSubordinateAsync(string type)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", 0);
                parameters.Add("@PageSize", 1000000);
                parameters.Add("@Employee", "");
                parameters.Add("@Superior", "");
                parameters.Add("@Status", "");
                parameters.Add("@SortBy", "EmployeeSuperiorID");
                parameters.Add("@OrderBy", "ASC");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/get_superior_subordinate");
                var data = await db.QueryAsync<SuperiorSubordinateDto>(query, parameters);

                var fileName = string.Empty;
                byte[] fileBytes;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(type, "xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("SuperiorSubordinate");

                    ws.Cell("A1").Value = "Superior Subordinate List";
                    ws.Range("A1:O1").Merge()
                        .Style.Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    string[] headers =
                    {
                        "Employee No",
                        "Employee Name",
                        "Superior 1",
                        "Superior 2",
                        "Superior 3",
                        "Superior 4",
                        "Superior 5",
                        "Superior 6",
                        "Superior 7",
                        "Superior 8",
                        "Superior 9",
                        "Superior 10",
                        "Effective Date",
                        "End Date",
                        "Status"
                    };

                    for (int i = 0; i < headers.Length; i++)
                    {
                        var cell = ws.Cell(3, i + 1);
                        cell.Value = headers[i];
                        cell.Style.Font.SetBold()
                            .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));
                    }

                    int row = 4;

                    foreach (var item in data)
                    {
                        ws.Cell(row, 1).Value = item.EmployeeNo;
                        ws.Cell(row, 2).Value = item.EmployeeName;

                        ws.Cell(row, 3).Value = $"{item.Superior1No} {item.Superior1Name}";
                        ws.Cell(row, 4).Value = $"{item.Superior2No} {item.Superior2Name}";
                        ws.Cell(row, 5).Value = $"{item.Superior3No} {item.Superior3Name}";
                        ws.Cell(row, 6).Value = $"{item.Superior4No} {item.Superior4Name}";
                        ws.Cell(row, 7).Value = $"{item.Superior5No} {item.Superior5Name}";
                        ws.Cell(row, 8).Value = $"{item.Superior6No} {item.Superior6Name}";
                        ws.Cell(row, 9).Value = $"{item.Superior7No} {item.Superior7Name}";
                        ws.Cell(row, 10).Value = $"{item.Superior8No} {item.Superior8Name}";
                        ws.Cell(row, 11).Value = $"{item.Superior9No} {item.Superior9Name}";
                        ws.Cell(row, 12).Value = $"{item.Superior10No} {item.Superior10Name}";

                        ws.Cell(row, 13).Value = item.EffectiveDate;
                        ws.Cell(row, 14).Value = item.EndDate;
                        ws.Cell(row, 15).Value = item.EndDate == null ? "ACTIVE" : "INACTIVE";

                        row++;
                    }

                    ws.Columns().AdjustToContents();

                    ws.Columns(1, 7).AdjustToContents();
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"SuperiorSubordinate_{DateTime.Now:yyyyMMdd}.xlsx";

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
                            page.Header().AlignCenter().Text("Superior Subordinate List").SemiBold().FontSize(16);
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(70);   // Emp No
                                    columns.RelativeColumn();     // Name

                                    for (int i = 0; i < 10; i++)
                                        columns.RelativeColumn(); // Superior 1–10

                                    columns.ConstantColumn(90);   // Status
                                    columns.ConstantColumn(100);  // Effective Date
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).Padding(3).Text("Emp No").Bold();
                                    header.Cell().Border(1).Padding(3).Text("Employee Name").Bold();

                                    for (int i = 1; i <= 10; i++)
                                        header.Cell().Border(1).Padding(3).Text($"Sup {i}").Bold();

                                    header.Cell().Border(1).Padding(3).Text("Status").Bold();
                                    header.Cell().Border(1).Padding(3).Text("Eff Date").Bold();
                                });

                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(3).Text(item.EmployeeNo ?? "-");
                                    table.Cell().Border(1).Padding(3).Text(item.EmployeeName ?? "-");

                                    table.Cell().Border(1).Padding(3).Text($"{item.Superior1No} {item.Superior1Name}");
                                    table.Cell().Border(1).Padding(3).Text($"{item.Superior2No} {item.Superior2Name}");
                                    table.Cell().Border(1).Padding(3).Text($"{item.Superior3No} {item.Superior3Name}");
                                    table.Cell().Border(1).Padding(3).Text($"{item.Superior4No} {item.Superior4Name}");
                                    table.Cell().Border(1).Padding(3).Text($"{item.Superior5No} {item.Superior5Name}");
                                    table.Cell().Border(1).Padding(3).Text($"{item.Superior6No} {item.Superior6Name}");
                                    table.Cell().Border(1).Padding(3).Text($"{item.Superior7No} {item.Superior7Name}");
                                    table.Cell().Border(1).Padding(3).Text($"{item.Superior8No} {item.Superior8Name}");
                                    table.Cell().Border(1).Padding(3).Text($"{item.Superior9No} {item.Superior9Name}");
                                    table.Cell().Border(1).Padding(3).Text($"{item.Superior10No} {item.Superior10Name}");

                                    table.Cell().Border(1).Padding(3)
                                        .Text(item.EndDate == null ? "ACTIVE" : "INACTIVE");

                                    table.Cell().Border(1).Padding(3)
                                        .Text(item.EffectiveDate ?? "-");
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"SuperiorSubordinate_{DateTime.Now:yyyyMMdd}.pdf";

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

