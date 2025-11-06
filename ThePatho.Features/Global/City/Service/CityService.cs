using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.City.Commands;
using ThePatho.Features.Global.City.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.City.Service
{
    public class CityService : ICityService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public CityService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<CityItemDto>> GetCity(GetCityCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@CityCode", request.FilterCityCode ?? string.Empty);
                parameters.Add("@Name", request.FilterName ?? string.Empty);
                parameters.Add("@ProvinceId", request.FilterProvinceId);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/City/Sql/get_city");
                var data = await dbConnection.QueryAsync<CityDto>(query, parameters);
                var result = new CityItemDto
                {
                    DataOfRecords = data.Count(),
                    CityList = data.ToList(),
                };
                return new ApiResponse<CityItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CityItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<CityDto>> GetSingleCity(GetSingleCityCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CityId", request.FilterCityId);

                var query = await queryLoader.LoadQueryAsync("Global/City/Sql/get_single_city");

                var data = await dbConnection.QueryFirstOrDefaultAsync<CityDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<CityDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<CityDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CityDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<CityItemDto>> GetCityByCriteria(GetCityByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CityCode", request.FilterCityCode ?? string.Empty);
                parameters.Add("@Name", request.FilterName ?? string.Empty);
                parameters.Add("@ProvinceId", request.FilterProvinceId);


                var query = await queryLoader.LoadQueryAsync("Global/City/Sql/get_criteria_city");
                var data = await dbConnection.QueryAsync<CityDto>(query, parameters);
                var result = new CityItemDto
                {
                    DataOfRecords = data.Count(),
                    CityList = data.ToList(),
                };
                return new ApiResponse<CityItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CityItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitCity(SubmitCityCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CityId", request.CityId);
                parameters.Add("@CityCode", request.CityCode);
                parameters.Add("@ProvinceId", request.ProvinceId);
                parameters.Add("@Name", request.Name);
                parameters.Add("@Sort", request.Sort);
                parameters.Add("@IsDeleted", request.IsDeleted);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/City/Sql/submit_city");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.CityCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.CityCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteCity(DeleteCityCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CityId", request.CityId);

                var query = await queryLoader.LoadQueryAsync("Global/City/Sql/get_single_city");

                var data = await dbConnection.QueryFirstOrDefaultAsync<CityDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<CityDto>(HttpStatusCode.NotFound, "data not found");
                }
                var query_delete = await queryLoader.LoadQueryAsync("Global/City/Sql/delete_city");
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
