using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.WorkLocation.Commands;
using ThePatho.Features.Organization.WorkLocation.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using ThePatho.Features.Common.DTO;
using QuestPDF.Helpers;

namespace ThePatho.Features.Organization.WorkLocation.Service
{
    public class WorkLocationService : IWorkLocationService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public WorkLocationService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<WorkLocationItemDto>> GetWorkLocation(GetWorkLocationCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.WorkLocation)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.WorkLocationName),
                        q => q.WhereContains("WorkLocationCode", request.WorkLocationCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.WorkLocationName),
                        q => q.WhereContains("WorkLocationName", request.WorkLocationName)
                    )
                    .When(
                        request.IsActive.HasValue,
                        q => q.Where("IsActive", request.IsActive.Value)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.TaxLocationCode),
                        q => q.WhereContains("TaxLocationCode", request.TaxLocationCode)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<WorkLocationDto>(query);

                var result = new WorkLocationItemDto
                {
                    DataOfRecords = data.Count(),
                    WorkLocationList = data.ToList(),
                };
                return new ApiResponse<WorkLocationItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<WorkLocationItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<WorkLocationItemDto>> GetWorkLocationByCriteria(GetWorkLocationByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.WorkLocation)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.WorkLocationName),
                        q => q.WhereContains("WorkLocationCode", request.WorkLocationCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.WorkLocationName),
                        q => q.WhereContains("WorkLocationName", request.WorkLocationName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.TaxLocationCode),
                        q => q.WhereContains("TaxLocationCode", request.TaxLocationCode)
                    );

                var data = await db.GetAsync<WorkLocationDto>(query);

                var result = new WorkLocationItemDto
                {
                    DataOfRecords = data.Count(),
                    WorkLocationList = data.ToList(),
                };
                return new ApiResponse<WorkLocationItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<WorkLocationItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitWorkLocation(SubmitWorkLocationCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var existsQuery = new Query(TableOrganization.WorkLocation)
                    .Where("WorkLocationCode", request.WorkLocationCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.WorkLocation).AsInsert(new
                    {
                        WorkLocationCode = request.WorkLocationCode,
                        WorkLocationName = request.WorkLocationName,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow,
                        Latitude = request.Latitude,
                        Longitude = request.Longitude,
                        Radius = request.Radius,
                        IsActive = request.IsActive,
                        TimeZone = request.TimeZone,
                        TaxLocationCode = request.TaxLocationCode,
                        HazardInformation = request.HazardInformation
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.WorkLocation)
                        .Where("WorkLocationCode", request.WorkLocationCode)
                        .AsUpdate(new
                        {
                            WorkLocationName = request.WorkLocationName,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow,
                            Latitude = request.Latitude,
                            Longitude = request.Longitude,
                            Radius = request.Radius,
                            IsActive = request.IsActive,
                            TimeZone = request.TimeZone,
                            TaxLocationCode = request.TaxLocationCode,
                            HazardInformation = request.HazardInformation
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.WorkLocationCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.WorkLocationCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteWorkLocation(DeleteWorkLocationCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.WorkLocationCode))
                {
                    return new ApiResponse<WorkLocationDto>(
                         HttpStatusCode.BadRequest,
                         "WorkLocation is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.WorkLocation)
                                .Where("WorkLocationCode", request.WorkLocationCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.WorkLocationCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.WorkLocationCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<WorkLocationDto>> GetSingleWorkLocation(GetSingleWorkLocationCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.WorkLocation)
                    .Select("*")
                    .Where("WorkLocationCode", request.WorkLocationCode);

                var data = await db.FirstOrDefaultAsync<WorkLocationDto>(query);

                if (data == null)
                {
                    return new ApiResponse<WorkLocationDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<WorkLocationDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<WorkLocationDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportWorkLocationAsync(string type)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.WorkLocation)
                    .Select("WorkLocationCode", "WorkLocationName", "IsActive", "TimeZone", "TaxLocationCode", "Latitude", "Longitude", "Radius", "HazardInformation")
                    .OrderBy("WorkLocationCode");

                var data = await db.GetAsync<WorkLocationDto>(query);

                var exportType = (type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(exportType)) exportType = "excel";

                if (exportType == "excel" || exportType == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("WorkLocation");

                    // ===== TITLE =====
                    ws.Cell("A1").Value = "Work Location Master List";
                    ws.Range("A1:I1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                    ws.Row(1).Height = 24;

                    // ===== HEADER =====
                    var headers = new[]
                    {
                        "Work Location Code", "Work Location Name", "Active", "Time Zone",
                        "Tax Location", "Latitude", "Longitude", "Radius", "Hazard Information"
                    };

                    for (int i = 0; i < headers.Length; i++)
                        ws.Cell(3, i + 1).Value = headers[i];

                    var headerRange = ws.Range(3, 1, 3, headers.Length);
                    headerRange.Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));

                    // ===== DATA =====
                    int row = 4;
                    foreach (var item in data)
                    {
                        ws.Cell(row, 1).Value = item.WorkLocationCode;
                        ws.Cell(row, 2).Value = item.WorkLocationName;
                        ws.Cell(row, 3).Value = item.IsActive.HasValue
                            ? (item.IsActive.Value ? "Active" : "Inactive")
                            : string.Empty;
                        ws.Cell(row, 4).Value = item.TimeZone ?? string.Empty;
                        ws.Cell(row, 5).Value = item.TaxLocationCode ?? string.Empty;
                        ws.Cell(row, 6).Value = item.Latitude?.ToString() ?? string.Empty;
                        ws.Cell(row, 7).Value = item.Longitude?.ToString() ?? string.Empty;
                        ws.Cell(row, 8).Value = item.Radius?.ToString() ?? string.Empty;
                        ws.Cell(row, 9).Value = item.HazardInformation ?? string.Empty;
                        row++;
                    }

                    // ===== BORDER & ALIGNMENT =====
                    var lastRow = row - 1;
                    var tableRange = ws.Range(3, 1, lastRow, headers.Length);
                    tableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    tableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    tableRange.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // ===== AUTO FIT =====
                    ws.Columns(1, headers.Length).AdjustToContents();

                    // ===== FREEZE HEADER =====
                    ws.SheetView.FreezeRows(3);

                    // ===== EXPORT =====
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    var fileBytes = ms.ToArray();

                    var dto = new AttachmentFileDto
                    {
                        FileBytes = fileBytes,
                        FileName = $"WorkLocation.xlsx",
                        ContentType = MimeTypesConstants.VND_OPENXML_EXCEL
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);

                }
                else if (exportType == "pdf")
                {
                    var doc = Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Margin(30);
                            page.Size(PageSizes.A4.Landscape());

                            // Title
                            page.Header()
                                .AlignCenter()
                                .Text("Work Location")
                                .SemiBold()
                                .FontSize(16)
                                .FontColor(Colors.Black);

                            // Define text styles
                            var headerStyle = TextStyle.Default.FontSize(10).Bold();
                            var normalTextStyle = TextStyle.Default.FontSize(8);

                            // Table
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                // Column definitions
                                table.ColumnsDefinition(cols =>
                                {
                                    cols.RelativeColumn(1f);    // WorkLocationCode
                                    cols.RelativeColumn(1.5f);  // WorkLocationName
                                    cols.RelativeColumn(0.6f);  // IsActive
                                    cols.RelativeColumn(0.8f);  // TimeZone
                                    cols.RelativeColumn(0.9f);  // TaxLocationCode
                                    cols.RelativeColumn(0.7f);  // Latitude
                                    cols.RelativeColumn(0.7f);  // Longitude
                                    cols.RelativeColumn(0.7f);  // Radius
                                    cols.RelativeColumn(1.1f);  // HazardInformation
                                });

                                // Header
                                table.Header(header =>
                                {
                                    string[] headers = {
                                        "Work Location Code", "Work Location Name", "Active", "Time Zone", "Tax Location",
                                        "Latitude", "Longitude", "Radius", "Hazard Info"
                                    };

                                    foreach (var title in headers)
                                    {
                                        header.Cell()
                                            .Border(1)
                                            .PaddingVertical(4)
                                            .PaddingHorizontal(3)
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
                                    table.Cell().Border(1).Padding(3).AlignMiddle()
                                        .Text(item.WorkLocationCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(3).AlignMiddle()
                                        .Text(item.WorkLocationName ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(3).AlignMiddle()
                                        .Text(item.IsActive.HasValue ? (item.IsActive.Value ? "Yes" : "No") : "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(3).AlignMiddle()
                                        .Text(item.TimeZone ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(3).AlignMiddle()
                                        .Text(item.TaxLocationCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(3).AlignMiddle()
                                        .Text(item.Latitude?.ToString() ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(3).AlignMiddle()
                                        .Text(item.Longitude?.ToString() ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(3).AlignMiddle()
                                        .Text(item.Radius?.ToString() ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(3).AlignMiddle()
                                        .Text(item.HazardInformation ?? "-")
                                        .Style(normalTextStyle);
                                }
                            });
                        });
                    });

                    using var stream = new MemoryStream();
                    doc.GeneratePdf(stream);
                    var bytes = stream.ToArray();

                    var dto = new AttachmentFileDto
                    {
                        FileBytes = bytes,
                        FileName = "WorkLocation.pdf",
                        ContentType = MimeTypesConstants.PDF
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);
                }
                else
                {
                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "Type harus 'excel' atau 'pdf'");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "Gagal export work location", ex.Message);
            }
        }
        #endregion
    }
}
