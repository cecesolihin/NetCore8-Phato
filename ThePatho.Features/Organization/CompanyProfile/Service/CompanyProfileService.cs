using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.CompanyBank.DTO;
using ThePatho.Features.Organization.CompanyProfile.Commands;
using ThePatho.Features.Organization.CompanyProfile.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.CompanyProfile.Service
{
    public class CompanyProfileService : ICompanyProfileService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public CompanyProfileService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
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
                        !string.IsNullOrWhiteSpace(request.FilterCompanyCode),
                        q => q.WhereContains("CompanyCode", request.FilterCompanyCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterCompanyName),
                        q => q.WhereContains("CompanyName", request.FilterCompanyName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterCountryCode),
                        q => q.WhereContains("CountryCode", request.FilterCountryCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterCity),
                        q => q.WhereContains("City", request.FilterCity)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<CompanyProfileDto>(query);

                var result = new CompanyProfileItemDto
                {
                    DataOfRecords = data.ToList().Count,
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

        public async Task<ApiResponse<CompanyProfileItemDto>> GetCompanyProfileByCriteria(GetCompanyProfileByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.CompanyProfile)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterCompanyCode),
                        q => q.WhereContains("CompanyCode", request.FilterCompanyCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterCompanyName),
                        q => q.WhereContains("CompanyName", request.FilterCompanyName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterCountryCode),
                        q => q.WhereContains("CountryCode", request.FilterCountryCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterCity),
                        q => q.WhereContains("City", request.FilterCity)
                    );

                var data = await db.GetAsync<CompanyProfileDto>(query);

                var result = new CompanyProfileItemDto
                {
                    DataOfRecords = data.ToList().Count,
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

                var argumentException = new List<string>();
                // Validasi field NOT NULL berdasarkan struktur tabel
                if (string.IsNullOrWhiteSpace(request.CompanyCode))
                    argumentException.Add("Company Code is required.");

                if (string.IsNullOrWhiteSpace(request.CompanyName))
                    argumentException.Add("Company Name is required.");

                if (string.IsNullOrWhiteSpace(request.Abbreviation))
                    argumentException.Add("Abbreviation is required.");

                if (string.IsNullOrWhiteSpace(request.AbbreviationUpin))
                    argumentException.Add("Abbreviation UPIN is required.");

                // Validasi panjang field sesuai constraint di database
                if (request.CompanyName.Length > 100)
                    argumentException.Add("Company Name cannot exceed 100 characters.");

                if (request.Abbreviation.Length > 10)
                    argumentException.Add("Abbreviation cannot exceed 10 characters.");

                if (request.AbbreviationUpin.Length > 10)
                    argumentException.Add("Abbreviation UPIN cannot exceed 10 characters.");

                // Validasi field lainnya yang memiliki length constraint
                if (!string.IsNullOrWhiteSpace(request.Phone) && request.Phone.Length > 15)
                    argumentException.Add("Phone cannot exceed 15 characters.");

                if (!string.IsNullOrWhiteSpace(request.Fax) && request.Fax.Length > 15)
                    argumentException.Add("Fax cannot exceed 15 characters.");

                if (!string.IsNullOrWhiteSpace(request.ZipCode) && request.ZipCode.Length > 10)
                    argumentException.Add("ZipCode cannot exceed 10 characters.");

                if (!string.IsNullOrWhiteSpace(request.City) && request.City.Length > 30)
                    argumentException.Add("City cannot exceed 30 characters.");

                if (!string.IsNullOrWhiteSpace(request.PhoneUpin) && request.PhoneUpin.Length > 15)
                    argumentException.Add("Phone UPIN cannot exceed 15 characters.");

                if (!string.IsNullOrWhiteSpace(request.FaxUpin) && request.FaxUpin.Length > 15)
                    argumentException.Add("Fax UPIN cannot exceed 15 characters.");

                if (!string.IsNullOrWhiteSpace(request.ZipCodeUpin) && request.ZipCodeUpin.Length > 10)
                    argumentException.Add("ZipCode UPIN cannot exceed 10 characters.");

                if (!string.IsNullOrWhiteSpace(request.CityUpin) && request.CityUpin.Length > 30)
                    argumentException.Add("City UPIN cannot exceed 30 characters.");

                if (argumentException.Any())
                {
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.CompanyCode}", string.Join(", ", argumentException.ToArray()));
                }
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
                        InsertedBy = "system",
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
                            ModifiedBy = "system",
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
                if (string.IsNullOrWhiteSpace(request.CompanyCode))
                    throw new ArgumentException("Company Code is required.");

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
