using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.TaxStatus.Commands;
using ThePatho.Features.Global.TaxStatus.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.TaxStatus.Service
{
    public class TaxStatusService : ITaxStatusService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public TaxStatusService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService =_currentUserService;
        }

        public async Task<ApiResponse<TaxStatusItemDto>> GetTaxStatus(GetTaxStatusCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@TaxStatusCode", request.FilterTaxStatusCode ?? string.Empty);
                parameters.Add("@TaxStatusName", request.FilterTaxStatusName ?? string.Empty);
                parameters.Add("@Married", request.FilterMarried ?? string.Empty);
                parameters.Add("@TotalDependents", request.FilterTotalDependents ?? 0);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/TaxStatus/Sql/get_tax_status");
                var data = await db.QueryAsync<TaxStatusDto>(query, parameters);

                var result = new TaxStatusItemDto
                {
                    DataOfRecords = data.Count(),
                    TaxStatusList = data.ToList()
                };

                return new ApiResponse<TaxStatusItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TaxStatusItemDto>(HttpStatusCode.BadRequest, "Error retrieving Tax Status list.", ex.Message);
            }
        }

        public async Task<ApiResponse<TaxStatusDto>> GetSingleTaxStatus(GetSingleTaxStatusCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@TaxStatusCode", request.FilterTaxStatusCode);

                var query = await queryLoader.LoadQueryAsync("Global/TaxStatus/Sql/get_single_tax_status");
                var data = await db.QueryFirstOrDefaultAsync<TaxStatusDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<TaxStatusDto>(HttpStatusCode.NotFound, $"Data not Found", "Data not Found");
                }

                return new ApiResponse<TaxStatusDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TaxStatusDto>(HttpStatusCode.BadRequest, "Error retrieving Tax Status detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<TaxStatusItemDto>> GetTaxStatusByCriteria(GetTaxStatusByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@TaxStatusCode", request.TaxStatusCode);
                parameters.Add("@TaxStatusName", request.TaxStatusName);
                parameters.Add("@Married", request.Married ?? string.Empty);
                parameters.Add("@TotalDependents", request.TotalDependents ?? 0);

                var query = await queryLoader.LoadQueryAsync("Global/TaxStatus/Sql/get_criteria_tax_status");
                var data = await db.QueryAsync<TaxStatusDto>(query, parameters);

                var result = new TaxStatusItemDto
                {
                    DataOfRecords = data.Count(),
                    TaxStatusList = data.ToList()
                };

                return new ApiResponse<TaxStatusItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TaxStatusItemDto>(HttpStatusCode.BadRequest, "Error filtering Tax Status data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitTaxStatus(SubmitTaxStatusCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var ArgumentException = new List<string>();

                if (string.IsNullOrWhiteSpace(request.TaxStatusCode))
                    ArgumentException.Add("Tax Status Code is required.");

                if (string.IsNullOrWhiteSpace(request.TaxStatusName))
                    ArgumentException.Add("Tax Status Name is required.");

                if (ArgumentException.Any())
                {
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.TaxStatusName}", string.Join(", ", ArgumentException.ToArray()));
                }

                var parameters = new DynamicParameters();
                parameters.Add("@TaxStatusCode", request.TaxStatusCode);
                parameters.Add("@TaxStatusName", request.TaxStatusName);
                parameters.Add("@Married", request.Married);
                parameters.Add("@TotalDependents", request.TotalDependents);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/TaxStatus/Sql/submit_tax_status");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.TaxStatusCode} successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.TaxStatusCode}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteTaxStatus(DeleteTaxStatusCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@TaxStatusCode", request.TaxStatusCode);
                var query_single = await queryLoader.LoadQueryAsync("Global/TaxStatus/Sql/get_single_tax_status");
                var data_single = await db.QueryFirstOrDefaultAsync<TaxStatusDto>(query_single, parameters);
                if (data_single == null)
                {
                    return new ApiResponse(HttpStatusCode.NotFound, $"Failed to delete", "Data not Found");
                }
                var query = await queryLoader.LoadQueryAsync("Global/TaxStatus/Sql/delete_tax_status");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.TaxStatusCode} successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.TaxStatusCode}", ex.Message);
            }
        }
    }
}
