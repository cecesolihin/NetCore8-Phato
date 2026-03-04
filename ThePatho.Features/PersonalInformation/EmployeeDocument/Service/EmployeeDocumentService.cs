using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeDocument.Commands;
using ThePatho.Features.PersonalInformation.EmployeeDocument.DTO;
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

namespace ThePatho.Features.PersonalInformation.EmployeeDocument.Service
{
    public class EmployeeDocumentService : IEmployeeDocumentService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeeDocumentService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeDocumentItemDto>> GetEmployeeDocument(GetEmployeeDocumentCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@DocumentTypeCode", request.FilterDocumentTypeCode ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeDocument/Sql/get_emp_document");
                var data = await db.QueryAsync<EmployeeDocumentDto>(query, parameters);

                var result = new EmployeeDocumentItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeDocumentList = data.ToList()
                };

                return new ApiResponse<EmployeeDocumentItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeDocumentItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Document list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeDocumentDto>> GetSingleEmployeeDocument(GetSingleEmployeeDocumentCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeDocumentId", request.EmployeeDocumentId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeDocument/Sql/get_single_emp_document");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeDocumentDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeDocumentDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeeDocumentDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeDocumentDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Document detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeDocumentItemDto>> GetEmployeeDocumentByCriteria(GetEmployeeDocumentByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId ?? 0);
                parameters.Add("@DocumentTypeCode", request.DocumentTypeCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeDocument/Sql/get_criteria_emp_document");
                var data = await db.QueryAsync<EmployeeDocumentDto>(query, parameters);

                var result = new EmployeeDocumentItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeDocumentList = data.ToList()
                };

                return new ApiResponse<EmployeeDocumentItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeDocumentItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Document data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeDocument(SubmitEmployeeDocumentCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeDocumentId", request.EmployeeDocumentId);
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@DocumentTypeCode", request.DocumentTypeCode);
                parameters.Add("@FilePath", request.FilePath);
                parameters.Add("@Remark", request.Remark);
                parameters.Add("@InsertedBy", request.InsertedBy);
                parameters.Add("@InsertedDate", request.InsertedDate);
                parameters.Add("@ModifiedBy", request.ModifiedBy);
                parameters.Add("@ModifiedDate", request.ModifiedDate);
                parameters.Add("@Action", request.Action);
                var userName = currentUserService.GetUserName();
                parameters.Add("@User", string.IsNullOrWhiteSpace(userName) ? "admin" : userName);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeDocument/Sql/submit_emp_document");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeDocument(DeleteEmployeeDocumentCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeDocumentId", request.EmployeeDocumentId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeDocument/Sql/get_single_emp_document");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeDocumentDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeDocumentDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeDocument/Sql/delete_emp_document");
                await db.ExecuteAsync(query_delete, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message);
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportEmployeeDocumentAsync(string type)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", 0);
                parameters.Add("@PageSize", 1000000);
                parameters.Add("@EmployeeId", 0);
                parameters.Add("@DocumentTypeCode", "");
                parameters.Add("@SortBy", "EmployeeId");
                parameters.Add("@OrderBy", "ASC");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeDocument/Sql/get_emp_document");
                var data = await db.QueryAsync<EmployeeDocumentDto>(query, parameters);

                var fileName = string.Empty;
                byte[] fileBytes;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(type, "xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("EmployeeDocument");

                    ws.Cell("A1").Value = "Employee Document List";
                    ws.Range("A1:E1").Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    string[] headers = { "Employee No", "Full Name", "Document Type", "File Path", "Remark" };
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
                        ws.Cell(row, 3).Value = item.DocumentTypeCode;
                        ws.Cell(row, 4).Value = item.FilePath;
                        ws.Cell(row, 5).Value = item.Remark;
                        row++;
                    }

                    ws.Columns(1, 5).AdjustToContents();
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeDocument_{DateTime.Now:yyyyMMdd}.xlsx";

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
                            page.Header().AlignCenter().Text("Employee Document List").SemiBold().FontSize(16);
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(80);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("No").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Employee").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Document Type").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("File Path").Bold();
                                    header.Cell().Border(1).Padding(5).Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2).Text("Remark").Bold();
                                });
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeNo ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeName ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.DocumentTypeCode ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.FilePath ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.Remark ?? "-");
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeDocument_{DateTime.Now:yyyyMMdd}.pdf";

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

