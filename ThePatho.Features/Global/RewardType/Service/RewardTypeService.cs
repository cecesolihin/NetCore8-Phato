using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.RewardType.Commands;
using ThePatho.Features.Global.RewardType.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.RewardType.Service
{
    public class RewardTypeService : IRewardTypeService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public RewardTypeService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<RewardTypeItemDto>> GetRewardType(GetRewardTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@RewardTypeCode", request.FilterRewardTypeCode ?? string.Empty);
                parameters.Add("@RewardTypeName", request.FilterRewardTypeName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/RewardType/Sql/get_rewardtype");
                var data = await dbConnection.QueryAsync<RewardTypeDto>(query, parameters);
                var result = new RewardTypeItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    RewardTypeList = data.ToList(),
                };
                return new ApiResponse<RewardTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<RewardTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<RewardTypeDto>> GetSingleRewardType(GetSingleRewardTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RewardTypeCode", request.FilterRewardTypeCode);

                var query = await queryLoader.LoadQueryAsync("Global/RewardType/Sql/get_single_rewardtype");

                var data = await dbConnection.QueryFirstOrDefaultAsync<RewardTypeDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<RewardTypeDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<RewardTypeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<RewardTypeDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<RewardTypeItemDto>> GetRewardTypeByCriteria(GetRewardTypeByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RewardTypeCode", request.FilterRewardTypeCode ?? string.Empty);
                parameters.Add("@RewardTypeName", request.FilterRewardTypeName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/RewardType/Sql/get_criteria_rewardtype");
                var data = await dbConnection.QueryAsync<RewardTypeDto>(query, parameters);
                var result = new RewardTypeItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    RewardTypeList = data.ToList(),
                };
                return new ApiResponse<RewardTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<RewardTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitRewardType(SubmitRewardTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RewardTypeCode", request.RewardTypeCode);
                parameters.Add("@RewardTypeName", request.RewardTypeName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/RewardType/Sql/submit_rewardtype");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.RewardTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.RewardTypeCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteRewardType(DeleteRewardTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RewardTypeCode", request.RewardTypeCode);

                var query = await queryLoader.LoadQueryAsync("Global/RewardType/Sql/get_single_rewardtype");

                var data = await dbConnection.QueryFirstOrDefaultAsync<RewardTypeDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<RewardTypeDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("Global/RewardType/Sql/delete_rewardtype");
                await dbConnection.ExecuteAsync(query_delete, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"Delete successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message.ToString());
            }
        }

    }
}
