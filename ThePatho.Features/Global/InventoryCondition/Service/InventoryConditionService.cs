using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.InventoryCondition.Commands;
using ThePatho.Features.Global.InventoryCondition.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.InventoryCondition.Service
{
    public class InventoryConditionService : IInventoryConditionService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public InventoryConditionService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<InventoryConditionItemDto>> GetInventoryCondition(GetInventoryConditionCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@InventoryConditionCode", request.FilterInventoryConditionCode ?? string.Empty);
                parameters.Add("@InventoryConditionName", request.FilterInventoryConditionName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryCondition/Sql/get_inventorycondition");
                var data = await dbConnection.QueryAsync<InventoryConditionDto>(query, parameters);
                var result = new InventoryConditionItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    InventoryConditionList = data.ToList(),
                };
                return new ApiResponse<InventoryConditionItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<InventoryConditionItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<InventoryConditionDto>> GetSingleInventoryCondition(GetSingleInventoryConditionCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryConditionCode", request.FilterInventoryConditionCode);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryCondition/Sql/get_single_inventorycondition");

                var data = await dbConnection.QueryFirstOrDefaultAsync<InventoryConditionDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<InventoryConditionDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<InventoryConditionDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<InventoryConditionDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<InventoryConditionItemDto>> GetInventoryConditionByCriteria(GetInventoryConditionByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryConditionCode", request.FilterInventoryConditionCode ?? string.Empty);
                parameters.Add("@InventoryConditionName", request.FilterInventoryConditionName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryCondition/Sql/get_criteria_inventorycondition");
                var data = await dbConnection.QueryAsync<InventoryConditionDto>(query, parameters);
                var result = new InventoryConditionItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    InventoryConditionList = data.ToList(),
                };
                return new ApiResponse<InventoryConditionItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<InventoryConditionItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitInventoryCondition(SubmitInventoryConditionCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryConditionCode", request.InventoryConditionCode);
                parameters.Add("@InventoryConditionName", request.InventoryConditionName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/InventoryCondition/Sql/submit_inventorycondition");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.InventoryConditionCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.InventoryConditionCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteInventoryCondition(DeleteInventoryConditionCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryConditionCode", request.InventoryConditionCode);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryCondition/Sql/get_single_inventorycondition");

                var data = await dbConnection.QueryFirstOrDefaultAsync<InventoryConditionDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<InventoryConditionDto>(HttpStatusCode.NotFound, "data not found");
                }
                var query_delete = await queryLoader.LoadQueryAsync("Global/InventoryCondition/Sql/delete_inventorycondition");
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
