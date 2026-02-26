using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.Province.Commands;
using ThePatho.Features.Global.Province.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.Province.Service
{
    public class ProvinceService : IProvinceService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public ProvinceService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<ProvinceItemDto>> GetProvince(GetProvinceCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@Abbreviation", request.FilterAbbreviation ?? string.Empty);
                parameters.Add("@CountryId", request.FilterCountry ?? 0);
                parameters.Add("@Name", request.FilterName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/Province/Sql/get_province");
                var data = await dbConnection.QueryAsync<ProvinceDto>(query, parameters);
                var result = new ProvinceItemDto
                {
                    DataOfRecords = data.Count(),
                    ProvinceList = data.ToList(),
                };
                return new ApiResponse<ProvinceItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ProvinceItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<ProvinceDto>> GetSingleProvince(GetSingleProvinceCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProvinceId", request.FilterProvinceId);

                var query = await queryLoader.LoadQueryAsync("Global/Province/Sql/get_single_province");

                var data = await dbConnection.QueryFirstOrDefaultAsync<ProvinceDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<ProvinceDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<ProvinceDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ProvinceDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<ProvinceItemDto>> GetProvinceByCriteria(GetProvinceByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Abbreviation", request.Abbreviation ?? string.Empty);
                parameters.Add("@CountryId", request.Country ?? 0);
                parameters.Add("@Name", request.Name ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/Province/Sql/get_criteria_province");
                var data = await dbConnection.QueryAsync<ProvinceDto>(query, parameters);
                var result = new ProvinceItemDto
                {
                    DataOfRecords = data.Count(),
                    ProvinceList = data.ToList(),
                };
                return new ApiResponse<ProvinceItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ProvinceItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitProvince(SubmitProvinceCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProvinceId", request.ProvinceId);
                parameters.Add("@Abbreviation", request.Abbreviation);
                parameters.Add("@Name", request.Name);
                parameters.Add("@ProvinceId", request.ProvinceId);
                parameters.Add("@Sort", request.Sort);
                parameters.Add("@IsDeleted", request.IsDeleted);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/Province/Sql/submit_province");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.Name} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.Name}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteProvince(DeleteProvinceCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProvinceId", request.ProvinceId);

                var query = await queryLoader.LoadQueryAsync("Global/Province/Sql/get_single_province");

                var data = await dbConnection.QueryFirstOrDefaultAsync<ProvinceDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<ProvinceDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("Global/Province/Sql/delete_province");
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
