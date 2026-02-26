using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.RadiusUnit.Commands;
using ThePatho.Features.Global.RadiusUnit.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.RadiusUnit.Service
{
    public class RadiusUnitService : IRadiusUnitService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public RadiusUnitService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<RadiusUnitItemDto>> GetRadiusUnit(GetRadiusUnitCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@RadiusUnitCode", request.FilterRadiusUnitCode ?? string.Empty);
                parameters.Add("@RadiusUnitName", request.FilterRadiusUnitName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/RadiusUnit/Sql/get_radiusunit");
                var data = await dbConnection.QueryAsync<RadiusUnitDto>(query, parameters);
                var result = new RadiusUnitItemDto
                {
                    DataOfRecords = data.Count(),
                    RadiusUnitList = data.ToList(),
                };
                return new ApiResponse<RadiusUnitItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<RadiusUnitItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<RadiusUnitDto>> GetSingleRadiusUnit(GetSingleRadiusUnitCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RadiusUnitCode", request.RadiusUnitCode);

                var query = await queryLoader.LoadQueryAsync("Global/RadiusUnit/Sql/get_single_radiusunit");

                var data = await dbConnection.QueryFirstOrDefaultAsync<RadiusUnitDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<RadiusUnitDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<RadiusUnitDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<RadiusUnitDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<RadiusUnitItemDto>> GetRadiusUnitByCriteria(GetRadiusUnitByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RadiusUnitCode", request.RadiusUnitCode ?? string.Empty);
                parameters.Add("@RadiusUnitName", request.RadiusUnitName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/RadiusUnit/Sql/get_criteria_radiusunit");
                var data = await dbConnection.QueryAsync<RadiusUnitDto>(query, parameters);
                var result = new RadiusUnitItemDto
                {
                    DataOfRecords = data.Count(),
                    RadiusUnitList = data.ToList(),
                };
                return new ApiResponse<RadiusUnitItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<RadiusUnitItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitRadiusUnit(SubmitRadiusUnitCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RadiusUnitCode", request.RadiusUnitCode);
                parameters.Add("@RadiusUnitName", request.RadiusUnitName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/RadiusUnit/Sql/submit_radiusunit");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.RadiusUnitName} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.RadiusUnitName}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteRadiusUnit(DeleteRadiusUnitCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RadiusUnitCode", request.RadiusUnitCode);

                var query = await queryLoader.LoadQueryAsync("Global/RadiusUnit/Sql/get_single_radiusunit");

                var data = await dbConnection.QueryFirstOrDefaultAsync<RadiusUnitDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<RadiusUnitDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("Global/RadiusUnit/Sql/delete_radiusunit");
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
