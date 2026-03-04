using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SqlKata;
using SqlKata.Execution;
using System.IO;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Organization.MutationType.Commands;
using ThePatho.Features.Organization.MutationType.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Organization.MutationType.Service
{
    public class MutationTypeService : IMutationTypeService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;
        private readonly ICurrentUserService currentUserService;

        public MutationTypeService(DapperContext _dapperContext, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<MutationTypeItemDto>> GetMutationType(GetMutationTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.MutationType)
                        .Select("*")
                        .When(
                            !string.IsNullOrWhiteSpace(request.FilterMutationType),
                            q => q.Where(w => w
                                .WhereContains("MutationTypeCode", request.FilterMutationType)
                                .OrWhereContains("MutationTypeName", request.FilterMutationType)
                            )
                        );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<MutationTypeDto>(query);

                var result = new MutationTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    MutationTypeList = data.ToList(),
                };
                return new ApiResponse<MutationTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<MutationTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<MutationTypeItemDto>> GetMutationTypeByCriteria(GetMutationTypeByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.MutationType)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.MutationTypeCode),
                        q => q.WhereContains("MutationTypeCode", request.MutationTypeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.MutationTypeName),
                        q => q.WhereContains("MutationTypeName", request.MutationTypeName)
                    );

                var data = await db.GetAsync<MutationTypeDto>(query);

                var result = new MutationTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    MutationTypeList = data.ToList(),
                };
                return new ApiResponse<MutationTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<MutationTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitMutationType(SubmitMutationTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var ArgumentException = new List<string>();
                
                var existsQuery = new Query(TableOrganization.MutationType)
                    .Where("MutationTypeCode", request.MutationTypeCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.MutationType).AsInsert(new
                    {
                        MutationTypeCode = request.MutationTypeCode,
                        MutationTypeName = request.MutationTypeName,
                        IsDeleted = false,
                        InsertedBy = currentUserService.GetUserName() ?? "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.MutationType)
                        .Where("MutationTypeCode", request.MutationTypeCode)
                        .AsUpdate(new
                        {
                            MutationTypeName = request.MutationTypeName,
                            IsDeleted = false,
                            ModifiedBy  = currentUserService.GetUserName() ?? "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.MutationTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.MutationTypeCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteMutationType(DeleteMutationTypeCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.MutationTypeCode))
                {
                    return new ApiResponse<MutationTypeDto>(
                         HttpStatusCode.BadRequest,
                         "MutationType is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.MutationType)
                                .Where("MutationTypeCode", request.MutationTypeCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.MutationTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.MutationTypeCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<MutationTypeDto>> GetSingleMutationType(GetSingleMutationTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.MutationType)
                    .Select("*")
                    .Where("MutationTypeCode", request.MutationTypeCode);

                var data = await db.FirstOrDefaultAsync<MutationTypeDto>(query);

                if (data == null)
                {
                    return new ApiResponse<MutationTypeDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<MutationTypeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<MutationTypeDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion

        public async Task<ApiResponse<AttachmentFileDto>> ExportMutationTypeAsync(string type)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var data = await db.Query(TableOrganization.MutationType)
                    .Where("IsDeleted", false)
                    .OrderBy("MutationTypeCode")
                    .GetAsync<MutationTypeDto>();

                var exportType = (type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(exportType)) exportType = "excel";

                if (exportType == "excel" || exportType == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("MutationType");

                    // ===== TITLE =====
                    worksheet.Cell("A1").Value = "Mutation Type List";
                    worksheet.Range("A1:F1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // ===== HEADER =====
                    worksheet.Cell(3, 1).Value = "Mutation Type Code";
                    worksheet.Cell(3, 2).Value = "Mutation Type Name";

                    worksheet.Range(3, 1, 3, 2).Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));

                    // ===== DATA =====
                    var row = 4;
                    foreach (var item in data)
                    {
                        worksheet.Cell(row, 1).Value = item.MutationTypeCode;
                        worksheet.Cell(row, 2).Value = item.MutationTypeName;
                        row++;
                    }

                    // ===== BORDER =====
                    var lastDataRow = row - 1;
                    var range = worksheet.Range(3, 1, lastDataRow, 2);
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // ===== AUTO FIT =====
                    worksheet.Columns(1, 6).AdjustToContents();

                    // ===== EXPORT =====
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    var bytes = ms.ToArray();

                    var fileName = $"MutationType.xlsx";

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(bytes),
                        FileName = fileName,
                        ContentType = MimeTypesConstants.VND_OPENXML_EXCEL
                    });

                }
                else if (exportType == "pdf")
                {
                    var document = Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Margin(20);
                            page.Size(PageSizes.A4.Landscape()); // gunakan landscape agar 6 kolom muat rapi
                            page.DefaultTextStyle(x => x.FontSize(10));

                            // Header Title
                            page.Header()
                                .Text("Mutation Type List")
                                .SemiBold()
                                .FontSize(14)
                                .AlignCenter();

                            // Table Content
                            page.Content().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(100);  // MutationTypeCode
                                    columns.RelativeColumn();     // MutationTypeName
                                });

                                var headerStyle = TextStyle.Default.FontSize(12).Bold();
                                var normalTextStyle = TextStyle.Default.FontSize(8);

                                // Header row
                                table.Header(header =>
                                {
                                    header.Cell()
                                            .Border(1)
                                            .PaddingVertical(4)
                                            .PaddingHorizontal(6)
                                            .Background(Colors.BlueGrey.Lighten2)
                                            .AlignCenter()
                                            .AlignMiddle().Text("Mutation Type Code").Style(headerStyle);
                                    header.Cell()
                                            .Border(1)
                                            .PaddingVertical(4)
                                            .PaddingHorizontal(6)
                                            .Background(Colors.BlueGrey.Lighten2)
                                            .AlignCenter()
                                            .AlignMiddle().Text("Mutation Type Name").Style(headerStyle);
                                });

                                // Data rows
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).AlignMiddle().Text(item.MutationTypeCode ?? "").Style(normalTextStyle);
                                    table.Cell().Border(1).Padding(5).AlignMiddle().Text(item.MutationTypeName ?? "").Style(normalTextStyle);
                                }
                            });
                        });
                    });

                  
                    var bytes = document.GeneratePdf();

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(bytes),
                        FileName = $"MutationType.pdf",
                        ContentType = MimeTypesConstants.PDF
                    });

                }

                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, "Unsupported export type");
            }
            catch (Exception ex)
            {
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, "Failed to export Mutation Type", ex.Message);
            }
        }
    }
}
