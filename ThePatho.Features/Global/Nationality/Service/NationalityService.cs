using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.Nationality.Commands;
using ThePatho.Features.Global.Nationality.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.Nationality.Service
{
    public class NationalityService : INationalityService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public NationalityService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<NationalityItemDto>> GetNationality(GetNationalityCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@NationalityName", request.FilterNationalityName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/Nationality/Sql/get_nationality");
                var data = await dbConnection.QueryAsync<NationalityDto>(query, parameters);
                var result = new NationalityItemDto
                {
                    DataOfRecords = data.Count(),
                    NationalityList = data.ToList(),
                };
                return new ApiResponse<NationalityItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<NationalityItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<NationalityDto>> GetSingleNationality(GetSingleNationalityCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@NationalityId", request.FilterNationalityId);

                var query = await queryLoader.LoadQueryAsync("Global/Nationality/Sql/get_single_nationality");

                var data = await dbConnection.QueryFirstOrDefaultAsync<NationalityDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<NationalityDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<NationalityDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<NationalityDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<NationalityItemDto>> GetNationalityByCriteria(GetNationalityByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@NationalityName", request.NationalityName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/Nationality/Sql/get_criteria_nationality");
                var data = await dbConnection.QueryAsync<NationalityDto>(query, parameters);
                var result = new NationalityItemDto
                {
                    DataOfRecords = data.Count(),
                    NationalityList = data.ToList(),
                };
                return new ApiResponse<NationalityItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<NationalityItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitNationality(SubmitNationalityCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@NationalityId", request.NationalityId);
                parameters.Add("@NationalityName", request.NationalityName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/Nationality/Sql/submit_nationality");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.NationalityName} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.NationalityName}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteNationality(DeleteNationalityCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@NationalityId", request.NationalityId);

                var query = await queryLoader.LoadQueryAsync("Global/Nationality/Sql/get_single_nationality");

                var data = await dbConnection.QueryFirstOrDefaultAsync<NationalityDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<NationalityDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("Global/Nationality/Sql/delete_nationality");
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
