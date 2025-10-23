using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.Announcement.DTO;
using ThePatho.Features.Global.Bank.Commands;
using ThePatho.Features.Global.Bank.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Bank.Service
{
    public class BankService : IBankService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;

        public BankService(DapperContext _dapperContext, SqlQueryLoader _queryLoader)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
        }

        public async Task<ApiResponse<BankItemDto>> GetBank(GetBankCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@BankCode", request.FilterBankCode ?? string.Empty);
                parameters.Add("@Name", request.FilterName ?? string.Empty);
                parameters.Add("@BranchName", request.FilterBranchName ?? string.Empty);
                parameters.Add("@CurrencyCode", request.FilterCurrencyCode ?? string.Empty);
                parameters.Add("@TransferCode", request.FilterTransferCode ?? string.Empty);
                parameters.Add("@TransdferFee", request.FilterTransdferFee ?? 0);
                parameters.Add("@SwiftCode", request.FilterSwiftCode ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/Bank/Sql/get_bank");
                var data = await db.QueryAsync<BankDto>(query, parameters);

                var result = new BankItemDto
                {
                    DataOfRecords = data.Count(),
                    BankList = data.ToList()
                };

                return new ApiResponse<BankItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<BankItemDto>(HttpStatusCode.BadRequest, "Error retrieving Blood Type list.", ex.Message);
            }
        }

        public async Task<ApiResponse<BankDto>> GetSingleBank(GetSingleBankCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@BankCode", request.FilterBankCode);

                var query = await queryLoader.LoadQueryAsync("Global/Bank/Sql/get_single_bank");
                var data = await db.QueryFirstOrDefaultAsync<BankDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<BankDto>(HttpStatusCode.NotFound, $"Data not Found", "Data not Found");
                }

                return new ApiResponse<BankDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<BankDto>(HttpStatusCode.BadRequest, "Error retrieving Blood Type detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<BankItemDto>> GetBankByCriteria(GetBankByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@BankCode", request.FilterBankCode ?? string.Empty);
                parameters.Add("@Name", request.FilterName ?? string.Empty);
                parameters.Add("@BranchName", request.FilterBranchName ?? string.Empty);
                parameters.Add("@CurrencyCode", request.FilterCurrencyCode ?? string.Empty);
                parameters.Add("@TransferCode", request.FilterTransferCode ?? string.Empty);
                parameters.Add("@TransdferFee", request.FilterTransdferFee ?? 0);
                parameters.Add("@SwiftCode", request.FilterSwiftCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/Bank/Sql/get_criteria_bank");
                var data = await db.QueryAsync<BankDto>(query, parameters);

                var result = new BankItemDto
                {
                    DataOfRecords = data.Count(),
                    BankList = data.ToList()
                };

                return new ApiResponse<BankItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<BankItemDto>(HttpStatusCode.BadRequest, "Error filtering Blood Type data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitBank(SubmitBankCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
            
                var parameters = new DynamicParameters();
                parameters.Add("@BankCode", request.BankCode);
                parameters.Add("@Name", request.Name);
                parameters.Add("@BranchName", request.BranchName );
                parameters.Add("@CurrencyCode", request.CurrencyCode);
                parameters.Add("@TransferCode", request.TransferCode);
                parameters.Add("@TransdferFee", request.TransdferFee);
                parameters.Add("@SwiftCode", request.SwiftCode);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/Bank/Sql/submit_bank");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.BankCode} successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.BankCode}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteBank(DeleteBankCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@BankCode", request.BankCode);
                var query_single = await queryLoader.LoadQueryAsync("Global/Bank/Sql/get_single_bank");
                var data_single = await db.QueryFirstOrDefaultAsync<BankDto>(query_single, parameters);
                if (data_single == null)
                {
                    return new ApiResponse(HttpStatusCode.NotFound, $"Failed to delete", "Data not Found");
                }
                var query = await queryLoader.LoadQueryAsync("Global/Bank/Sql/delete_bank");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.BankCode} successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.BankCode}", ex.Message);
            }
        }
    }
}
