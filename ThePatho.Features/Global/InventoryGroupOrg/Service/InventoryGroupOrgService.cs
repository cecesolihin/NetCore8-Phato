using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.InventoryGroupOrg.Commands;
using ThePatho.Features.Global.InventoryGroupOrg.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.InventoryGroupOrg.Service
{
    public class InventoryGroupOrgService : IInventoryGroupOrgService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public InventoryGroupOrgService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService =_currentUserService;
        }

        public async Task<ApiResponse<InventoryGroupOrgItemDto>> GetInventoryGroupOrg(GetInventoryGroupOrgCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@InventoryGroupCode", request.FilterInventoryGroupCode ?? string.Empty);
                parameters.Add("@OrganizationCode", request.FilterOrganizationCode ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryGroupOrg/Sql/get_inventorygrouporg");
                var data = await dbConnection.QueryAsync<InventoryGroupOrgDto>(query, parameters);
                var result = new InventoryGroupOrgItemDto
                {
                    DataOfRecords = data.Count(),
                    InventoryGroupOrgList = data.ToList(),
                };
                return new ApiResponse<InventoryGroupOrgItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<InventoryGroupOrgItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<InventoryGroupOrgDto>> GetSingleInventoryGroupOrg(GetSingleInventoryGroupOrgCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryGroupOrgId", request.FilterInventoryGroupOrgId);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryGroupOrg/Sql/get_single_inventorygrouporg");

                var data = await dbConnection.QueryFirstOrDefaultAsync<InventoryGroupOrgDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<InventoryGroupOrgDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<InventoryGroupOrgDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<InventoryGroupOrgDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<InventoryGroupOrgItemDto>> GetInventoryGroupOrgByCriteria(GetInventoryGroupOrgByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryGroupCode", request.FilterInventoryGroupCode ?? string.Empty);
                parameters.Add("@OrganizationCode", request.FilterOrganizationCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/InventoryGroupOrg/Sql/get_criteria_inventorygrouporg");
                var data = await dbConnection.QueryAsync<InventoryGroupOrgDto>(query, parameters);
                var result = new InventoryGroupOrgItemDto
                {
                    DataOfRecords = data.Count(),
                    InventoryGroupOrgList = data.ToList(),
                };
                return new ApiResponse<InventoryGroupOrgItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<InventoryGroupOrgItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitInventoryGroupOrg(SubmitInventoryGroupOrgCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryGroupOrgId", request.InventoryGroupOrgId);
                parameters.Add("@InventoryGroupCode", request.InventoryGroupCode);
                parameters.Add("@OrganizationCode", request.OrganizationCode);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/InventoryGroupOrg/Sql/submit_inventorygrouporg");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.InventoryGroupCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.InventoryGroupCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteInventoryGroupOrg(DeleteInventoryGroupOrgCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InventoryGroupOrgId", request.InventoryGroupOrgId);
                var query = await queryLoader.LoadQueryAsync("Global/InventoryGroupOrg/Sql/get_single_inventorygrouporg");

                var data = await dbConnection.QueryFirstOrDefaultAsync<InventoryGroupOrgDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<InventoryGroupOrgDto>(HttpStatusCode.NotFound, "data not found");
                }
                var query_delete = await queryLoader.LoadQueryAsync("Global/InventoryGroupOrg/Sql/delete_inventorygrouporg");
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

