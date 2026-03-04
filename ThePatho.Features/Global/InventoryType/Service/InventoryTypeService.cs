using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.InventoryType.Commands;
using ThePatho.Features.Global.InventoryType.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.InventoryType.Service
{
    public class InventoryTypeService : IInventoryTypeService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public InventoryTypeService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<InventoryTypeItemDto>> GetInventoryType(GetInventoryTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@InventoryTypeCode", request.FilterInventoryTypeCode ?? string.Empty);
                parameters.Add("@InventoryName", request.FilterInventoryName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryType/Sql/get_inventorytype");
                var data = await dbConnection.QueryAsync<InventoryTypeDto>(query, parameters);
                var result = new InventoryTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    InventoryTypeList = data.ToList(),
                };
                return new ApiResponse<InventoryTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<InventoryTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<InventoryTypeDto>> GetSingleInventoryType(GetSingleInventoryTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryTypeCode", request.FilterInventoryTypeCode);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryType/Sql/get_single_inventorytype");

                var data = await dbConnection.QueryFirstOrDefaultAsync<InventoryTypeDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<InventoryTypeDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<InventoryTypeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<InventoryTypeDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<InventoryTypeItemDto>> GetInventoryTypeByCriteria(GetInventoryTypeByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryTypeCode", request.InventoryTypeCode ?? string.Empty);
                parameters.Add("@InventoryName", request.InventoryName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryType/Sql/get_criteria_inventorytype");
                var data = await dbConnection.QueryAsync<InventoryTypeDto>(query, parameters);
                var result = new InventoryTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    InventoryTypeList = data.ToList(),
                };
                return new ApiResponse<InventoryTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<InventoryTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitInventoryType(SubmitInventoryTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryTypeCode", request.InventoryTypeCode);
                parameters.Add("@InventoryName", request.InventoryName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/InventoryType/Sql/submit_inventorytype");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.InventoryTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.InventoryTypeCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteInventoryType(DeleteInventoryTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryTypeCode", request.InventoryTypeCode);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryType/Sql/get_single_inventorytype");

                var data = await dbConnection.QueryFirstOrDefaultAsync<InventoryTypeDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<InventoryTypeDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("Global/InventoryType/Sql/delete_inventorytype");
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
