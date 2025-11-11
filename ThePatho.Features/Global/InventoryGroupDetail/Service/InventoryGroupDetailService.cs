using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.InventoryGroupDetail.Commands;
using ThePatho.Features.Global.InventoryGroupDetail.DTO;
using ThePatho.Features.Global.InventoryGroupDetail.Commands;
using ThePatho.Features.Global.InventoryGroupDetail.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.InventoryGroupDetail.Service
{
    public class InventoryGroupDetailService : IInventoryGroupDetailService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public InventoryGroupDetailService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService; 
        }

        public async Task<ApiResponse<InventoryGroupDetailItemDto>> GetInventoryGroupDetail(GetInventoryGroupDetailCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@InventoryGroupDetailCode", request.FilterInventoryGroupCode ?? (object)DBNull.Value);
                parameters.Add("@InventoryTypeCode", request.FilterInventoryTypeCode ?? (object)DBNull.Value);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryGroupDetail/Sql/get_inventorygroupdetail");
                var data = await dbConnection.QueryAsync<InventoryGroupDetailDto>(query, parameters);
                var result = new InventoryGroupDetailItemDto
                {
                    DataOfRecords = data.Count(),
                    InventoryGroupDetailList = data.ToList(),
                };
                return new ApiResponse<InventoryGroupDetailItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<InventoryGroupDetailItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<InventoryGroupDetailDto>> GetSingleInventoryGroupDetail(GetSingleInventoryGroupDetailCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryGroupDetailId", request.InventoryGroupDetailId);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryGroupDetail/Sql/get_single_inventorygroupdetail");

                var data = await dbConnection.QueryFirstOrDefaultAsync<InventoryGroupDetailDto>(query, parameters);
                return new ApiResponse<InventoryGroupDetailDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<InventoryGroupDetailDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<InventoryGroupDetailItemDto>> GetInventoryGroupDetailByCriteria(GetInventoryGroupDetailByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryGroupDetailCode", request.FilterInventoryGroupCode ?? (object)DBNull.Value);
                parameters.Add("@InventoryTypeCode", request.FilterInventoryTypeCode ?? (object)DBNull.Value);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryGroupDetail/Sql/get_criteria_inventorygroupdetail");
                var data = await dbConnection.QueryAsync<InventoryGroupDetailDto>(query, parameters);
                var result = new InventoryGroupDetailItemDto
                {
                    DataOfRecords = data.Count(),
                    InventoryGroupDetailList = data.ToList(),
                };
                return new ApiResponse<InventoryGroupDetailItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<InventoryGroupDetailItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitInventoryGroupDetail(SubmitInventoryGroupDetailCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryGroupDetailId", request.InventoryGroupDetailId);
                parameters.Add("@InventoryGroupCode", request.InventoryGroupCode);
                parameters.Add("@InventoryTypeCode", request.InventoryTypeCode);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/InventoryGroupDetail/Sql/submit_inventorygroupdetail");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.InventoryGroupCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.InventoryGroupCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteInventoryGroupDetail(DeleteInventoryGroupDetailCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryGroupDetailId", request.InventoryGroupDetailId);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryGroupDetail/Sql/delete_inventorygroupdetail");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"Delete successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message.ToString());
            }
        }
    }
}

