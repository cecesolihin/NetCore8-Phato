using SqlKata;
using SqlKata.Execution;
using System;
using System.IO;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.CompanyBank.Commands;
using ThePatho.Features.Organization.CompanyBank.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.CompanyBank.Service
{
    public class CompanyBankService : ICompanyBankService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public CompanyBankService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<CompanyBankItemDto>> GetCompanyBank(GetCompanyBankCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.CompanyBank)
                            .Select("*")
                            .When(
                                !string.IsNullOrWhiteSpace(request.FilterCompanyCode),
                                q => q.WhereContains("CompanyCode", request.FilterCompanyCode)
                            )
                            .When(
                                !string.IsNullOrWhiteSpace(request.FilterBankCode),
                                q => q.WhereContains("BankCode", request.FilterBankCode)
                            )
                            .When(
                                !string.IsNullOrWhiteSpace(request.FilterBranch),
                                q => q.WhereContains("Branch", request.FilterBranch)
                            )
                            .When(
                                !string.IsNullOrWhiteSpace(request.FilterAccountName),
                                q => q.WhereContains("AccountName", request.FilterAccountName)
                            );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<CompanyBankDto>(query);

                var result = new CompanyBankItemDto
                {
                    DataOfRecords = data.Count(),
                    CompanyBankList = data.ToList(),
                };
                return new ApiResponse<CompanyBankItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CompanyBankItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportCompanyBankAsync(string type)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.CompanyBank)
                    .Select(
                        "CompanyCode",
                        "BankCode",
                        "Branch",
                        "AccountNo",
                        "AccountName",
                        "IsDefault"
                    )
                    .Where("IsDeleted", false)
                    .OrderBy("CompanyCode");

                var data = await db.GetAsync<CompanyBankDto>(query);

                var exportType = (type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(exportType)) exportType = "excel";

                // Excel export
                if (exportType == "excel" || exportType == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("CompanyBank");

                    // Title
                    worksheet.Cell("A1").Value = "Company Bank List";
                    worksheet.Range("A1:F1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // Header
                    worksheet.Cell(3, 1).Value = "Company Code";
                    worksheet.Cell(3, 2).Value = "Bank Code";
                    worksheet.Cell(3, 3).Value = "Branch";
                    worksheet.Cell(3, 4).Value = "Account No";
                    worksheet.Cell(3, 5).Value = "Account Name";
                    worksheet.Cell(3, 6).Value = "Is Default";

                    worksheet.Range(3, 1, 3, 6).Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));

                    // Data
                    var row = 4;
                    foreach (var item in data)
                    {
                        worksheet.Cell(row, 1).Value = item.CompanyCode;
                        worksheet.Cell(row, 2).Value = item.BankCode;
                        worksheet.Cell(row, 3).Value = item.Branch;
                        worksheet.Cell(row, 4).Value = item.AccountNo;
                        worksheet.Cell(row, 5).Value = item.AccountName;
                        worksheet.Cell(row, 6).Value = item.IsDefault.Value ? "Yes" : "No";
                        row++;
                    }

                    worksheet.Columns(1, 6).AdjustToContents();

                    var lastDataRow = row - 1;
                    var tableRange = worksheet.Range(3, 1, lastDataRow, 6);
                    tableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    tableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    using var stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    var bytes = stream.ToArray();

                    var dto = new AttachmentFileDto
                    {
                        FileBytes = bytes,
                        FileName = "CompanyBank.xlsx",
                        ContentType = MimeTypesConstants.VND_OPENXML_EXCEL
                    };

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, dto);
                }
                // PDF export
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
                                .Text("Company Bank List")
                                .SemiBold()
                                .FontSize(16)
                                .FontColor(Colors.Black);

                            // Define text styles
                            var headerStyle = TextStyle.Default.FontSize(12).Bold();
                            var boldTextStyle = TextStyle.Default.FontSize(8).Bold();
                            var normalTextStyle = TextStyle.Default.FontSize(8);

                            // Table
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                // Column definitions
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1.2f); // Company Code
                                    columns.RelativeColumn(1f);   // Bank Code
                                    columns.RelativeColumn(1.4f); // Branch
                                    columns.RelativeColumn(1.2f); // Account No
                                    columns.RelativeColumn(1.6f); // Account Name
                                    columns.RelativeColumn(0.8f); // Is Default
                                });

                              
                                // Header
                                table.Header(header =>
                                {
                                    string[] headers = {
                                        "Company Code", "Bank Code", "Branch",
                                        "Account No", "Account Name", "Is Default"
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
                                        .Text(item.CompanyCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.BankCode ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.Branch ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.AccountNo ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.AccountName ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.IsDefault == true ? "Yes" : "No")
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
                        FileName = "CompanyBank.pdf",
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
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, default, "Gagal export company bank", ex.Message);
            }
        }

        public async Task<ApiResponse<CompanyBankItemDto>> GetCompanyBankByCriteria(GetCompanyBankByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.CompanyBank)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterCompanyCode),
                        q => q.WhereContains("CompanyCode", request.FilterCompanyCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterBankCode),
                        q => q.WhereContains("BankCode", request.FilterBankCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterBranch),
                        q => q.WhereContains("Branch", request.FilterBranch)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterAccountName),
                        q => q.WhereContains("AccountName", request.FilterAccountName)
                    );

                var data = await db.GetAsync<CompanyBankDto>(query);

                var result = new CompanyBankItemDto
                {
                    DataOfRecords = data.Count(),
                    CompanyBankList = data.ToList(),
                };
                return new ApiResponse<CompanyBankItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CompanyBankItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitCompanyBank(SubmitCompanyBankCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var argument = new List<string>();

        
                var companyExistsQuery = new Query(TableOrganization.CompanyProfile)
                    .Where("CompanyCode", request.CompanyCode)
                    .SelectRaw("COUNT(1)");

                var companyExists = await db.ExecuteScalarAsync<int>(companyExistsQuery);
                if (companyExists == 0)
                    argument.Add($"Company Code '{request.CompanyCode}' does not exist.");

                
                // Cek duplikat untuk insert (AccountNo harus unique per CompanyCode)
                if (request.CompanyBankId == null || request.CompanyBankId == 0)
                {
                    if (!string.IsNullOrWhiteSpace(request.AccountNo))
                    {
                        var duplicateQuery = new Query(TableOrganization.CompanyBank)
                            .Where("CompanyCode", request.CompanyCode)
                            .Where("AccountNo", request.AccountNo)
                            .Where("IsDeleted", false)
                            .SelectRaw("COUNT(1)");

                        var duplicateExists = await db.ExecuteScalarAsync<int>(duplicateQuery);
                        if (duplicateExists > 0)
                            argument.Add($"Account No '{request.AccountNo}' already exists for this company.");
                    }
                }

                if (argument.Any())
                {
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.CompanyCode}", string.Join(", ", argument.ToArray()));
                }

                if (request.CompanyBankId == null || request.CompanyBankId == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.CompanyBank).AsInsert(new
                    {
                        CompanyCode = request.CompanyCode,
                        BankCode = request.BankCode,
                        Branch = request.Branch,
                        AccountNo = request.AccountNo,
                        AccountName = request.AccountName,
                        IsDeleted = request.IsDeleted,
                        IsDefault = request.IsDefault,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                    return new ApiResponse(HttpStatusCode.OK, $"Insert Company Bank successfully");
                }
                else
                {
                    
                    var existsQuery = new Query(TableOrganization.CompanyBank)
                        .Where("CompanyBankId", request.CompanyBankId)
                        .SelectRaw("COUNT(1)");

                    var exists = await db.ExecuteScalarAsync<int>(existsQuery);
                    if (exists == 0)
                        argument.Add($"Company Bank with ID {request.CompanyBankId} not found.");

                    if (!string.IsNullOrWhiteSpace(request.AccountNo))
                    {
                        var duplicateQuery = new Query(TableOrganization.CompanyBank)
                            .Where("CompanyCode", request.CompanyCode)
                            .Where("AccountNo", request.AccountNo)
                            .Where("IsDeleted", false)
                            .WhereNot("CompanyBankId", request.CompanyBankId)
                            .SelectRaw("COUNT(1)");

                        var duplicateExists = await db.ExecuteScalarAsync<int>(duplicateQuery);
                        if (duplicateExists > 0)
                            argument.Add($"Account No '{request.AccountNo}' already exists for this company.");
                    }

                    if (argument.Any())
                    {
                        return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.CompanyCode}", string.Join(", ", argument.ToArray()));
                    }

                    // Update
                    var updateQuery = new Query(TableOrganization.CompanyBank)
                        .Where("CompanyBankId", request.CompanyBankId)
                        .AsUpdate(new
                        {
                            CompanyCode = request.CompanyCode,
                            BankCode = request.BankCode,
                            Branch = request.Branch,
                            AccountNo = request.AccountNo,
                            AccountName = request.AccountName,
                            IsDeleted = request.IsDeleted,
                            IsDefault = request.IsDefault,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                    return new ApiResponse(HttpStatusCode.OK, $"Update Company Bank ID {request.BankCode} successfully");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse(
                    HttpStatusCode.BadRequest,
                    $"Failed to {request.Action} Company Bank",
                    ex.Message
                );
            }
        }
        public async Task<ApiResponse> DeleteCompanyBank(DeleteCompanyBankCommand request)
        {
            var existingRecord = new CompanyBankDto();
            try
            {
                if (request.CompanyBankId <= 0)
                    return new ApiResponse(HttpStatusCode.NotFound, "CompanyBank is not found");

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                // Cek dulu data-nya
                existingRecord = await db.Query(TableOrganization.CompanyBank)
                    .Select("CompanyCode", "BankCode", "Branch")
                    .Where("CompanyBankId", request.CompanyBankId)
                    .FirstOrDefaultAsync<CompanyBankDto>();

                if (existingRecord == null)
                {
                    return new ApiResponse(HttpStatusCode.NotFound,
                        $"CompanyBank record not found for the specified criteria.");
                }

                // Ubah dari delete menjadi update
                var updateQuery = new Query(TableOrganization.CompanyBank)
                    .Where("CompanyBankId", request.CompanyBankId)
                    .AsUpdate(new
                    {
                        IsDeleted = true,
                        ModifiedBy = "system",
                        ModifiedDate = DateTime.UtcNow
                    });

                var updateResult = await db.ExecuteAsync(updateQuery);


                return new ApiResponse(HttpStatusCode.OK, $"Delete CompanyBank ID {existingRecord.BankCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete CompanyBank ID {existingRecord.BankCode}", ex.Message);
            }

        }

        public async Task<ApiResponse<CompanyBankDto>> GetSingleCompanyBank(GetSingleCompanyBankCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.CompanyBank)
                         .Select("*")
                         .Where("CompanyBankId", request.CompanyBankId);

                var data = await db.FirstOrDefaultAsync<CompanyBankDto>(query);

                if (data == null)
                {
                    return new ApiResponse<CompanyBankDto>(
                        HttpStatusCode.NotFound,
                        "Company bank data not found."
                    );
                }

                return new ApiResponse<CompanyBankDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CompanyBankDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion
    }
}
