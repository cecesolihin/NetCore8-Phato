using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Organization.PensionType.Commands;
using ThePatho.Features.Organization.PensionType.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Organization.PensionType.Service
{
    public class PensionTypeService : IPensionTypeService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;
        private readonly ICurrentUserService currentUserService;

        public PensionTypeService(DapperContext _dapperContext, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<PensionTypeItemDto>> GetPensionType(GetPensionTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.PensionType)
                        .Select("*")
                        .When(
                            !string.IsNullOrWhiteSpace(request.FilterPensionType),
                            q => q.Where(w => w
                                .WhereContains("PensionTypeCode", request.FilterPensionType)
                                .OrWhereContains("PensionTypeName", request.FilterPensionType)
                            )
                        );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<PensionTypeDto>(query);

                var result = new PensionTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    PensionTypeList = data.ToList(),
                };
                return new ApiResponse<PensionTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<PensionTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<PensionTypeItemDto>> GetPensionTypeByCriteria(GetPensionTypeByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.PensionType)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.PensionTypeCode),
                        q => q.WhereContains("PensionTypeCode", request.PensionTypeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.PensionTypeName),
                        q => q.WhereContains("PensionTypeName", request.PensionTypeName)
                    );

                var data = await db.GetAsync<PensionTypeDto>(query);

                var result = new PensionTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    PensionTypeList = data.ToList(),
                };
                return new ApiResponse<PensionTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<PensionTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitPensionType(SubmitPensionTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var ArgumentException = new List<string>();
                
                var existsQuery = new Query(TableOrganization.PensionType)
                    .Where("PensionTypeCode", request.PensionTypeCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.PensionType).AsInsert(new
                    {
                        PensionTypeCode = request.PensionTypeCode,
                        PensionTypeName = request.PensionTypeName,
                        IsDeleted = false,
                        InsertedBy = currentUserService.GetUserName() ?? "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.PensionType)
                        .Where("PensionTypeCode", request.PensionTypeCode)
                        .AsUpdate(new
                        {
                            PensionTypeName = request.PensionTypeName,
                            IsDeleted = false,
                            ModifiedBy  = currentUserService.GetUserName() ?? "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.PensionTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.PensionTypeCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeletePensionType(DeletePensionTypeCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.PensionTypeCode))
                {
                    return new ApiResponse<PensionTypeDto>(
                         HttpStatusCode.BadRequest,
                         "PensionType is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.PensionType)
                                .Where("PensionTypeCode", request.PensionTypeCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.PensionTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.PensionTypeCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<PensionTypeDto>> GetSinglePensionType(GetSinglePensionTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.PensionType)
                    .Select("*")
                    .Where("PensionTypeCode", request.PensionTypeCode);

                var data = await db.FirstOrDefaultAsync<PensionTypeDto>(query);

                if (data == null)
                {
                    return new ApiResponse<PensionTypeDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<PensionTypeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<PensionTypeDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion

        public async Task<ApiResponse<AttachmentFileDto>> ExportPensionTypeAsync(string type)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var data = await db.Query(TableOrganization.PensionType)
                    .OrderBy("PensionTypeCode")
                    .GetAsync<PensionTypeDto>();

                var exportType = (type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(exportType)) exportType = "excel";

                byte[] fileBytes;
                string fileName;
                string contentType;

                if (exportType == "excel" || exportType == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("PensionType");

                    // ===== TITLE =====
                    worksheet.Cell("A1").Value = "Pension Type Master List";
                    worksheet.Range("A1:B1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // ===== HEADER =====
                    worksheet.Cell(3, 1).Value = "Pension Type Code";
                    worksheet.Cell(3, 2).Value = "Pension Type Name";

                    worksheet.Range(3, 1, 3, 2).Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));

                    // ===== DATA =====
                    var row = 4;
                    foreach (var item in data)
                    {
                        worksheet.Cell(row, 1).Value = item.PensionTypeCode;
                        worksheet.Cell(row, 2).Value = item.PensionTypeName;
                        row++;
                    }

                    // ===== BORDER =====
                    var lastDataRow = row - 1;
                    var range = worksheet.Range(3, 1, lastDataRow, 2);
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // ===== AUTO FIT =====
                    worksheet.Columns(1, 2).AdjustToContents();

                    // ===== EXPORT =====
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();

                    fileName = $"PensionType.xlsx";
                    contentType = MimeTypesConstants.VND_OPENXML_EXCEL;

                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(fileBytes),
                        FileName = fileName,
                        ContentType = contentType
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);

                }
                else if (exportType == "pdf")
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
                                .Text("Pension Type")
                                .SemiBold()
                                .FontSize(16)
                                .FontColor(Colors.Black);

                            // Define text styles
                            var headerStyle = TextStyle.Default.FontSize(12).Bold();
                            var normalTextStyle = TextStyle.Default.FontSize(8);

                            // Table
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                // Column definitions
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1.2f); // PensionTypeCode
                                    columns.RelativeColumn(2.8f); // PensionTypeName
                                });

                                // Header
                                table.Header(header =>
                                {
                                    string[] headers = {
                                        "Pension Type Code", "Pension Type Name"
                                    };

                                    foreach (var title in headers)
                                    {
                                        header.Cell()
                                            .Border(1)
                                            .PaddingVertical(4)
                                            .PaddingHorizontal(6)
                                            .Background(Colors.BlueGrey.Lighten2)
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
                                        .Text(item.PensionTypeCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.PensionTypeName ?? "-")
                                        .Style(normalTextStyle);
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();

                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(fileBytes),
                        FileName = "PensionType.pdf",
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
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "Gagal mengekspor Pension Type", ex.Message);
            }
        }
    }
}
