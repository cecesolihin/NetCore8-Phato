using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.TimeZone.Commands;
using ThePatho.Features.Global.TimeZone.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.TimeZone.Service
{
    public class TimeZoneService : ITimeZoneService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public TimeZoneService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<TimeZoneItemDto>> GetTimeZone(GetTimeZoneCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@TimeZoneCode", request.FilterTimeZoneCode ?? string.Empty);
                parameters.Add("@TimeZoneName", request.FilterTimeZoneName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/TimeZone/Sql/get_timezone");
                var data = await dbConnection.QueryAsync<TimeZoneDto>(query, parameters);
                var result = new TimeZoneItemDto
                {
                    DataOfRecords = data.Count(),
                    TimeZoneList = data.ToList(),
                };
                return new ApiResponse<TimeZoneItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TimeZoneItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<TimeZoneDto>> GetSingleTimeZone(GetSingleTimeZoneCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TimeZoneCode", request.FilterTimeZoneCode);

                var query = await queryLoader.LoadQueryAsync("Global/TimeZone/Sql/get_single_timezone");

                var data = await dbConnection.QueryFirstOrDefaultAsync<TimeZoneDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<TimeZoneDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<TimeZoneDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TimeZoneDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<TimeZoneItemDto>> GetTimeZoneByCriteria(GetTimeZoneByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TimeZoneCode", request.TimeZoneCode ?? string.Empty);
                parameters.Add("@TimeZoneName", request.TimeZoneName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/TimeZone/Sql/get_criteria_timezone");
                var data = await dbConnection.QueryAsync<TimeZoneDto>(query, parameters);
                var result = new TimeZoneItemDto
                {
                    DataOfRecords = data.Count(),
                    TimeZoneList = data.ToList(),
                };
                return new ApiResponse<TimeZoneItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TimeZoneItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitTimeZone(SubmitTimeZoneCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TimeZoneCode", request.TimeZoneCode);
                parameters.Add("@TimeZoneName", request.TimeZoneName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/TimeZone/Sql/submit_timezone");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.TimeZoneName} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.TimeZoneName}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteTimeZone(DeleteTimeZoneCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TimeZoneCode", request.TimeZoneCode);

                var query = await queryLoader.LoadQueryAsync("Global/TimeZone/Sql/get_single_timezone");

                var data = await dbConnection.QueryFirstOrDefaultAsync<TimeZoneDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<TimeZoneDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("Global/TimeZone/Sql/delete_timezone");
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
