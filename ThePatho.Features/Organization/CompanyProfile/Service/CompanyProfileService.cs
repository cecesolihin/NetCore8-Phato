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
using ThePatho.Features.Organization.CompanyBank.DTO;
using ThePatho.Features.Organization.CompanyProfile.Commands;
using ThePatho.Features.Organization.CompanyProfile.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Organization.CompanyProfile.Service
{
    public class CompanyProfileService : ICompanyProfileService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;
        private readonly ICurrentUserService currentUserService;

        public CompanyProfileService(DapperContext _dapperContext, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<CompanyProfileItemDto>> GetCompanyProfile(GetCompanyProfileCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.CompanyProfile)
                         .Select("*")
                         .When(
                             !string.IsNullOrWhiteSpace(request.FilterCompany),
                             q => q.Where(w => w
                                 .WhereContains("CompanyCode", request.FilterCompany)
                                 .OrWhereContains("CompanyName", request.FilterCompany)
                                 .OrWhereContains("CountryCode", request.FilterCompany)
                                 .OrWhereContains("City", request.FilterCompany)
                             )
                         );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<CompanyProfileDto>(query);

                var result = new CompanyProfileItemDto
                {
                    DataOfRecords = data.Count(),
                    CompanyProfileList = data.ToList(),
                };
                return new ApiResponse<CompanyProfileItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CompanyProfileItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportCompanyProfileAsync(string type)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.CompanyProfile)
                    .Select(
                        "CompanyCode",
                        "CompanyName",
                        "Phone",
                        "Email",
                        "Address",
                        "City",
                        "CountryCode"
                    )
                    .Where("IsDeleted", false)
                    .OrderBy("CompanyCode");

                var data = await db.GetAsync<CompanyProfileDto>(query);

                var exportType = (type ?? "").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(exportType)) exportType = "excel";

                if (exportType == "excel" || exportType == "xlsx")
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("CompanyProfile");

                    worksheet.Cell("A1").Value = "Company Profile List";
                    worksheet.Range("A1:G1").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    worksheet.Cell(3, 1).Value = "Company Code";
                    worksheet.Cell(3, 2).Value = "Company Name";
                    worksheet.Cell(3, 3).Value = "Phone";
                    worksheet.Cell(3, 4).Value = "Email";
                    worksheet.Cell(3, 5).Value = "Address";
                    worksheet.Cell(3, 6).Value = "City";
                    worksheet.Cell(3, 7).Value = "Country Code";

                    worksheet.Range(3, 1, 3, 7).Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));

                    var row = 4;
                    foreach (var item in data)
                    {
                        worksheet.Cell(row, 1).Value = item.CompanyCode;
                        worksheet.Cell(row, 2).Value = item.CompanyName;
                        worksheet.Cell(row, 3).Value = item.Phone;
                        worksheet.Cell(row, 4).Value = item.Email;
                        worksheet.Cell(row, 5).Value = item.Address;
                        worksheet.Cell(row, 6).Value = item.City;
                        worksheet.Cell(row, 7).Value = item.CountryCode;
                        row++;
                    }

                    worksheet.Columns(1, 7).AdjustToContents();

                    var lastDataRow = row - 1;
                    var tableRange = worksheet.Range(3, 1, lastDataRow, 7);
                    tableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    tableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    using var stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    var bytes = stream.ToArray();

                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(bytes),
                        FileName = "CompanyProfile.xlsx",
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
                                .Text("Company Profile List")
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
                                    columns.RelativeColumn(1f); // Company Code
                                    columns.RelativeColumn(1.5f); // Company Name
                                    columns.RelativeColumn(1f); // Phone
                                    columns.RelativeColumn(1.4f); // Email
                                    columns.RelativeColumn(2f); // Address
                                    columns.RelativeColumn(1.2f); // City
                                    columns.RelativeColumn(1f); // Country Code
                                });

                                // Header
                                table.Header(header =>
                                {
                                    string[] headers = {
                                        "Company Code", "Company Name", "Phone",
                                        "Email", "Address", "City", "Country Code"
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
                                        .Text(item.CompanyName ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.Phone ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.Email ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.Address ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.City ?? "-")
                                        .Style(normalTextStyle);

                                    table.Cell().Border(1).Padding(5).AlignMiddle()
                                        .Text(item.CountryCode ?? "-")
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
                        Base64Data = Convert.ToBase64String(bytes),
                        FileName = "CompanyProfile.pdf",
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

        public async Task<ApiResponse<CompanyProfileItemDto>> GetCompanyProfileByCriteria(GetCompanyProfileByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.CompanyProfile)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.CompanyCode),
                        q => q.WhereContains("CompanyCode", request.CompanyCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.CompanyName),
                        q => q.WhereContains("CompanyName", request.CompanyName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.CountryCode),
                        q => q.WhereContains("CountryCode", request.CountryCode)
                    );

                var data = await db.GetAsync<CompanyProfileDto>(query);

                var result = new CompanyProfileItemDto
                {
                    DataOfRecords = data.Count(),
                    CompanyProfileList = data.ToList(),
                };
                return new ApiResponse<CompanyProfileItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CompanyProfileItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitCompanyProfile(SubmitCompanyProfileCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                // Cek apakah CompanyCode sudah exists
                var existsQuery = new Query(TableOrganization.CompanyProfile)
                    .Where("CompanyCode", request.CompanyCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.CompanyProfile).AsInsert(new
                    {
                        CompanyCode = request.CompanyCode,
                        CompanyName = request.CompanyName,
                        Phone = request.Phone,
                        Fax = request.Fax,
                        Email = request.Email,
                        CompTaxNo = request.CompTaxNo,
                        BpjsTKCardNo = request.BpjsTkCardNo,
                        BpjsTKRegNo = request.BpjsTkRegNo,
                        BpjsKSCardNo = request.BpjsKsRegNo,
                        BpjsKSRegNo = request.BpjsKsCardNo,
                        Abbreviation = request.Abbreviation,
                        MainBusiness = request.MainBusiness,
                        Address = request.Address,
                        ZipCode = request.ZipCode,
                        Logo = request.Logo,
                        City = request.City,
                        CountryCode = request.CountryCode,
                        IsDeleted = request.IsDeleted,
                        TaxPenaltyByEmp = request.TaxPenaltyByEmp,
                        TaxPenaltyByComp = request.TaxPenaltyByComp,
                        TaxLocationID = request.TaxLocationId,
                        InsertedBy = currentUserService.GetUserName() ?? "system",
                        InsertedDate = DateTime.UtcNow,
                        GeneralSettings_ConfigGuid = request.GeneralSettingsConfigGuid,
                        BPJSTKLocation = request.BpjstkLocation,
                        BPJSKesLocation = request.BpjskesLocation,
                        Phone_UPIN = request.PhoneUpin,
                        Fax_UPIN = request.FaxUpin,
                        Email_UPIN = request.EmailUpin,
                        Abbreviation_UPIN = request.AbbreviationUpin,
                        MainBusiness_UPIN = request.MainBusinessUpin,
                        Address_UPIN = request.AddressUpin,
                        ZipCode_UPIN = request.ZipCodeUpin,
                        City_UPIN = request.CityUpin,
                        CountryCode_UPIN = request.CountryCodeUpin,
                        CheckedById = request.CheckedById,
                        Approved1Id = request.Approved1Id,
                        Approved2Id = request.Approved2Id,
                        PreparedId = request.PreparedId
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.CompanyProfile)
                        .Where("CompanyCode", request.CompanyCode)
                        .AsUpdate(new
                        {
                            CompanyName = request.CompanyName,
                            Phone = request.Phone,
                            Fax = request.Fax,
                            Email = request.Email,
                            CompTaxNo = request.CompTaxNo,
                            BpjsTKCardNo = request.BpjsTkCardNo,
                            BpjsTKRegNo = request.BpjsTkRegNo,
                            BpjsKSCardNo = request.BpjsKsCardNo,
                            BpjsKSRegNo = request.BpjsKsRegNo,
                            Abbreviation = request.Abbreviation,
                            MainBusiness = request.MainBusiness,
                            Address = request.Address,
                            ZipCode = request.ZipCode,
                            Logo = request.Logo,
                            City = request.City,
                            CountryCode = request.CountryCode,
                            IsDeleted = request.IsDeleted,
                            TaxPenaltyByEmp = request.TaxPenaltyByEmp,
                            TaxPenaltyByComp = request.TaxPenaltyByComp,
                            TaxLocationID = request.TaxLocationId,
                            ModifiedBy  = currentUserService.GetUserName() ?? "system",
                            ModifiedDate = DateTime.UtcNow,
                            GeneralSettings_ConfigGuid = request.GeneralSettingsConfigGuid,
                            BPJSTKLocation = request.BpjstkLocation,
                            BPJSKesLocation = request.BpjskesLocation,
                            Phone_UPIN = request.PhoneUpin,
                            Fax_UPIN = request.FaxUpin,
                            Email_UPIN = request.EmailUpin,
                            Abbreviation_UPIN = request.AbbreviationUpin,
                            MainBusiness_UPIN = request.MainBusinessUpin,
                            Address_UPIN = request.AddressUpin,
                            ZipCode_UPIN = request.ZipCodeUpin,
                            City_UPIN = request.CityUpin,
                            CountryCode_UPIN = request.CountryCodeUpin,
                            CheckedById = request.CheckedById,
                            Approved1Id = request.Approved1Id,
                            Approved2Id = request.Approved2Id,
                            PreparedId = request.PreparedId
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.CompanyCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.CompanyCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteCompanyProfile(DeleteCompanyProfileCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                // Cek apakah data exists sebelum delete
                var existsQuery = new Query(TableOrganization.CompanyProfile)
                                .Where("CompanyCode", request.CompanyCode)
                                .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);
                if (exists == 0)
                {
                    return new ApiResponse(HttpStatusCode.NotFound, $"Company with code '{request.CompanyCode}' not found.");
                }

                var deleteQuery = new Query(TableOrganization.CompanyProfile)
                                .Where("CompanyCode", request.CompanyCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);

                if (deleteResult == 0)
                {
                    return new ApiResponse(HttpStatusCode.NotFound, $"Company with code '{request.CompanyCode}' not found.");
                }

                return new ApiResponse(HttpStatusCode.OK, $"Delete company '{request.CompanyCode}' successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(
                    HttpStatusCode.BadRequest,
                    $"Failed to delete company '{request.CompanyCode}'",
                    ex.Message
                );
            }
        }

        public async Task<ApiResponse<CompanyProfileDto>> GetSingleCompanyProfile(GetSingleCompanyProfileCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.CompanyProfile)
                    .Select("*")
                    .Where("CompanyCode", request.CompanyCode);

                var data = await db.FirstOrDefaultAsync<CompanyProfileDto>(query);
                if (data == null)
                {
                    return new ApiResponse<CompanyProfileDto>(
                        HttpStatusCode.NotFound,
                        "Company Code data not found."
                    );
                }
                return new ApiResponse<CompanyProfileDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CompanyProfileDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion
    }
}
