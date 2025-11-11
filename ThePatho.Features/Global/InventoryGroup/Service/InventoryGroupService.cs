using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.InventoryGroup.Commands;
using ThePatho.Features.Global.InventoryGroup.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.InventoryGroup.Service
{
    public class InventoryGroupService : IInventoryGroupService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public InventoryGroupService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<InventoryGroupItemDto>> GetInventoryGroup(GetInventoryGroupCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@InventoryGroupCode", request.FilterInventoryGroupCode ?? string.Empty);
                parameters.Add("@InventoryGroupName", request.FilterInventoryGroupName ?? string.Empty);
                parameters.Add("@GroupBy", request.FilterGroupBy ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryGroup/Sql/get_inventorygroup");
                var data = await dbConnection.QueryAsync<InventoryGroupDto>(query, parameters);
                var result = new InventoryGroupItemDto
                {
                    DataOfRecords = data.Count(),
                    InventoryGroupList = data.ToList(),
                };
                return new ApiResponse<InventoryGroupItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<InventoryGroupItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<InventoryGroupDto>> GetSingleInventoryGroup(GetSingleInventoryGroupCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryGroupCode", request.FilterInventoryGroupCode);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryGroup/Sql/get_single_inventorygroup");

                var data = await dbConnection.QueryFirstOrDefaultAsync<InventoryGroupDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<InventoryGroupDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<InventoryGroupDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<InventoryGroupDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<InventoryGroupItemDto>> GetInventoryGroupByCriteria(GetInventoryGroupByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryGroupCode", request.FilterInventoryGroupCode ?? string.Empty);
                parameters.Add("@InventoryGroupName", request.FilterInventoryGroupName ?? string.Empty);
                parameters.Add("@GroupBy", request.FilterGroupBy ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryGroup/Sql/get_criteria_inventorygroup");
                var data = await dbConnection.QueryAsync<InventoryGroupDto>(query, parameters);
                var result = new InventoryGroupItemDto
                {
                    DataOfRecords = data.Count(),
                    InventoryGroupList = data.ToList(),
                };
                return new ApiResponse<InventoryGroupItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<InventoryGroupItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitInventoryGroup(SubmitInventoryGroupCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryGroupCode", request.InventoryGroupCode);
                parameters.Add("@InventoryGroupName", request.InventoryGroupName);
                parameters.Add("@GroupBy", request.GroupBy);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/InventoryGroup/Sql/submit_inventorygroup");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.InventoryGroupCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.InventoryGroupCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteInventoryGroup(DeleteInventoryGroupCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryGroupCode", request.InventoryGroupCode);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryGroup/Sql/get_single_inventorygroup");

                var data = await dbConnection.QueryFirstOrDefaultAsync<InventoryGroupDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<InventoryGroupDto>(HttpStatusCode.NotFound, "data not found");
                }
                var query_delete = await queryLoader.LoadQueryAsync("Global/InventoryGroup/Sql/delete_inventorygroup");
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

