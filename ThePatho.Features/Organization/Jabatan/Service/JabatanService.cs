using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.Jabatan.Commands;
using ThePatho.Features.Organization.Jabatan.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ClosedXML.Excel;
using System.IO;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.Jabatan.Service
{
    public class JabatanService : IJabatanService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public JabatanService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<JabatanItemDto>> GetJabatan(GetJabatanCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Jabatan)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.JabatanCode),
                        q => q.WhereContains("JabatanCode", request.JabatanCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.JabatanName),
                        q => q.WhereContains("JabatanName", request.JabatanName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.JabatanDescription),
                        q => q.Where("JabatanDescription", request.JabatanDescription)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<JabatanDto>(query);

                var result = new JabatanItemDto
                {
                    DataOfRecords = data.Count(),
                    JabatanList = data.ToList(),
                };
                return new ApiResponse<JabatanItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JabatanItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<JabatanItemDto>> GetJabatanByCriteria(GetJabatanByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Jabatan)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.JabatanCode),
                        q => q.WhereContains("JabatanCode", request.JabatanCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.JabatanName),
                        q => q.WhereContains("JabatanName", request.JabatanName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.JabatanDescription),
                        q => q.Where("JabatanDescription", request.JabatanDescription)
                    );

                var data = await db.GetAsync<JabatanDto>(query);

                var result = new JabatanItemDto
                {
                    DataOfRecords = data.Count(),
                    JabatanList = data.ToList(),
                };
                return new ApiResponse<JabatanItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JabatanItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitJabatan(SubmitJabatanCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var ArgumentException = new List<string>();
               
                var existsQuery = new Query(TableOrganization.Jabatan)
                    .Where("JabatanCode", request.JabatanCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.Jabatan).AsInsert(new
                    {
                        JabatanCode = request.JabatanCode,
                        JabatanName = request.JabatanName,
                        JabatanDescription = request.JabatanDescription,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.Jabatan)
                        .Where("JabatanCode", request.JabatanCode)
                        .AsUpdate(new
                        {
                            JabatanName = request.JabatanName,
                            JabatanDescription = request.JabatanDescription,
                            IsDeleted = false,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.JabatanCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.JabatanCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteJabatan(DeleteJabatanCommand request)
        {
            try
            {
                if (request.JabatanId == 0)
                {
                    return new ApiResponse<JabatanDto>(
                         HttpStatusCode.BadRequest,
                         "Jabatan is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.Jabatan)
                                .Where("JabatanId", request.JabatanId)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete  successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete ", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<JabatanDto>> GetSingleJabatan(GetSingleJabatanCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Jabatan)
                    .Select("*")
                    .Where("JabatanId", request.JabatanId);

                var data = await db.FirstOrDefaultAsync<JabatanDto>(query);

                if (data == null)
                {
                    return new ApiResponse<JabatanDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<JabatanDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JabatanDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        
        public async Task<ApiResponse<AttachmentFileDto>> ExportJabatanAsync(string type)
        {
            
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var data = await db.Query(TableOrganization.Jabatan)
                    .Where("IsDeleted", false)
                    .OrderBy("JabatanCode")
                    .GetAsync<JabatanDto>();

                var fileName = $"jabatan_{DateTime.Now:yyyyMMddHHmmss}";
                byte[] fileBytes;
                string contentType;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("Jabatan");

                    // ===== TITLE =====
                    worksheet.Cell("A1").Value = "Jabatan List";
                    worksheet.Range("A1:C1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // ===== HEADER =====
                    worksheet.Cell(3, 1).Value = "Jabatan Code";
                    worksheet.Cell(3, 2).Value = "Jabatan Name";
                    worksheet.Cell(3, 3).Value = "Jabatan Description";

                    worksheet.Range(3, 1, 3, 3).Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));

                    // ===== DATA =====
                    var row = 4;
                    foreach (var item in data)
                    {
                        worksheet.Cell(row, 1).Value = item.JabatanCode;
                        worksheet.Cell(row, 2).Value = item.JabatanName;
                        worksheet.Cell(row, 3).Value = item.JabatanDescription;
                        row++;
                    }

                    // ===== AUTO FIT =====
                    worksheet.Columns(1, 3).AdjustToContents();

                    // ===== BORDER =====
                    var lastDataRow = row - 1;
                    var tableRange = worksheet.Range(3, 1, lastDataRow, 3);
                    tableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    tableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // ===== EXPORT FILE =====
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();

                    fileName = $"Jabatan.xlsx";
                    var dto = new AttachmentFileDto
                    {
                        FileBytes = fileBytes,
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

                            // ===== TITLE =====
                            page.Header().Element(header =>
                            {
                                header.AlignCenter()
                                    .PaddingBottom(10)
                                    .Text("Jabatan List")
                                    .SemiBold()
                                    .FontSize(18);
                                    //.FontColor("#007BFF"); // Biru profesional
                            });

                            // ===== CONTENT =====
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                // ===== COLUMN DEFINITIONS =====
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(120); // Code
                                    columns.ConstantColumn(200); // Name
                                    columns.RelativeColumn(2f);  // Description
                                });

                                var headerStyle = TextStyle.Default.FontSize(12).Bold();
                                var normalTextStyle = TextStyle.Default.FontSize(8);

                                // ===== TABLE HEADER =====
                                table.Header(header =>
                                {
                                    string[] headers = { "Jabatan Code", "Jabatan Name", "Description" };

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
                                        .Text(item.JabatanCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.JabatanName ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.JabatanDescription ?? "-")
                                        .Style(normalTextStyle);
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    var bytes = ms.ToArray();

                    var dto = new AttachmentFileDto
                    {
                        FileBytes = bytes,
                        FileName = "JabatanList.pdf",
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
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "Gagal export company profile", ex.Message);
            }
        }
        #endregion
    }
}
