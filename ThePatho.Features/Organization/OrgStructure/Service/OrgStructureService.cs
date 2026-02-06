using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgStructure.Commands;
using ThePatho.Features.Organization.OrgStructure.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Domain.Models.Organization;
using System.IO;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.OrgStructure.Service
{
    public class OrgStructureService : IOrgStructureService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public OrgStructureService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<OrgStructureItemDto>> GetOrgStructure(GetOrgStructureCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.OrgStructure)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgStructureCode),
                        q => q.WhereContains("OrgStructureCode", request.OrgStructureCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgStructureName),
                        q => q.WhereContains("OrgStructureName", request.OrgStructureName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgLevelCode),
                        q => q.WhereContains("OrgLevelCode", request.OrgLevelCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.Status)
                        && request.Status.ToLower() != "all",
                        q =>
                        {
                            bool isActive = request.Status == "1";
                            return q.Where("IsActive", isActive);
                        }
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<OrgStructureDto>(query);

                var result = new OrgStructureItemDto
                {
                    DataOfRecords = data.Count(),
                    OrgStructureList = data.ToList(),
                };
                return new ApiResponse<OrgStructureItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<OrgStructureItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<OrgStructureItemDto>> GetOrgStructureByCriteria(GetOrgStructureByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.OrgStructure)
                .Select("*")
                    .When(
                        request.OrgStructureId > 0,
                        q => q.WhereContains("OrgStructureId", request.OrgStructureId)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgStructureCode),
                        q => q.WhereContains("OrgStructureCode", request.OrgStructureCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgStructureName),
                        q => q.WhereContains("OrgStructureName", request.OrgStructureName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgLevelCode),
                        q => q.WhereContains("OrgLevelCode", request.OrgLevelCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.Status)
                        && request.Status.ToLower() != "all",
                        q =>
                        {
                            bool isActive = request.Status == "1";
                            return q.Where("IsActive", isActive);
                        }
                    );

                var data = await db.GetAsync<OrgStructureDto>(query);

                var result = new OrgStructureItemDto
                {
                    DataOfRecords = data.Count(),
                    OrgStructureList = data.ToList(),
                };
                return new ApiResponse<OrgStructureItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<OrgStructureItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitOrgStructure(SubmitOrgStructureCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                string path = string.Empty;
                List<string> pathList = new List<string>();

                
                if (request.Action.ToUpper() == "ADD")
                {
                    var query = new Query(TableOrganization.OrgStructure).Select("*").OrderByDesc("OrgStructureID");

                    var org_last = await db.FirstOrDefaultAsync<OrgStructureDto>(query);

                    var query_parent_org = new Query(TableOrganization.OrgStructure)
                                    .Select("*").Where("OrgStructureId", request.ParentOrgId);

                    var data_parent_org = await db.FirstOrDefaultAsync<OrgStructureDto>(query_parent_org);

                    if (data_parent_org != null)
                    {
                        pathList = data_parent_org.Path.ToString().Split(',').ToList();
                    }

                    pathList.Add((org_last.OrgStructureId + 1).ToString());
                    path = string.Join(",", pathList.ToArray());

                    var existsQuery = new Query(TableOrganization.OrgStructure)
                        .Where("OrgStructureCode", request.OrgStructureCode)
                        .SelectRaw("COUNT(1)");

                    var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                    if (exists > 0)
                    {
                        return new ApiResponse(
                            HttpStatusCode.BadRequest,
                            $"OrgStructure with code {request.OrgStructureCode} already exists."
                        );
                    }


                    // Insert new record
                    var insertQuery = new Query(TableOrganization.OrgStructure).AsInsert(new
                    {
                        OrgStructureCode = request.OrgStructureCode,
                        OrgStructureName = request.OrgStructureName,
                        ParentOrgId = request.ParentOrgId,
                        OrgLevelCode = request.OrgLevelCode,
                        IsActive = request.IsActive,
                        Location = request.Location,
                        Path = path,
                        CostCenter = request.CostCenter,
                        Phone = request.Phone,
                        SortOrder = request.SortOrder,
                        IsDeleted = false,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);

                    if (insertResult == 0)
                    {
                        return new ApiResponse(
                            HttpStatusCode.BadRequest,
                            $"Failed to insert org structure {request.OrgStructureCode}"
                        );
                    }
                }
                else if (request.Action.ToUpper() == "EDIT")
                {
                    if (request.OrgStructureId == 0)
                    {
                        return new ApiResponse(
                            HttpStatusCode.BadRequest,
                            "OrgStructure ID is required for update operation."
                        );
                    }

                    var existsQuery = new Query(TableOrganization.OrgStructure)
                        .Where("OrgStructureId", request.OrgStructureId)
                        .SelectRaw("COUNT(1)");

                    var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                    if (exists == 0)
                    {
                        return new ApiResponse(
                            HttpStatusCode.NotFound,
                            $"OrgStructure with ID {request.OrgStructureId} not found."
                        );
                    }

                   
                    var query_parent_org = new Query(TableOrganization.OrgStructure)
                                    .Select("*").Where("OrgStructureId", request.ParentOrgId);

                    var data_parent_org = await db.FirstOrDefaultAsync<OrgStructureDto>(query_parent_org);

                    if (data_parent_org != null)
                    {
                        pathList = data_parent_org.Path.ToString().Split(',').ToList();
                    }

                    pathList.Add(request.OrgStructureId.ToString());
                    path = string.Join(",", pathList.ToArray());

                    // Update existing record
                    var updateQuery = new Query(TableOrganization.OrgStructure)
                        .Where("OrgStructureId", request.OrgStructureId)
                        .AsUpdate(new
                        {
                            //OrgStructureCode = request.OrgStructureCode,
                            OrgStructureName = request.OrgStructureName,
                            ParentOrgId = request.ParentOrgId,
                            OrgLevelCode = request.OrgLevelCode,
                            IsActive = request.IsActive,
                            Location = request.Location,
                            Path = path,
                            CostCenter = request.CostCenter,
                            Phone = request.Phone,
                            SortOrder = request.SortOrder,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);

                    if (updateResult == 0)
                    {
                        return new ApiResponse(
                            HttpStatusCode.BadRequest,
                            $"Failed to update org structure {request.OrgStructureCode}"
                        );
                    }
                }

                var actionMessage = request.Action.ToUpper() == "ADD" ? "created" : "updated";
                return new ApiResponse(
                    HttpStatusCode.OK,
                    $"Org structure {request.OrgStructureCode} {actionMessage} successfully"
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse(
                    HttpStatusCode.BadRequest,
                    $"Failed to {request.Action} org structure {request.OrgStructureCode}",
                    ex.Message
                );
            }
        }
        public async Task<ApiResponse> DeleteOrgStructure(DeleteOrgStructureCommand request)
        {
            try
            {
                if (request.OrgStructureId > 0)
                {
                    return new ApiResponse<OrgStructureDto>(
                         HttpStatusCode.BadRequest,
                         "OrgStructure is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.OrgStructure)
                                .Where("OrgStructureId", request.OrgStructureId)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete ", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<OrgStructureDto>> GetSingleOrgStructure(GetSingleOrgStructureCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.OrgStructure)
                    .Select("*")
                    .Where("OrgStructureId", request.OrgStructureId);

                var data = await db.FirstOrDefaultAsync<OrgStructureDto>(query);

                if (data == null)
                {
                    return new ApiResponse<OrgStructureDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<OrgStructureDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<OrgStructureDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportOrgStructureAsync(string type)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.OrgStructure)
                    .Select(
                        "OrgStructureCode",
                        "OrgStructureName",
                        "ParentOrgStructureID",
                        "OrgLevelCode",
                        "CostCenterCode",
                        "Location",
                        "Path",
                        "Status"
                    )
                    .Where("IsDeleted", false)
                    .OrderBy("ParentOrgStructureID");

                var data = await db.GetAsync<OrgStructureDto>(query);

                var exportType = (type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(exportType)) exportType = "excel";

                // Excel
                if (exportType == "excel" || exportType == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("OrgStructure");

                    // ===== TITLE =====
                    worksheet.Cell("A1").Value = "Organization Structure List";
                    worksheet.Range("A1:H1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // ===== HEADER =====
                    worksheet.Cell(3, 1).Value = "Org Structure Code";
                    worksheet.Cell(3, 2).Value = "Org Structure Name";
                    worksheet.Cell(3, 3).Value = "Parent Org Structure ID";
                    worksheet.Cell(3, 4).Value = "Org Level Code";
                    worksheet.Cell(3, 5).Value = "Cost Center Code";
                    worksheet.Cell(3, 6).Value = "Location";
                    worksheet.Cell(3, 7).Value = "Path";
                    worksheet.Cell(3, 8).Value = "Status";

                    worksheet.Range(3, 1, 3, 8).Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));

                    // ===== DATA =====
                    var row = 4;
                    foreach (var item in data)
                    {
                        worksheet.Cell(row, 1).Value = item.OrgStructureCode;
                        worksheet.Cell(row, 2).Value = item.OrgStructureName;
                        worksheet.Cell(row, 3).Value = item.ParentOrgStructureID?.ToString() ?? string.Empty;
                        worksheet.Cell(row, 4).Value = item.OrgLevelCode;
                        worksheet.Cell(row, 5).Value = item.CostCenterCode;
                        worksheet.Cell(row, 6).Value = item.Location;
                        worksheet.Cell(row, 7).Value = item.Path;
                        worksheet.Cell(row, 8).Value = item.IsActive ? "Active" :"Inactive";
                        row++;
                    }

                    // ===== BORDER =====
                    var lastDataRow = row - 1;
                    var range = worksheet.Range(3, 1, lastDataRow, 8);
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // ===== AUTO FIT =====
                    worksheet.Columns(1, 8).AdjustToContents();

                    // ===== EXPORT =====
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    var bytes = ms.ToArray();

                    var fileName = $"OrgStructure.xlsx";

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, new AttachmentFileDto
                    {
                        FileBytes = bytes,
                        FileName = fileName,
                        ContentType = MimeTypesConstants.VND_OPENXML_EXCEL
                    });

                }
                // PDF
                else if (exportType == "pdf")
                {
                    var doc = Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Margin(30);
                            page.Size(PageSizes.A4.Landscape());
                            page.DefaultTextStyle(x => x.FontSize(10));

                            // Title
                            page.Header()
                                .AlignCenter()
                                .Text("Org Structure")
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
                                    columns.RelativeColumn(1.2f); // OrgStructureCode
                                    columns.RelativeColumn(1.6f); // OrgStructureName
                                    columns.RelativeColumn(1f);   // ParentOrgId
                                    columns.RelativeColumn(0.8f); // OrgLevelCode
                                    columns.RelativeColumn(1.2f); // CostCenterCode
                                    columns.RelativeColumn(1.4f); // Location
                                    columns.RelativeColumn(1.8f); // Path
                                    columns.RelativeColumn(0.8f); // Status
                                });

                                // Header
                                table.Header(header =>
                                {
                                    string[] headers = {
                                        "Org Structure Code", "Org Structure Name", "Parent Org ID",
                                        "Org Level Code", "Cost Center Code", "Location",
                                        "Path", "Status"
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
                                        .Text(item.OrgStructureCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.OrgStructureName ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.ParentOrgStructureID?.ToString() ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.OrgLevelCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.CostCenterCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.Location ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.Path ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.IsActive ? "Active" :"Inactive")
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
                        FileName = $"OrgStructure.pdf",
                        ContentType = MimeTypesConstants.PDF
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);
                }
                else
                {
                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, "Unsupported export type");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, "Failed to export Org Structure", ex.Message);
            }
        }
        #endregion
    }
}
