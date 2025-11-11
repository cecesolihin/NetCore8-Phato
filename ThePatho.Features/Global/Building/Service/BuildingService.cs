using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.Building.Commands;
using ThePatho.Features.Global.Building.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.Building.Service
{
    public class BuildingService : IBuildingService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public BuildingService(ApplicationDbContext _context, 
            DapperContext _dappercontext, SqlQueryLoader _queryLoader, 
            IDbConnection _dbConnection,
            ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<BuildingItemDto>> GetBuilding(GetBuildingCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@BuildingCode", request.FilterBuildingCode ?? string.Empty);
                parameters.Add("@BuildingName", request.FilterBuildingName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/Building/Sql/get_building");
                var data = await dbConnection.QueryAsync<BuildingDto>(query, parameters);
                var result = new BuildingItemDto
                {
                    DataOfRecords = data.Count(),
                    BuildingList = data.ToList(),
                };
                return new ApiResponse<BuildingItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<BuildingItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<BuildingDto>> GetSingleBuilding(GetSingleBuildingCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BuildingCode", request.FilterBuildingCode);

                var query = await queryLoader.LoadQueryAsync("Global/Building/Sql/get_single_building");

                var data = await dbConnection.QueryFirstOrDefaultAsync<BuildingDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<BuildingDto>(
                                        HttpStatusCode.BadRequest,
                                        "data not found",
                                        null
                                    );
                }
                return new ApiResponse<BuildingDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<BuildingDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<BuildingItemDto>> GetBuildingByCriteria(GetBuildingByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BuildingCode", request.FilterBuildingCode ?? string.Empty);
                parameters.Add("@BuildingName", request.FilterBuildingName ?? string.Empty);


                var query = await queryLoader.LoadQueryAsync("Global/Building/Sql/get_criteria_building");
                var data = await dbConnection.QueryAsync<BuildingDto>(query, parameters);
                var result = new BuildingItemDto
                {
                    DataOfRecords = data.Count(),
                    BuildingList = data.ToList(),
                };
                return new ApiResponse<BuildingItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<BuildingItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitBuilding(SubmitBuildingCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BuildingCode", request.BuildingCode);
                parameters.Add("@BuildingName", request.BuildingName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/Building/Sql/submit_building");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.BuildingCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.BuildingCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteBuilding(DeleteBuildingCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BuildingCode", request.BuildingCode);
                var query_single = await queryLoader.LoadQueryAsync("Global/Building/Sql/get_single_building");

                var data_single = await dbConnection.QueryFirstOrDefaultAsync<BuildingDto>(query_single, parameters);
                if (data_single == null)
                {
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", "data not found");
                }
                var query = await queryLoader.LoadQueryAsync("Global/Building/Sql/delete_building");
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
