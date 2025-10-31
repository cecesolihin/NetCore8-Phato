using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.CompanyBank.Commands;
using ThePatho.Features.Organization.CompanyBank.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

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
                    DataOfRecords = data.ToList().Count,
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

                // Validasi field yang required
                if (string.IsNullOrWhiteSpace(request.Branch))
                    throw new ArgumentException("Branch is required.");

                if (string.IsNullOrWhiteSpace(request.CompanyCode))
                    throw new ArgumentException("Company Code is required.");

                // Validasi CompanyCode exists di TOGMCompanyProfile
                var companyExistsQuery = new Query(TableOrganization.CompanyProfile)
                    .Where("CompanyCode", request.CompanyCode)
                    .SelectRaw("COUNT(1)");

                var companyExists = await db.ExecuteScalarAsync<int>(companyExistsQuery);
                if (companyExists == 0)
                    throw new ArgumentException($"Company Code '{request.CompanyCode}' does not exist.");

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
                            throw new ArgumentException($"Account No '{request.AccountNo}' already exists for this company.");
                    }
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
                        throw new ArgumentException($"Company Bank with ID {request.CompanyBankId} not found.");

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
                            throw new ArgumentException($"Account No '{request.AccountNo}' already exists for this company.");
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
                    throw new ArgumentException("CompanyBankId is required and must be greater than 0.");

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
