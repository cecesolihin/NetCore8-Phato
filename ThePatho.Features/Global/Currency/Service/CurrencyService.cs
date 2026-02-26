using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.Currency.Commands;
using ThePatho.Features.Global.Currency.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.Currency.Service
{
    public class CurrencyService : ICurrencyService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public CurrencyService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<CurrencyItemDto>> GetCurrency(GetCurrencyCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@CurrencyCode", request.FilterCurrencyCode ?? string.Empty);
                parameters.Add("@CurrencyName", request.FilterCurrencyName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/Currency/Sql/get_currency");
                var data = await dbConnection.QueryAsync<CurrencyDto>(query, parameters);
                var result = new CurrencyItemDto
                {
                    DataOfRecords = data.Count(),
                    CurrencyList = data.ToList(),
                };
                return new ApiResponse<CurrencyItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CurrencyItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<CurrencyDto>> GetSingleCurrency(GetSingleCurrencyCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CurrencyCode", request.FilterCurrencyCode);

                var query = await queryLoader.LoadQueryAsync("Global/Currency/Sql/get_single_currency");

                var data = await dbConnection.QueryFirstOrDefaultAsync<CurrencyDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<CurrencyDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<CurrencyDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CurrencyDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<CurrencyItemDto>> GetCurrencyByCriteria(GetCurrencyByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CurrencyCode", request.CurrencyCode ?? string.Empty);
                parameters.Add("@CurrencyName", request.CurrencyName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/Currency/Sql/get_criteria_currency");
                var data = await dbConnection.QueryAsync<CurrencyDto>(query, parameters);
                var result = new CurrencyItemDto
                {
                    DataOfRecords = data.Count(),
                    CurrencyList = data.ToList(),
                };
                return new ApiResponse<CurrencyItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CurrencyItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitCurrency(SubmitCurrencyCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CurrencyCode", request.CurrencyCode);
                parameters.Add("@CurrencyName", request.CurrencyName);
                parameters.Add("@Symbol", request.Symbol);
                parameters.Add("@DecimalDigit", request.DecimalDigit);
                parameters.Add("@IsDefault", request.IsDefault);
                parameters.Add("@Action", request.Action);
                var userName = currentUserService.GetUserName();
                parameters.Add("@User", string.IsNullOrWhiteSpace(userName) ? "admin" : userName);

                var query = await queryLoader.LoadQueryAsync("Global/Currency/Sql/submit_currency");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.CurrencyCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.CurrencyCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteCurrency(DeleteCurrencyCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CurrencyCode", request.CurrencyCode);
                var query = await queryLoader.LoadQueryAsync("Global/Currency/Sql/get_single_currency");

                var data = await dbConnection.QueryFirstOrDefaultAsync<CurrencyDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse(HttpStatusCode.NotFound, "data not found");
                }
                var query_delete = await queryLoader.LoadQueryAsync("Global/Currency/Sql/delete_currency");
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
