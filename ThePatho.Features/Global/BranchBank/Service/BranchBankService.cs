using Dapper;
using System.Net;
using ThePatho.Features.Global.BloodType.DTO;
using ThePatho.Features.Global.BranchBank.Commands;
using ThePatho.Features.Global.BranchBank.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.BranchBank.Service
{
    public class BranchBankService : IBranchBankService
    {
        private readonly DapperContext dapperContext;
        private readonly SqlQueryLoader queryLoader;

        public BranchBankService(DapperContext _dapperContext, SqlQueryLoader _queryLoader)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
        }

        public async Task<ApiResponse<BranchBankItemDto>> GetBranchBank(GetBranchBankCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@BranchBankCode", request.FilterBranchBankCode ?? string.Empty);
                parameters.Add("@BranchBankName", request.FilterBranchBankName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/BranchBank/Sql/get_branch_bank");
                var data = await db.QueryAsync<BranchBankDto>(query, parameters);

                var result = new BranchBankItemDto
                {
                    DataOfRecords = data.Count(),
                    BranchBankList = data.ToList()
                };

                return new ApiResponse<BranchBankItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<BranchBankItemDto>(
                    HttpStatusCode.BadRequest,
                    "An error occurred while retrieving Branch Bank list.",
                    ex.Message
                );
            }
        }

        public async Task<ApiResponse<BranchBankDto>> GetSingleBranchBank(GetSingleBranchBankCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@BranchBankCode", request.FilterBranchBankCode);

                var query = await queryLoader.LoadQueryAsync("Global/BranchBank/Sql/get_single_branch_bank");
                var data = await db.QueryFirstOrDefaultAsync<BranchBankDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<BranchBankDto>(HttpStatusCode.NotFound, $"Data not Found", "Data not Found");
                }
                return new ApiResponse<BranchBankDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<BranchBankDto>(
                    HttpStatusCode.BadRequest,
                    "An error occurred while retrieving Branch Bank data.",
                    ex.Message
                );
            }
        }

        public async Task<ApiResponse<BranchBankItemDto>> GetBranchBankByCriteria(GetBranchBankByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@BranchBankCode", request.FilterBranchBankCode ?? string.Empty);
                parameters.Add("@BranchBankName", request.FilterBranchBankName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/BranchBank/Sql/get_criteria_branch_bank");
                var data = await db.QueryAsync<BranchBankDto>(query, parameters);

                var result = new BranchBankItemDto
                {
                    DataOfRecords = data.Count(),
                    BranchBankList = data.ToList()
                };

                return new ApiResponse<BranchBankItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<BranchBankItemDto>(
                    HttpStatusCode.BadRequest,
                    "An error occurred while filtering Branch Bank data.",
                    ex.Message
                );
            }
        }

        public async Task<ApiResponse> SubmitBranchBank(SubmitBranchBankCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();

                var ArgumentException = new List<string>();

                if (string.IsNullOrWhiteSpace(request.BranchBankCode))
                    ArgumentException.Add("Branch Bank Code Code is required.");

                if (string.IsNullOrWhiteSpace(request.BranchBankName))
                    ArgumentException.Add("Branch Bank Name Name is required.");

                if (ArgumentException.Any())
                {
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.BranchBankName}", string.Join(", ", ArgumentException.ToArray()));
                }
                var parameters = new DynamicParameters();
                parameters.Add("@BranchBankCode", request.BranchBankCode);
                parameters.Add("@BranchBankName", request.BranchBankName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/BranchBank/Sql/submit_branch_bank");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.BranchBankCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.BranchBankCode}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteBranchBank(DeleteBranchBankCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@BranchBankCode", request.BranchBankCode);
                var query_single = await queryLoader.LoadQueryAsync("Global/BranchBank/Sql/get_single_branch_bank");
                var data = await db.QueryFirstOrDefaultAsync<BranchBankDto>(query_single, parameters);
                if (query_single == null)
                {
                    return new ApiResponse<BranchBankDto>(HttpStatusCode.NotFound, $"Data not Found", "Data not Found");
                }
                var query = await queryLoader.LoadQueryAsync("Global/BranchBank/Sql/delete_branch_bank");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.BranchBankCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.BranchBankCode}", ex.Message);
            }
        }
    }
}
