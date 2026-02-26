using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.Country.Commands;
using ThePatho.Features.Global.Country.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.Country.Service
{
    public class CountryService : ICountryService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public CountryService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<CountryItemDto>> GetCountry(GetCountryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@Name", request.FilterName ?? string.Empty);
                parameters.Add("@NumericIsoCode", request.FilterNumericIsoCode ?? 0);
                parameters.Add("@ThreeLetterIsoCode", request.FilterThreeLetterIsoCode ?? string.Empty);
                parameters.Add("@TwoLetterIsoCode", request.FilterTwoLetterIsoCode ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/Country/Sql/get_country");
                var data = await dbConnection.QueryAsync<CountryDto>(query, parameters);
                var result = new CountryItemDto
                {
                    DataOfRecords = data.Count(),
                    CountryList = data.ToList(),
                };
                return new ApiResponse<CountryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CountryItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<CountryDto>> GetSingleCountry(GetSingleCountryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CountryId", request.FilterCountryId);

                var query = await queryLoader.LoadQueryAsync("Global/Country/Sql/get_single_country");

                var data = await dbConnection.QueryFirstOrDefaultAsync<CountryDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<CountryDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<CountryDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CountryDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<CountryItemDto>> GetCountryByCriteria(GetCountryByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", request.Name ?? string.Empty);
                parameters.Add("@NumericIsoCode", request.NumericIsoCode ?? 0);
                parameters.Add("@ThreeLetterIsoCode", request.ThreeLetterIsoCode ?? string.Empty);
                parameters.Add("@TwoLetterIsoCode", request.TwoLetterIsoCode ?? string.Empty);


                var query = await queryLoader.LoadQueryAsync("Global/Country/Sql/get_criteria_country");
                var data = await dbConnection.QueryAsync<CountryDto>(query, parameters);
                var result = new CountryItemDto
                {
                    DataOfRecords = data.Count(),
                    CountryList = data.ToList(),
                };
                return new ApiResponse<CountryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CountryItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitCountry(SubmitCountryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CountryId", request.CountryId);
                parameters.Add("@Name", request.Name);
                parameters.Add("@NumericIsoCode", request.NumericIsoCode);
                parameters.Add("@ThreeLetterIsoCode", request.ThreeLetterIsoCode);
                parameters.Add("@TwoLetterIsoCode", request.TwoLetterIsoCode);
                parameters.Add("@Sort", request.Sort);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/Country/Sql/submit_country");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.Name} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.Name}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteCountry(DeleteCountryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CountryId", request.CountryId);
                var query = await queryLoader.LoadQueryAsync("Global/Country/Sql/get_single_country");

                var data = await dbConnection.QueryFirstOrDefaultAsync<CountryDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<CountryDto>(HttpStatusCode.NotFound, "data not found");
                }
                var query_delete = await queryLoader.LoadQueryAsync("Global/Country/Sql/delete_country");
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
