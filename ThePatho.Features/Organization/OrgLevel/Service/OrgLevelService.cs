using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgLevel.Commands;
using ThePatho.Features.Organization.OrgLevel.DTO;
using ThePatho.Infrastructure.Persistance;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.OrgLevel.Service
{
    public class OrgLevelService : IOrgLevelService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public OrgLevelService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<OrgLevelItemDto>> GetOrgLevel(GetOrgLevelCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.OrgLevel)
                        .Select("*")
                        .Where("IsDeleted", false)
                        .When(
                            !string.IsNullOrWhiteSpace(request.FilterOrgLevel),
                            q => q.Where(w => w
                                .WhereContains("OrgLevelCode", request.FilterOrgLevel)
                                .OrWhereContains("OrgLevelName", request.FilterOrgLevel)
                            )
                        );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<OrgLevelDto>(query);

                var result = new OrgLevelItemDto
                {
                    DataOfRecords = data.Count(),
                    OrgLevelList = data.ToList(),
                };
                return new ApiResponse<OrgLevelItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<OrgLevelItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<OrgLevelItemDto>> GetOrgLevelByCriteria(GetOrgLevelByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.OrgLevel)
                    .Select("*")
                    .Where("IsDeleted", false)
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgLevelCode),
                        q => q.WhereContains("OrgLevelCode", request.OrgLevelCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgLevelName),
                        q => q.WhereContains("OrgLevelName", request.OrgLevelName)
                    );

                var data = await db.GetAsync<OrgLevelDto>(query);

                var result = new OrgLevelItemDto
                {
                    DataOfRecords = data.Count(),
                    OrgLevelList = data.ToList(),
                };
                return new ApiResponse<OrgLevelItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<OrgLevelItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitOrgLevel(SubmitOrgLevelCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var ArgumentException = new List<string>();
               
                var existsQuery = new Query(TableOrganization.OrgLevel)
                    .Where("OrgLevelCode", request.OrgLevelCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.OrgLevel).AsInsert(new
                    {
                        OrgLevelCode = request.OrgLevelCode,
                        OrgLevelName = request.OrgLevelName,
                        SortOrder = request.SortOrder,
                        IsDeleted = false,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.OrgLevel)
                        .Where("OrgLevelCode", request.OrgLevelCode)
                        .AsUpdate(new
                        {
                            OrgLevelName = request.OrgLevelName,
                            SortOrder = request.SortOrder,
                            IsDeleted = false,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.OrgLevelCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.OrgLevelCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteOrgLevel(DeleteOrgLevelCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.OrgLevelCode))
                {
                    return new ApiResponse<OrgLevelDto>(
                        HttpStatusCode.BadRequest,
                        "OrgLevel is required"
                    );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var updateResult = await db
                    .Query(TableOrganization.OrgLevel)
                    .Where("OrgLevelCode", request.OrgLevelCode)
                    .WhereFalse("IsDeleted")
                    .UpdateAsync(new
                    {
                        IsDeleted = true,
                        ModifiedBy = "system",
                        ModifiedDate = DateTime.UtcNow
                    });

                if (updateResult == 0)
                {
                    return new ApiResponse(
                        HttpStatusCode.NotFound,
                        $"OrgLevel {request.OrgLevelCode} not found"
                    );
                }

                return new ApiResponse(
                    HttpStatusCode.OK,
                    $"Delete {request.OrgLevelCode} successfully"
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse(
                    HttpStatusCode.InternalServerError,
                    $"Failed to delete {request.OrgLevelCode}",
                    ex.Message
                );
            }

        }

        public async Task<ApiResponse<OrgLevelDto>> GetSingleOrgLevel(GetSingleOrgLevelCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.OrgLevel)
                    .Select("*")
                    .Where("OrgLevelCode", request.OrgLevelCode);

                var data = await db.FirstOrDefaultAsync<OrgLevelDto>(query);

                if (data == null)
                {
                    return new ApiResponse<OrgLevelDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<OrgLevelDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<OrgLevelDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportOrgLevelAsync(string type)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var data = await db.Query(TableOrganization.OrgLevel)
                    .Where("IsDeleted", false)
                    .OrderBy("Sort")
                    .GetAsync<OrgLevelDto>();

                var exportType = (type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(exportType)) exportType = "excel";

                if (exportType == "excel" || exportType == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("OrgLevel");

                    // ===== TITLE =====
                    worksheet.Cell("A1").Value = "Organization Level List";
                    worksheet.Range("A1:C1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // ===== HEADER =====
                    worksheet.Cell(3, 1).Value = "Org Level Code";
                    worksheet.Cell(3, 2).Value = "Org Level Name";
                    worksheet.Cell(3, 3).Value = "Sort";

                    worksheet.Range(3, 1, 3, 3).Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));

                    // ===== DATA =====
                    var row = 4;
                    foreach (var item in data)
                    {
                        worksheet.Cell(row, 1).Value = item.OrgLevelCode;
                        worksheet.Cell(row, 2).Value = item.OrgLevelName;
                        worksheet.Cell(row, 3).Value = item.SortOrder;
                        row++;
                    }

                    // ===== BORDER =====
                    var lastDataRow = row - 1;
                    var range = worksheet.Range(3, 1, lastDataRow, 3);
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // ===== AUTO FIT =====
                    worksheet.Columns(1, 3).AdjustToContents();

                    // ===== EXPORT =====
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    var bytes = ms.ToArray();

                    var fileName = $"OrgLevel.xlsx";

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, new AttachmentFileDto
                    {
                        FileBytes = bytes,
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
                            page.Margin(30);
                            page.Size(PageSizes.A4.Landscape());

                            // ===== TITLE =====
                            page.Header().Element(header =>
                            {
                                header.AlignCenter()
                                    .PaddingBottom(10)
                                    .Text("Job Class List")
                                    .SemiBold()
                                    .FontSize(18);
                                //.FontColor("#007BFF"); // Warna biru profesional
                            });

                            // ===== CONTENT =====
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                // ===== COLUMN DEFINITIONS =====
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(120);
                                    columns.RelativeColumn();
                                    columns.ConstantColumn(60);
                                });

                                var headerStyle = TextStyle.Default.FontSize(12).Bold();
                                var normalTextStyle = TextStyle.Default.FontSize(8);

                                // ===== TABLE HEADER =====
                                table.Header(header =>
                                {
                                    string[] headers = { "Org Level Code", "Org Level Name", "Sort" };

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

                                // ===== TABLE DATA ROWS =====
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.OrgLevelCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.OrgLevelName ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.SortOrder.ToString())
                                        .Style(normalTextStyle);
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    var fileBytes = ms.ToArray();

                    var dto = new AttachmentFileDto
                    {
                        FileBytes = fileBytes,
                        FileName = "OrgLevel.pdf",
                        ContentType = MimeTypesConstants.PDF
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);
                }

                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, "Unsupported export type");
            }
            catch (Exception ex)
            {
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, "Failed to export Org Level", ex.Message);
            }
        }
        #endregion
    }
}
