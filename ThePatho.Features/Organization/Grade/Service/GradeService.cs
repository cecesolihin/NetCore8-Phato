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
using ThePatho.Features.Organization.Grade.Commands;
using ThePatho.Features.Organization.Grade.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Organization.Grade.Service
{
    public class GradeService : IGradeService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;
        private readonly ICurrentUserService currentUserService;

        public GradeService(DapperContext _dapperContext, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        
        public async Task<ApiResponse<GradeItemDto>> GetGrade(GetGradeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Grade)
                        .Select("*")
                         .Where("IsDeleted", false)
                        .When(
                            !string.IsNullOrWhiteSpace(request.FilterGrade),
                            q => q.Where(w => w
                                .WhereContains("GradeCode", request.FilterGrade)
                                .OrWhereContains("GradeName", request.FilterGrade)
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

                var data = await db.GetAsync<GradeDto>(query);

                var result = new GradeItemDto
                {
                    DataOfRecords = data.Count(),
                    GradeList = data.ToList(),
                };
                return new ApiResponse<GradeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<GradeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<GradeItemDto>> GetGradeByCriteria(GetGradeByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Grade)
                    .Select("*")
                    .Where("IsDeleted", false)
                    .When(
                        !string.IsNullOrWhiteSpace(request.GradeCode),
                        q => q.WhereContains("GradeCode", request.GradeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.GradeName),
                        q => q.WhereContains("GradeName", request.GradeName)
                    );
                var data = await db.GetAsync<GradeDto>(query);

                var result = new GradeItemDto
                {
                    DataOfRecords = data.Count(),
                    GradeList = data.ToList(),
                };
                return new ApiResponse<GradeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<GradeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitGrade(SubmitGradeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var ArgumentException = new List<string>();
                
                // Cek apakah GradeCode sudah exists
                var existsQuery = new Query(TableOrganization.Grade)
                    .Where("GradeCode", request.GradeCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.Grade).AsInsert(new
                    {
                        GradeCode = request.GradeCode,
                        GradeName = request.GradeName,
                        IsActive = request.IsActive,
                        SortOrder = request.SortOrder,
                        Remarks = request.Remarks,
                        IsDeleted = false,
                        InsertedBy = currentUserService.GetUserName() ?? "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.Grade)
                        .Where("GradeCode", request.GradeCode)
                        .AsUpdate(new
                        {
                            GradeName = request.GradeName,
                            IsActive = request.IsActive,
                            SortOrder = request.SortOrder,
                            Remarks = request.Remarks,
                            IsDeleted = false,
                            ModifiedBy  = currentUserService.GetUserName() ?? "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.GradeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.GradeCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteGrade(DeleteGradeCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.GradeCode))
                {
                    return new ApiResponse<GradeDto>(
                        HttpStatusCode.BadRequest,
                        "Grade is required"
                    );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                // Soft delete: UPDATE IsDeleted = true
                var updateResult = await db
                    .Query(TableOrganization.Grade)
                    .Where("GradeCode", request.GradeCode)
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
                        $"Grade {request.GradeCode} not found"
                    );
                }

                return new ApiResponse(
                    HttpStatusCode.OK,
                    $"Delete {request.GradeCode} successfully"
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.GradeCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<GradeDto>> GetSingleGrade(GetSingleGradeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Grade)
                    .Select("*")
                    .Where("GradeCode", request.GradeCode);

                var data = await db.FirstOrDefaultAsync<GradeDto>(query);

                if (data == null)
                {
                    return new ApiResponse<GradeDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<GradeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<GradeDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse<AttachmentFileDto>> DownloadGradeTemplate()
        {
            try
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("TEMPLATE");

                // ===== HEADER =====
                worksheet.Cell(1, 1).Value = "GradeCode";
                worksheet.Cell(1, 2).Value = "GradeName";
                worksheet.Cell(1, 3).Value = "SortOrder";
                worksheet.Cell(1, 4).Value = "Status";
                worksheet.Cell(1, 5).Value = "Remarks";

                // ===== STYLING =====
                // Kolom wajib (A & B)
                var requiredHeader = worksheet.Range(1, 1, 1, 2);
                requiredHeader.Style.Fill.BackgroundColor = XLColor.DarkRed;
                requiredHeader.Style.Font.FontColor = XLColor.White;
                requiredHeader.Style.Font.Bold = true;

                // Kolom opsional (C�E)
                var optionalHeader = worksheet.Range(1, 3, 1, 5);
                optionalHeader.Style.Fill.BackgroundColor = XLColor.BlueGray;
                optionalHeader.Style.Font.FontColor = XLColor.White;
                optionalHeader.Style.Font.Bold = true;

                // Freeze baris header
                worksheet.SheetView.FreezeRows(1);

                // ===== WIDTH SETTING =====
                worksheet.Column(1).Width = 20; // GradeCode
                worksheet.Column(2).Width = 30; // GradeName
                worksheet.Column(3).Width = 10; // Sort
                worksheet.Column(4).Width = 12; // Status
                worksheet.Column(5).Width = 40; // Remarks

                // ===== DATA VALIDATION (Dropdown) =====
                // Hanya izinkan 1 atau 0 di kolom Status
                var statusRange = worksheet.Range("D2:D100"); // 100 baris pertama
                var validation = statusRange.CreateDataValidation();
                validation.IgnoreBlanks = true;
                validation.InCellDropdown = true;
                validation.AllowedValues = XLAllowedValues.List;
                validation.List("1,0"); // Hanya 1 dan 0
                validation.InputTitle = "Status";
                validation.InputMessage = "Pilih 1 (Active) atau 0 (Inactive)";
                validation.ErrorTitle = "Nilai tidak valid";
                validation.ErrorMessage = "Masukkan hanya 1 atau 0 untuk kolom Status.";

                // ===== TABLE / FILTER =====
                worksheet.Range("A1:E1").SetAutoFilter();

                // ===== EXPORT =====
                using var stream = new MemoryStream();
                workbook.SaveAs(stream);
                var bytes = stream.ToArray();

                var dto = new AttachmentFileDto
                {
                    Base64Data = Convert.ToBase64String(bytes),
                    FileName = "GradeTemplate.xlsx",
                    ContentType = MimeTypesConstants.VND_OPENXML_EXCEL
                };

                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);
            }
            catch (Exception ex)
            {
                return new ApiResponse<AttachmentFileDto>(
                    HttpStatusCode.BadRequest,
                    "Failed to generate Grade template.",
                    ex.Message
                );
            }
        }

        public async Task<ApiResponse<GradeUploadResultDto>> UploadGradeTemplate(UploadGradeTemplateCommand request)
        {
            try
            {
                if (request.FileBytes == null || request.FileBytes.Length == 0)
                {
                    return new ApiResponse<GradeUploadResultDto>(HttpStatusCode.BadRequest, "File kosong atau tidak ada.");
                }

                if (!string.IsNullOrWhiteSpace(request.FileName) && !request.FileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    return new ApiResponse<GradeUploadResultDto>(HttpStatusCode.BadRequest, "Format file harus .xlsx");
                }

                var result = new GradeUploadResultDto();

                using var stream = new MemoryStream(request.FileBytes);
                using var workbook = new XLWorkbook(stream);
                var worksheet = workbook.Worksheets.FirstOrDefault(w => w.Name.Equals("TEMPLATE", StringComparison.OrdinalIgnoreCase))
                                 ?? workbook.Worksheets.FirstOrDefault();

                if (worksheet == null)
                {
                    return new ApiResponse<GradeUploadResultDto>(HttpStatusCode.BadRequest, "Worksheet tidak ditemukan dalam file.");
                }

                var lastRow = worksheet.LastRowUsed()?.RowNumber() ?? 1;
                if (lastRow <= 1)
                {
                    return new ApiResponse<GradeUploadResultDto>(HttpStatusCode.BadRequest, "Tidak ada data yang dapat diproses.");
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                for (int row = 2; row <= lastRow; row++)
                {
                    string gradeCode = worksheet.Cell(row, 1).GetString().Trim();
                    string gradeName = worksheet.Cell(row, 2).GetString().Trim();
                    string sortRaw = worksheet.Cell(row, 3).GetString().Trim();
                    string status = worksheet.Cell(row, 4).GetString().Trim();
                    string remarks = worksheet.Cell(row, 5).GetString().Trim();

                    var error = new GradeUploadErrorDto
                    {
                        RowNumber = row,
                        GradeCode = gradeCode,
                        GradeName = gradeName,
                        Status = status,
                        Remarks = remarks
                    };

                    try
                    {
                        if (string.IsNullOrWhiteSpace(gradeCode))
                        {
                            error.Message = "GradeCode wajib diisi";
                            result.Errors.Add(error);
                            continue;
                        }
                        if (string.IsNullOrWhiteSpace(gradeName))
                        {
                            error.Message = "GradeName wajib diisi";
                            result.Errors.Add(error);
                            continue;
                        }

                        int? sort = null;
                        if (!string.IsNullOrWhiteSpace(sortRaw))
                        {
                            if (int.TryParse(sortRaw, out var parsed))
                                sort = parsed;
                            else
                            {
                                error.Message = "Kolom Sort harus angka";
                                result.Errors.Add(error);
                                continue;
                            }
                        }

                        // Cek eksistensi berdasarkan GradeCode
                        var existsQuery = new Query(TableOrganization.Grade)
                            .Where("GradeCode", gradeCode)
                            .SelectRaw("COUNT(1)");
                        var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                        if (exists == 0)
                        {
                            var insertQuery = new Query(TableOrganization.Grade).AsInsert(new
                            {
                                GradeCode = gradeCode,
                                GradeName = gradeName,
                                Status = status,
                                Order = sort,
                                Remarks = remarks,
                                IsDeleted = false,
                                InsertedBy = currentUserService.GetUserName() ?? "system",
                                InsertedDate = DateTime.UtcNow
                            });
                            await db.ExecuteAsync(insertQuery);
                            result.InsertedCount++;
                        }
                        else
                        {
                            var updateQuery = new Query(TableOrganization.Grade)
                                .Where("GradeCode", gradeCode)
                                .AsUpdate(new
                                {
                                    GradeName = gradeName,
                                    Status = status,
                                    Order = sort,
                                    Remarks = remarks,
                                    IsDeleted = false,
                                    ModifiedBy  = currentUserService.GetUserName() ?? "system",
                                    ModifiedDate = DateTime.UtcNow
                                });
                            await db.ExecuteAsync(updateQuery);
                            result.UpdatedCount++;
                        }
                    }
                    catch (Exception exRow)
                    {
                        error.Message = exRow.Message;
                        result.Errors.Add(error);
                    }
                }

                var statusCode = HttpStatusCode.OK;
                var message = $"Upload selesai. Insert: {result.InsertedCount}, Update: {result.UpdatedCount}, Error: {result.Errors.Count}";
                return new ApiResponse<GradeUploadResultDto>(statusCode, result, message);
            }
            catch (Exception ex)
            {
                return new ApiResponse<GradeUploadResultDto>(HttpStatusCode.BadRequest, default, "Gagal memproses file upload.", ex.Message);
            }
        }
        public async Task<ApiResponse<AttachmentFileDto>> ExportGradeAsync(ExportGradeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Grade)
                    .Select("*")
                    .OrderBy("SortOrder");

                var data = await db.GetAsync<GradeDto>(query);

                var type = (request.Type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(type)) type = "excel";

                if (type == "excel" || type == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("Grades");

                    // ===== TITLE =====
                    worksheet.Cell("A1").Value = "Grade List";
                    worksheet.Range("A1:F1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // ===== HEADER =====
                    worksheet.Cell(3, 1).Value = "No";
                    worksheet.Cell(3, 2).Value = "Grade Code";
                    worksheet.Cell(3, 3).Value = "Grade Name";
                    worksheet.Cell(3, 4).Value = "IsActive";
                    worksheet.Cell(3, 5).Value = "SortOrder";
                    worksheet.Cell(3, 6).Value = "Remarks";

                    worksheet.Range(3, 1, 3, 6).Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));

                    // ===== DATA =====
                    var row = 4;
                    int no = 1;

                    foreach (var g in data)
                    {
                        worksheet.Cell(row, 1).Value = no++;
                        worksheet.Cell(row, 2).Value = g.GradeCode;
                        worksheet.Cell(row, 3).Value = g.GradeName;
                        worksheet.Cell(row, 4).Value = g.IsActive ? "Active" : "Inactive";
                        worksheet.Cell(row, 5).Value = g.SortOrder;
                        worksheet.Cell(row, 6).Value = g.Remarks;
                        row++;
                    }

                    // ===== AUTO FIT KOLUMN =====
                    worksheet.Columns(1, 6).AdjustToContents();

                    // ===== BORDER =====
                    var lastDataRow = row - 1;
                    var tableRange = worksheet.Range(3, 1, lastDataRow, 6);
                    tableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    tableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // ===== EXPORT FILE =====
                    using var stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    var bytes = stream.ToArray();

                    // DTO hasil export
                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(bytes),
                        FileName = "GradeList.xlsx",
                        ContentType = MimeTypesConstants.VND_OPENXML_EXCEL
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);

                }

                else if (type == "pdf")
                {
                    var doc = Document.Create(container =>
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
                                    .Text("Grade List Data")
                                    .SemiBold()
                                    .FontSize(18)
                                    .FontColor("#007BFF"); // Biru elegan
                            });

                            // ===== CONTENT =====
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                // ===== COLUMN DEFINITIONS =====
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(40);   // No
                                    columns.ConstantColumn(100);  // Grade Code
                                    columns.RelativeColumn(2f);   // Grade Name
                                    columns.ConstantColumn(80);   // Status
                                    columns.ConstantColumn(60);   // Order
                                    columns.RelativeColumn(2f);   // Remarks
                                });

                                var headerStyle = TextStyle.Default.FontSize(12).Bold();
                                var normalTextStyle = TextStyle.Default.FontSize(8);

                                // ===== TABLE HEADER =====
                                table.Header(header =>
                                {
                                    string[] headers = { "No", "Grade Code", "Grade Name", "Status", "SortOrder", "Remarks" };

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
                                var no = 1;
                                foreach (var g in data)
                                {
                                    table.Cell().Border(1).Padding(5).AlignCenter().Text(no.ToString()).Style(normalTextStyle);
                                    table.Cell().Border(1).Padding(5).AlignCenter().Text(g.GradeCode ?? "-").Style(normalTextStyle);
                                    table.Cell().Border(1).Padding(5).Text(g.GradeName ?? "-").Style(normalTextStyle);
                                    table.Cell().Border(1).Padding(5).AlignCenter().Text(g.IsActive ?  "Active" : "Inactive").Style(normalTextStyle);
                                    table.Cell().Border(1).Padding(5).AlignCenter().Text(g.SortOrder.ToString()).Style(normalTextStyle);
                                    table.Cell().Border(1).Padding(5).Text(g.Remarks ?? "-").Style(normalTextStyle);
                                    no++;
                                }
                            });
                        });
                    });

                    var bytes = doc.GeneratePdf();
                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(bytes),
                        FileName = "Grades.pdf",
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
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "Gagal export grade", ex.Message);
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportGradeAsyncOLD(ExportGradeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Grade)
                    .Select("GradeCode", "GradeName", "Status", "SortOrder", "Remarks")
                    .OrderBy("SortOrder");

                var data = await db.GetAsync<GradeDto>(query);

                var type = (request.Type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(type)) type = "excel";

                if (type == "excel" || type == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("Grades");

                    // ===== TITLE =====
                    worksheet.Cell("A1").Value = "GRADE MASTER LIST";
                    worksheet.Range("A1:E1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Font.SetFontColor(XLColor.White)
                       // .Fill.SetBackgroundColor(XLColor.FromHtml("#4472C4"))
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                    worksheet.Row(1).Height = 25;

                    // ===== HEADER =====
                    worksheet.Cell(2, 1).Value = "GradeCode";
                    worksheet.Cell(2, 2).Value = "GradeName";
                    worksheet.Cell(2, 3).Value = "Status";
                    worksheet.Cell(2, 4).Value = "SortOrder";
                    worksheet.Cell(2, 5).Value = "Remarks";

                    var headerRange = worksheet.Range(2, 1, 2, 5);
                    headerRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#b5b9ba");
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Font.FontColor = XLColor.White;
                    headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    headerRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    headerRange.Style.Border.OutsideBorderColor = XLColor.Gray;

                    // ===== DATA =====
                    int startRow = 3;
                    int row = startRow;
                    foreach (var g in data)
                    {
                        worksheet.Cell(row, 1).Value = g.GradeCode;
                        worksheet.Cell(row, 2).Value = g.GradeName;
                        worksheet.Cell(row, 3).Value = g.IsActive ? "Active" :"Non Active";
                        worksheet.Cell(row, 4).Value = g.SortOrder;
                        worksheet.Cell(row, 5).Value = g.Remarks;
                        row++;
                    }

                    //worksheet.Column(1).Width = 6;   // No
                    worksheet.Column(1).Width = 15;  // GradeCode
                    worksheet.Column(2).Width = 30;  // GradeName
                    worksheet.Column(3).Width = 10;  // Status
                    worksheet.Column(4).Width = 8;   // Order
                    worksheet.Column(5).Width = 40;  // Remarks

                    var dataRange = worksheet.Range(startRow, 1, row - 1, 5);
                    dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Hair;
                    dataRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    dataRange.Style.Font.FontSize = 11;

                    // ===== TABLE BOUNDARY LINE =====
                    var fullTable = worksheet.Range(2, 1, row - 1, 5);
                    fullTable.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;

                    // ===== FREEZE HEADER =====
                    worksheet.SheetView.FreezeRows(2);

                    // ===== AUTO WIDTH =====
                    worksheet.Columns(1, 5).AdjustToContents();

                    // ===== FOOTER INFO (opsional) =====
                    worksheet.Cell(row + 1, 1).Value = $"Generated on: {DateTime.Now:dd MMM yyyy HH:mm}";
                    worksheet.Cell(row + 1, 1).Style.Font.Italic = true;
                    worksheet.Cell(row + 1, 1).Style.Font.FontColor = XLColor.Gray;

                    // ===== EXPORT =====
                    using var stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    var bytes = stream.ToArray();

                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(bytes),
                    FileName = "Grades.xlsx",
                    ContentType = MimeTypesConstants.VND_OPENXML_EXCEL
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);
                }
                else if (type == "pdf")
                {
                    // Build PDF using QuestPDF

                    var doc = Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Margin(30);
                            page.Size(PageSizes.A4);

                            // ===== HEADER TITLE =====
                            page.Header().Element(header =>
                            {
                                header
                                    .AlignCenter()
                                    .PaddingBottom(10)
                                    .Text("GRADE MASTER REPORT")
                                    .FontSize(20)
                                    .Bold()
                                    .FontColor(Colors.Blue.Medium);
                                 
                            });

                            // ===== CONTENT =====
                            page.Content().Element(content =>
                            {
                                content.Table(table =>
                                {
                                    // Kolom layout
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.ConstantColumn(80); // GradeCode
                                        columns.RelativeColumn(2);  // GradeName
                                        columns.ConstantColumn(60); // Status
                                        columns.ConstantColumn(60); // Order
                                        columns.RelativeColumn(3);  // Remarks
                                    });

                                    // ===== TABLE HEADER =====
                                    table.Header(header =>
                                    {
                                        static void HeaderCell(IContainer container, string text)
                                        {
                                            container
                                                .Background(Colors.Grey.Lighten2)
                                                .Border(0.5f)
                                                .Padding(5)
                                                .Text(text)
                                                .Bold()
                                                .FontColor(Colors.BlueGrey.Darken3)
                                                .FontSize(11)
                                                .AlignCenter();
                                        }

                                        HeaderCell(header.Cell(), "GradeCode");
                                        HeaderCell(header.Cell(), "GradeName");
                                        HeaderCell(header.Cell(), "Status");
                                        HeaderCell(header.Cell(), "SortOrder");
                                        HeaderCell(header.Cell(), "Remarks");
                                    });

                                    // ===== TABLE ROWS =====
                                    int rowIndex = 0;
                                    foreach (var g in data)
                                    {
                                        var bgColor = (rowIndex++ % 2 == 0)
                                            ? Colors.White
                                            : Colors.Grey.Lighten4; // Zebra stripe

                                        static void BodyCell(IContainer container, string text, string bg)
                                        {
                                            container
                                                .Background(bg)
                                                .Border(0.5f)
                                                .Padding(5)
                                                .Text(text)
                                                .FontSize(10)
                                                .FontColor(Colors.Grey.Darken3)
                                                .AlignLeft();
                                        }

                                        BodyCell(table.Cell(), g.GradeCode ?? "-", bgColor);
                                        BodyCell(table.Cell(), g.GradeName ?? "-", bgColor);
                                        BodyCell(table.Cell(), g.IsActive ? "Active":"Inactive", bgColor);
                                        BodyCell(table.Cell(), g.SortOrder.ToString(), bgColor);
                                        BodyCell(table.Cell(), g.Remarks ?? "-", bgColor);
                                    }
                                });
                            });

                            // ===== FOOTER =====
                            page.Footer().AlignRight().Text(txt =>
                            {
                                txt.Span("Generated on: ").FontColor(Colors.Grey.Darken1);
                                txt.Span($"{DateTime.Now:dd MMM yyyy HH:mm}").SemiBold().FontColor(Colors.Blue.Medium);
                            });
                        });
                    });

                    // ===== GENERATE =====
                    var bytes = doc.GeneratePdf();

                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(bytes),
                    FileName = "Grades.pdf",
                    ContentType = MimeTypesConstants.PDF
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);
                }
                else
                {
                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "type harus 'excel' atau 'pdf'");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "Gagal export grade", ex.Message);
            }
        }

        #endregion
    }
}
