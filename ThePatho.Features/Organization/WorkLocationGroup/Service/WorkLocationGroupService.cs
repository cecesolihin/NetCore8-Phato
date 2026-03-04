using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Organization.WorkLocationGroup.Commands;
using ThePatho.Features.Organization.WorkLocationGroup.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Organization.WorkLocationGroup.Service
{
    public class WorkLocationGroupService : IWorkLocationGroupService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;
        private readonly ICurrentUserService currentUserService;

        public WorkLocationGroupService(DapperContext _dapperContext, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<WorkLocationGroupItemDto>> GetWorkLocationGroup(GetWorkLocationGroupCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.WorkLocationGroup)
                    .Select("*")
                    .When(
                        request.FilterGroupId.HasValue && request.FilterGroupId > 0,
                        q => q.Where("GroupId", request.FilterGroupId.Value)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterWorkLocationCode),
                        q => q.WhereContains("WorkLocationCode", request.FilterWorkLocationCode)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<WorkLocationGroupDto>(query);

                var result = new WorkLocationGroupItemDto
                {
                    DataOfRecords = data.Count(),
                    WorkLocationGroupList = data.ToList(),
                };
                return new ApiResponse<WorkLocationGroupItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<WorkLocationGroupItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<WorkLocationGroupItemDto>> GetWorkLocationGroupByCriteria(GetWorkLocationGroupByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.WorkLocationGroup)
                    .Select("*")
                    .When(
                        request.FilterGroupId.HasValue && request.FilterGroupId > 0,
                        q => q.Where("GroupId", request.FilterGroupId.Value)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterWorkLocationCode),
                        q => q.WhereContains("WorkLocationCode", request.FilterWorkLocationCode)
                    );

                var data = await db.GetAsync<WorkLocationGroupDto>(query);

                var result = new WorkLocationGroupItemDto
                {
                    DataOfRecords = data.Count(),
                    WorkLocationGroupList = data.ToList(),
                };
                return new ApiResponse<WorkLocationGroupItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<WorkLocationGroupItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitWorkLocationGroup(SubmitWorkLocationGroupCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                if (request.GroupDetailId == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.WorkLocationGroupDetail).AsInsert(new
                    {
                        GroupId = request.GroupId,
                        WorkLocationCode = request.WorkLocationCode,
                        InsertedBy = currentUserService.GetUserName() ?? "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update - cek apakah data exists
                    var existsQuery = new Query(TableOrganization.WorkLocationGroupDetail)
                        .Where("GroupDetailId", request.GroupDetailId)
                        .SelectRaw("COUNT(1)");

                    var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                    if (exists == 0)
                    {
                        return new ApiResponse(HttpStatusCode.NotFound, $"WorkLocationGroup Detail with ID {request.GroupDetailId} not found.");
                    }

                    // Update
                    var updateQuery = new Query(TableOrganization.WorkLocationGroupDetail)
                        .Where("GroupDetailId", request.GroupDetailId)
                        .AsUpdate(new
                        {
                            GroupId = request.GroupId,
                            WorkLocationCode = request.WorkLocationCode,
                            ModifiedBy  = currentUserService.GetUserName() ?? "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} WorkLocationGroup Detail successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} WorkLocationGroup Detail", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteWorkLocationGroup(DeleteWorkLocationGroupCommand request)
        {
            try
            {
                if (request.GroupDetailId == 0)
                {
                    return new ApiResponse<WorkLocationGroupDto>(
                         HttpStatusCode.BadRequest,
                         "WorkLocationGroup is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.WorkLocationGroup)
                                .Where("GroupDetailId", request.GroupDetailId)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete ", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<WorkLocationGroupDto>> GetSingleWorkLocationGroup(GetSingleWorkLocationGroupCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.WorkLocationGroup)
                    .Select("*")
                    .Where("GroupDetailId", request.GroupDetailId);

                var data = await db.FirstOrDefaultAsync<WorkLocationGroupDto>(query);

                if (data == null)
                {
                    return new ApiResponse<WorkLocationGroupDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<WorkLocationGroupDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<WorkLocationGroupDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportWorkLocationGroupAsync(string type)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.WorkLocationGroup)
                    .Select("GroupDetailId", "GroupId", "WorkLocationCode")
                    .OrderBy("GroupId");

                var data = await db.GetAsync<WorkLocationGroupDto>(query);

                var exportType = (type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(exportType)) exportType = "excel";

                if (exportType == "excel" || exportType == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("WorkLocationGroup");

                    // ===== TITLE =====
                    ws.Cell("A1").Value = "Work Location Group Master List";
                    ws.Range("A1:C1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                    ws.Row(1).Height = 24;

                    // ===== HEADER =====
                    var headers = new[] { "Group Detail ID", "Group ID", "Work Location Code" };
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
                        ws.Cell(row, 1).Value = item.GroupDetailId;
                        ws.Cell(row, 2).Value = item.GroupId;
                        ws.Cell(row, 3).Value = item.WorkLocationCode ?? string.Empty;
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
                        Base64Data = Convert.ToBase64String(fileBytes),
                        FileName = $"WorkLocationGroup.xlsx",
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
                                .Text("Work Location Group")
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
                                table.ColumnsDefinition(cols =>
                                {
                                    cols.RelativeColumn(1.2f); // GroupDetailId
                                    cols.RelativeColumn(1f);   // GroupId
                                    cols.RelativeColumn(1.8f); // WorkLocationCode
                                });

                                // Header
                                table.Header(header =>
                                {
                                    string[] headers = {
                    "Group Detail ID", "Group ID", "Work Location Code"
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
                                        .Text(item.GroupDetailId.ToString())
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.GroupId.ToString())
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.WorkLocationCode ?? "-")
                                        .Style(normalTextStyle);
                                }
                            });
                        });
                    });

                    using var stream = new MemoryStream();
                    doc.GeneratePdf(stream);
                    var bytes = stream.ToArray();

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(bytes),
                        FileName = "WorkLocationGroup.pdf",
                        ContentType = MimeTypesConstants.PDF
                    });
                }
                else
                {
                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "Type harus 'excel' atau 'pdf'");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "Gagal export work location group", ex.Message);
            }
        }
        #endregion
    }
}
