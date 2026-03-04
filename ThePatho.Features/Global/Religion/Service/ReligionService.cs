using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.Religion.Commands;
using ThePatho.Features.Global.Religion.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.Religion.Service
{
    public class ReligionService : IReligionService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public ReligionService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<ReligionItemDto>> GetReligion(GetReligionCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@ReligionName", request.FilterReligionName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/Religion/Sql/get_religion");
                var data = await dbConnection.QueryAsync<ReligionDto>(query, parameters);
                var result = new ReligionItemDto
                {
                    DataOfRecords = data.Count(),
                    ReligionList = data.ToList(),
                };
                return new ApiResponse<ReligionItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ReligionItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<ReligionDto>> GetSingleReligion(GetSingleReligionCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ReligionId", request.FilterReligionId);

                var query = await queryLoader.LoadQueryAsync("Global/Religion/Sql/get_single_religion");

                var data = await dbConnection.QueryFirstOrDefaultAsync<ReligionDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<ReligionDto>(HttpStatusCode.OK, "data not found");
                }
                return new ApiResponse<ReligionDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ReligionDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<ReligionItemDto>> GetReligionByCriteria(GetReligionByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ReligionName", request.ReligionName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/Religion/Sql/get_criteria_religion");
                var data = await dbConnection.QueryAsync<ReligionDto>(query, parameters);
                var result = new ReligionItemDto
                {
                    DataOfRecords = data.Count(),
                    ReligionList = data.ToList(),
                };
                return new ApiResponse<ReligionItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ReligionItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitReligion(SubmitReligionCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ReligionId", request.ReligionId);
                parameters.Add("@ReligionName", request.ReligionName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/Religion/Sql/submit_religion");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.ReligionName} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.ReligionName}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteReligion(DeleteReligionCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ReligionId", request.ReligionId);

                var query = await queryLoader.LoadQueryAsync("Global/Religion/Sql/get_single_religion");

                var data = await dbConnection.QueryFirstOrDefaultAsync<ReligionDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<ReligionDto>(HttpStatusCode.OK, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("Global/Religion/Sql/delete_religion");
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
