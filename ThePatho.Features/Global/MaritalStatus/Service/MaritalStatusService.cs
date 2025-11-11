using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.MaritalStatus.Commands;
using ThePatho.Features.Global.MaritalStatus.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.MaritalStatus.Service
{
    public class MaritalStatusService : IMaritalStatusService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public MaritalStatusService(ApplicationDbContext _context, 
            DapperContext _dappercontext, 
            SqlQueryLoader _queryLoader, 
            IDbConnection _dbConnection,
            ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<MaritalStatusItemDto>> GetMaritalStatus(GetMaritalStatusCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@MaritalStatusCode", request.FilterMaritalStatusCode ?? string.Empty);
                parameters.Add("@MaritalStatusName", request.FilterMaritalStatusName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/MaritalStatus/Sql/get_maritalstatus");
                var data = await dbConnection.QueryAsync<MaritalStatusDto>(query, parameters);
                var result = new MaritalStatusItemDto
                {
                    DataOfRecords = data.Count(),
                    MaritalStatusList = data.ToList(),
                };
                return new ApiResponse<MaritalStatusItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<MaritalStatusItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<MaritalStatusDto>> GetSingleMaritalStatus(GetSingleMaritalStatusCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MaritalStatusCode", request.FilterMaritalStatusCode);

                var query = await queryLoader.LoadQueryAsync("Global/MaritalStatus/Sql/get_single_maritalstatus");

                var data = await dbConnection.QueryFirstOrDefaultAsync<MaritalStatusDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<MaritalStatusDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<MaritalStatusDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<MaritalStatusDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<MaritalStatusItemDto>> GetMaritalStatusByCriteria(GetMaritalStatusByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MaritalStatusCode", request.FilterMaritalStatusCode ?? string.Empty);
                parameters.Add("@MaritalStatusName", request.FilterMaritalStatusName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/MaritalStatus/Sql/get_criteria_maritalstatus");
                var data = await dbConnection.QueryAsync<MaritalStatusDto>(query, parameters);
                var result = new MaritalStatusItemDto
                {
                    DataOfRecords = data.Count(),
                    MaritalStatusList = data.ToList(),
                };
                return new ApiResponse<MaritalStatusItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<MaritalStatusItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitMaritalStatus(SubmitMaritalStatusCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MaritalStatusCode", request.MaritalStatusCode);
                parameters.Add("@MaritalStatusName", request.MaritalStatusName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/MaritalStatus/Sql/submit_maritalstatus");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.MaritalStatusName} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.MaritalStatusName}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteMaritalStatus(DeleteMaritalStatusCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MaritalStatusCode", request.MaritalStatusCode);

                var query = await queryLoader.LoadQueryAsync("Global/MaritalStatus/Sql/get_single_maritalstatus");

                var data = await dbConnection.QueryFirstOrDefaultAsync<MaritalStatusDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<MaritalStatusDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("Global/MaritalStatus/Sql/delete_maritalstatus");
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
