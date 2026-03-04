using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.Identity.Commands;
using ThePatho.Features.Global.Identity.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.Identity.Service
{
    public class IdentityService : IIdentityService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public IdentityService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<IdentityItemDto>> GetIdentity(GetIdentityCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@IdentityCode", request.FilterIdentityCode ?? string.Empty);
                parameters.Add("@IdentityName", request.FilterIdentityName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/Identity/Sql/get_identity");
                var data = await dbConnection.QueryAsync<IdentityDto>(query, parameters);
                var result = new IdentityItemDto
                {
                    DataOfRecords = data.Count(),
                    IdentityList = data.ToList(),
                };
                return new ApiResponse<IdentityItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IdentityItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<IdentityDto>> GetSingleIdentity(GetSingleIdentityCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdentityCode", request.FilterIdentityCode);

                var query = await queryLoader.LoadQueryAsync("Global/Identity/Sql/get_single_identity");

                var data = await dbConnection.QueryFirstOrDefaultAsync<IdentityDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<IdentityDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<IdentityDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IdentityDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<IdentityItemDto>> GetIdentityByCriteria(GetIdentityByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdentityCode", request.IdentityCode ?? string.Empty);
                parameters.Add("@IdentityName", request.IdentityName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/Identity/Sql/get_criteria_identity");
                var data = await dbConnection.QueryAsync<IdentityDto>(query, parameters);
                var result = new IdentityItemDto
                {
                    DataOfRecords = data.Count(),
                    IdentityList = data.ToList(),
                };
                return new ApiResponse<IdentityItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IdentityItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitIdentity(SubmitIdentityCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdentityCode", request.IdentityCode);
                parameters.Add("@IdentityName", request.IdentityName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/Identity/Sql/submit_identity");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.IdentityCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.IdentityCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteIdentity(DeleteIdentityCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdentityCode", request.IdentityCode);

                var query = await queryLoader.LoadQueryAsync("Global/Identity/Sql/get_single_identity");

                var data = await dbConnection.QueryFirstOrDefaultAsync<IdentityDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<IdentityDto>(HttpStatusCode.NotFound, "data not found");
                }
                var query_delete = await queryLoader.LoadQueryAsync("Global/Identity/Sql/delete_identity");
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

