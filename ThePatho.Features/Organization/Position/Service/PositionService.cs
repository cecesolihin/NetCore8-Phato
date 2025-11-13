using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Position.Commands;
using ThePatho.Features.Organization.Position.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.Position.Service
{
    public class PositionService : IPositionService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext; 

        public PositionService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<PositionItemDto>> GetPosition(GetPositionCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Position)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterPositionCode),
                        q => q.WhereIn("PositionCode", request.FilterPositionCode)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterPositionName),
                            q => q.WhereContains("PositionName", request.FilterPositionName)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<PositionDto>(query);

                var result = new PositionItemDto
                {
                    DataOfRecords = data.Count(),
                    PositionList = data.ToList(),
                };
                return new ApiResponse<PositionItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<PositionItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<PositionItemDto>> GetPositionByCriteria(GetPositionByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Position)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterOrgStructureId),
                        q => q.WhereIn("OrgStructureID", request.FilterOrgStructureId)
                    );

                var data = await db.GetAsync<PositionDto>(query);

                var result = new PositionItemDto
                {
                    DataOfRecords = data.Count(),
                    PositionList = data.ToList(),
                };
                return new ApiResponse<PositionItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<PositionItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitPosition(SubmitPositionCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                if (string.IsNullOrWhiteSpace(request.PositionCode))
                {
                    throw new ArgumentException("Position Code is required.");
                }

                var existsQuery = new Query(TableOrganization.Position)
                    .Where("PositionCode", request.PositionCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.Position).AsInsert(new
                    {
                        PositionCode = request.PositionCode,
                        PositionName = request.PositionName,
                        JobLevelCode = request.JobLevelCode,
                        OrgStructureId = request.OrgStructureId,
                        ActAsHead = request.ActAsHead,
                        Objective = request.Objective,
                        JobDescription = request.JobDescription,
                        IsDeleted = false,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.Position)
                        .Where("PositionCode", request.PositionCode)
                        .AsUpdate(new
                        {
                            PositionName = request.PositionName,
                            JobLevelCode = request.JobLevelCode,
                            OrgStructureId = request.OrgStructureId,
                            ActAsHead = request.ActAsHead,
                            Objective = request.Objective,
                            JobDescription = request.JobDescription,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.PositionCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.PositionCode}", ex.Message.ToString());
            }
        }
        public async Task<ApiResponse> DeletePosition(DeletePositionCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.PositionCode))
                {
                    return new ApiResponse<PositionDto>(
                         HttpStatusCode.BadRequest,
                         "Position is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.Position)
                                .Where("PositionCode", request.PositionCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.PositionCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.PositionCode}", ex.Message.ToString());
            }
            
        }

        public async Task<ApiResponse<PositionDto>> GetSinglePosition(GetSinglePositionCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Position)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterPositionCode),
                        q => q.WhereIn("PositionCode", request.FilterPositionCode)
                    );

                var data = await db.FirstOrDefaultAsync<PositionDto>(query);

                if (data == null)
                {
                    return new ApiResponse<PositionDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<PositionDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<PositionDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportPositionAsync(string type)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Position)
                    .Select(
                        "PositionCode",
                        "PositionName",
                        "JobLevelCode",
                        "OrgStructureID",
                        "ActAsHead",
                        "Objective",
                        "JobDescription",
                        "Status",
                        "ParentPositionCode",
                        "PositionPath"
                    )
                    .OrderBy("OrgStructureID");

                var data = await db.GetAsync<PositionDto>(query);

                var exportType = (type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(exportType)) exportType = "excel";

                if (exportType == "excel" || exportType == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("Positions");

                    // ===== TITLE =====
                    worksheet.Cell("A1").Value = "Position Master List";
                    worksheet.Range("A1:J1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // ===== HEADER =====
                    var headers = new[]
                    {
                        "Position Code","Position Name","Job Level Code","Org Structure ID","Act As Head",
                        "Objective","Job Description","Status","Parent Position Code","Position Path"
                    };

                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cell(3, i + 1).Value = headers[i];
                    }

                    worksheet.Range(3, 1, 3, headers.Length).Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));

                    // ===== DATA =====
                    int row = 4;
                    foreach (var item in data)
                    {
                        worksheet.Cell(row, 1).Value = item.PositionCode;
                        worksheet.Cell(row, 2).Value = item.PositionName;
                        worksheet.Cell(row, 3).Value = item.JobLevelCode;
                        worksheet.Cell(row, 4).Value = item.OrgStructureID.ToString() ?? string.Empty;
                        worksheet.Cell(row, 5).Value = item.ActAsHead ? "Yes" : "No";
                        worksheet.Cell(row, 6).Value = item.Objective ?? string.Empty;
                        worksheet.Cell(row, 7).Value = item.JobDescription ?? string.Empty;
                        worksheet.Cell(row, 8).Value = item.Status ? "Active" : "Inactive";
                        worksheet.Cell(row, 9).Value = item.ParentPositionCode ?? string.Empty;
                        worksheet.Cell(row, 10).Value = item.PositionPath ?? string.Empty;
                        row++;
                    }

                    // ===== BORDER =====
                    var lastDataRow = row - 1;
                    var range = worksheet.Range(3, 1, lastDataRow, headers.Length);
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    range.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // ===== AUTO FIT =====
                    worksheet.Columns(1, headers.Length).AdjustToContents();

                    // ===== EXPORT =====
                    using var stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    var bytes = stream.ToArray();

                    var dto = new AttachmentFileDto
                    {
                        FileBytes = bytes,
                        FileName = $"Positions.xlsx",
                        ContentType = MimeTypesConstants.VND_OPENXML_EXCEL
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);


                    return new ApiResponse<AttachmentFileDto>(System.Net.HttpStatusCode.OK, dto);
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
                                .Text("Position Master List")
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
                                    columns.RelativeColumn(1.2f); // Position Code
                                    columns.RelativeColumn(2f);   // Position Name
                                    columns.RelativeColumn(0.8f); // Job Level
                                    columns.RelativeColumn(0.8f); // Org ID
                                    columns.RelativeColumn(0.6f); // Head
                                });

                                // Header
                                table.Header(header =>
                                {
                                    string[] headers = {
                                        "Position Code", "Position Name", "Job Level",
                                        "Org ID", "Head"
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
                                        .Text(item.PositionCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.PositionName ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.JobLevelCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.OrgStructureID.ToString() ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.ActAsHead ? "Yes" : "No")
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
                        FileName = "Positions.pdf",
                        ContentType = MimeTypesConstants.PDF
                    };

                    return new ApiResponse<AttachmentFileDto>(System.Net.HttpStatusCode.OK, dto);
                }
                else
                {
                    return new ApiResponse<AttachmentFileDto>(System.Net.HttpStatusCode.BadRequest, default, "Type harus 'excel' atau 'pdf'");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<AttachmentFileDto>(System.Net.HttpStatusCode.BadRequest, default, "Gagal export position", ex.Message);
            }
        }
        #endregion
    }
}
