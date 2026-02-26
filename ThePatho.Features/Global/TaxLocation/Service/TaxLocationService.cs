using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.TaxLocation.Commands;
using ThePatho.Features.Global.TaxLocation.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.TaxLocation.Service
{
    public class TaxLocationService : ITaxLocationService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public TaxLocationService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<TaxLocationItemDto>> GetTaxLocation(GetTaxLocationCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@TaxLocationCode", request.FilterTaxLocationCode ?? string.Empty);
                parameters.Add("@TaxLocationName", request.FilterTaxLocationName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/TaxLocation/Sql/get_taxlocation");
                var data = await dbConnection.QueryAsync<TaxLocationDto>(query, parameters);
                var result = new TaxLocationItemDto
                {
                    DataOfRecords = data.Count(),
                    TaxLocationList = data.ToList(),
                };
                return new ApiResponse<TaxLocationItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TaxLocationItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<TaxLocationDto>> GetSingleTaxLocation(GetSingleTaxLocationCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TaxLocationCode", request.TaxLocationCode);

                var query = await queryLoader.LoadQueryAsync("Global/TaxLocation/Sql/get_single_taxlocation");

                var data = await dbConnection.QueryFirstOrDefaultAsync<TaxLocationDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<TaxLocationDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<TaxLocationDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TaxLocationDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<TaxLocationItemDto>> GetTaxLocationByCriteria(GetTaxLocationByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TaxLocationCode", request.TaxLocationCode ?? string.Empty);
                parameters.Add("@TaxLocationName", request.TaxLocationName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/TaxLocation/Sql/get_criteria_taxlocation");
                var data = await dbConnection.QueryAsync<TaxLocationDto>(query, parameters);
                var result = new TaxLocationItemDto
                {
                    DataOfRecords = data.Count(),
                    TaxLocationList = data.ToList(),
                };
                return new ApiResponse<TaxLocationItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TaxLocationItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitTaxLocation(SubmitTaxLocationCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TaxLocationCode", request.TaxLocationCode);
                parameters.Add("@TaxLocationName", request.TaxLocationName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/TaxLocation/Sql/submit_taxlocation");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.TaxLocationName} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.TaxLocationName}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteTaxLocation(DeleteTaxLocationCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TaxLocationCode", request.TaxLocationCode);

                var query = await queryLoader.LoadQueryAsync("Global/TaxLocation/Sql/get_single_taxlocation");

                var data = await dbConnection.QueryFirstOrDefaultAsync<TaxLocationDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<TaxLocationDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("Global/TaxLocation/Sql/delete_taxlocation");
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
