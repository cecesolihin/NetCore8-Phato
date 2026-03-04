using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SqlKata;
using SqlKata.Execution;
using System.IO;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Organization.EmploymentType.Commands;
using ThePatho.Features.Organization.EmploymentType.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;
using Query = SqlKata.Query;

namespace ThePatho.Features.Organization.EmploymentType.Service
{
    public class EmploymentTypeService : IEmploymentTypeService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;
        private readonly ICurrentUserService currentUserService;

        public EmploymentTypeService(DapperContext _dapperContext, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmploymentTypeItemDto>> GetEmploymentType(GetEmploymentTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.EmploymentType)
                    .Select("*")
                    .Where("IsDeleted", false)
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterEmploymentType),
                        q => q.Where(w => w
                            .WhereContains("EmploymentTypeCode", request.FilterEmploymentType)
                            .OrWhereContains("EmploymentTypeName", request.FilterEmploymentType)
                        )
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterStatus)
                        && request.FilterStatus.ToLower() != "all",
                        q =>
                        {
                            bool isActive = request.FilterStatus == "1";
                            return q.Where("IsActive", isActive);
                        }
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<EmploymentTypeDto>(query);

                var result = new EmploymentTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    EmploymentTypeList = data.ToList(),
                };
                return new ApiResponse<EmploymentTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmploymentTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<EmploymentTypeItemDto>> GetEmploymentTypeByCriteria(GetEmploymentTypeByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.EmploymentType)
                    .Select("*")
                    .Where("IsDeleted", false)
                    .Where("IsActive", true)
                    .When(
                        !string.IsNullOrWhiteSpace(request.EmploymentTypeCode),
                        q => q.WhereContains("EmploymentTypeCode", request.EmploymentTypeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.EmploymentTypeName),
                        q => q.WhereContains("EmploymentTypeName", request.EmploymentTypeName)
                    );

                var data = await db.GetAsync<EmploymentTypeDto>(query);

                var result = new EmploymentTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    EmploymentTypeList = data.ToList(),
                };
                return new ApiResponse<EmploymentTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmploymentTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitEmploymentType(SubmitEmploymentTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var argumentException = new List<string>();
               
                if (argumentException.Any())
                {
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.EmploymentTypeCode}", string.Join(", ", argumentException.ToArray()));
                }
                // Cek apakah EmploymentTypeCode sudah exists
                var existsQuery = new Query(TableOrganization.EmploymentType)
                    .Where("EmploymentTypeCode", request.EmploymentTypeCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.EmploymentType).AsInsert(new
                    {
                        EmploymentTypeCode = request.EmploymentTypeCode,
                        EmploymentTypeName = request.EmploymentTypeName,
                        IsActive = request.IsActive,
                        SortOrder = request.SortOrder,
                        Remarks = request.Remarks,
                        UseEndDate = request.UseEndDate,
                        EmploymentPeriodMonth = request.EmploymentPeriodMonth,
                        IsDeleted = request.IsDeleted,
                        InsertedBy = currentUserService.GetUserName() ?? "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.EmploymentType)
                        .Where("EmploymentTypeCode", request.EmploymentTypeCode) // Perbaiki typo: EmploymentType_code -> EmploymentTypeCode
                        .AsUpdate(new
                        {
                            EmploymentTypeName = request.EmploymentTypeName,
                            IsActive = request.IsActive,
                            SortOrder = request.SortOrder,
                            Remarks = request.Remarks,
                            UseEndDate = request.UseEndDate,
                            EmploymentPeriodMonth = request.EmploymentPeriodMonth,
                            IsDeleted = request.IsDeleted,
                            ModifiedBy  = currentUserService.GetUserName() ?? "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.EmploymentTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.EmploymentTypeCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteEmploymentType(DeleteEmploymentTypeCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.EmploymentTypeCode))
                {
                    return new ApiResponse(
                        HttpStatusCode.BadRequest,
                        "EmploymentType is required"
                    );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var updateResult = await db
                    .Query(TableOrganization.EmploymentType)
                    .Where("EmploymentTypeCode", request.EmploymentTypeCode)
                    .WhereFalse("IsDeleted") // optional: prevent double delete
                    .UpdateAsync(new
                    {
                        IsDeleted = true,
                        ModifiedBy  = currentUserService.GetUserName() ?? "system",
                        ModifiedDate = DateTime.UtcNow
                    });

                if (updateResult == 0)
                {
                    return new ApiResponse(
                        HttpStatusCode.NotFound,
                        $"EmploymentType {request.EmploymentTypeCode} not found"
                    );
                }

                return new ApiResponse(
                    HttpStatusCode.OK,
                    $"Delete {request.EmploymentTypeCode} successfully"
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse(
                    HttpStatusCode.InternalServerError,
                    $"Failed to delete {request.EmploymentTypeCode}",
                    ex.Message
                );
            }

        }

        public async Task<ApiResponse<EmploymentTypeDto>> GetSingleEmploymentType(GetSingleEmploymentTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.EmploymentType)
                    .Select("*")
                    .Where("EmploymentTypeCode", request.EmploymentTypeCode);
                   
                var data = await db.FirstOrDefaultAsync<EmploymentTypeDto>(query);
                return new ApiResponse<EmploymentTypeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmploymentTypeDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        
        public async Task<ApiResponse<AttachmentFileDto>> ExportEmploymentTypeAsync(string type)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var data = await db.Query(TableOrganization.EmploymentType)
                    .Where("IsDeleted", false)
                    .OrderBy("EmploymentTypeCode")
                    .GetAsync<EmploymentTypeDto>();

                var fileName = string.Empty;
                byte[] fileBytes;
                string contentType;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(type, "xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("EmploymentType");

                    // Judul
                    ws.Cell("A1").Value = "Employment Type List";
                    ws.Range("A1:F1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // Header
                    ws.Cell(3, 1).Value = "Employment Type Code";
                    ws.Cell(3, 2).Value = "Employment Type Name";
                    ws.Cell(3, 3).Value = "Status";
                    ws.Cell(3, 4).Value = "SortOrder";
                    ws.Cell(3, 5).Value = "Use End Date";
                    ws.Cell(3, 6).Value = "Employment Period (Month)";

                    ws.Range(3, 1, 3, 6).Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));

                    // Data
                    var row = 4;
                    foreach (var item in data)
                    {
                        ws.Cell(row, 1).Value = item.EmploymentTypeCode;
                        ws.Cell(row, 2).Value = item.EmploymentTypeName;
                        ws.Cell(row, 3).Value = item.IsActive;
                        ws.Cell(row, 4).Value = item.SortOrder;
                        ws.Cell(row, 5).Value = item.UseEndDate ? "Yes" :"No";
                        ws.Cell(row, 6).Value = item.EmploymentPeriodMonth;
                        row++;
                    }

                    // Auto-fit kolom
                    ws.Columns(1, 6).AdjustToContents();

                    // Border seluruh tabel (header + data)
                    var lastDataRow = row - 1;
                    var tableRange = ws.Range(3, 1, lastDataRow, 6);
                    tableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    tableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // Simpan ke stream
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();

                   fileName = $"EmploymentType.xlsx";

                    var dto = new AttachmentFileDto
                    {
                        //Base64Data = Convert.ToBase64String(fileBytes),
                        Base64Data = Convert.ToBase64String(fileBytes),
                        FileName = fileName,
                        ContentType = MimeTypesConstants.VND_OPENXML_EXCEL
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);
                }

                else if (string.Equals(type, "pdf", StringComparison.OrdinalIgnoreCase))
                {
                    var document = Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Margin(30);
                            page.Size(PageSizes.A4.Landscape());

                            // Title
                            page.Header()
                                .AlignCenter()
                                .Text("Employment Type List")
                                .SemiBold()
                                .FontSize(16)
                                .FontColor(QuestPDF.Helpers.Colors.Black);

                            // Define text styles
                            var headerStyle = TextStyle.Default.FontSize(12).Bold();
                            var normalTextStyle = TextStyle.Default.FontSize(8);

                            // Table
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                // Column definitions
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(100); // Code
                                    columns.ConstantColumn(160); // Name
                                    columns.ConstantColumn(80);  // Status
                                    columns.ConstantColumn(60);  // Order
                                    columns.ConstantColumn(100); // UseEndDate
                                    columns.ConstantColumn(140); // EmploymentPeriodMonth
                                });

                                // Header
                                table.Header(header =>
                                {
                                    string[] headers = {
                                        "Employment Type Code", "Employment Type Name", "Status", "SortOrder",
                                        "Use End Date", "Employment Period (Month)"
                                    };

                                    foreach (var title in headers)
                                    {
                                        header.Cell()
                                            .Border(1)
                                            .PaddingVertical(4)
                                            .PaddingHorizontal(6)
                                            .Background(QuestPDF.Helpers.Colors.BlueGrey.Lighten2)
                                            .AlignCenter()
                                            .AlignMiddle()
                                            .Text(title)
                                            .Style(headerStyle);
                                    }
                                });

                                // Data rows
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.EmploymentTypeCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.EmploymentTypeName ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.IsActive ? "Active" :"Inactive")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.SortOrder.ToString())
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.UseEndDate ? "Yes" : "No")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.EmploymentPeriodMonth?.ToString() ?? "-")
                                        .Style(normalTextStyle);
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();

                    fileName = $"EmploymentType.pdf";

                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(fileBytes),
                        FileName = fileName,
                        ContentType = MimeTypesConstants.PDF
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);

                }
                else
                {
                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "Tipe file tidak dikenali. Gunakan 'excel' atau 'pdf'.");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "Gagal mengekspor Employment Type", ex.Message);
            }
        }
        #endregion
    }
}
