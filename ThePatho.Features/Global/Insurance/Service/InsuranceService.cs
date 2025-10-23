using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.Insurance.Commands;
using ThePatho.Features.Global.Insurance.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Insurance.Service
{
    public class InsuranceService : IInsuranceService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public InsuranceService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<InsuranceItemDto>> GetInsurance(GetInsuranceCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@InsuranceCode", request.FilterInsuranceCode ?? (object)DBNull.Value);
                parameters.Add("@InsuranceName", request.FilterInsuranceName ?? (object)DBNull.Value);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/Insurance/Sql/get_insurance");
                var data = await dbConnection.QueryAsync<InsuranceDto>(query, parameters);
                var result = new InsuranceItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    InsuranceList = data.ToList(),
                };
                return new ApiResponse<InsuranceItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<InsuranceItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<InsuranceDto>> GetSingleInsurance(GetSingleInsuranceCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InsuranceCode", request.FilterInsuranceCode ?? (object)DBNull.Value);

                var query = await queryLoader.LoadQueryAsync("Global/Insurance/Sql/get_single_insurance");

                var data = await dbConnection.QueryFirstOrDefaultAsync<InsuranceDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<InsuranceDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<InsuranceDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<InsuranceDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<InsuranceItemDto>> GetInsuranceByCriteria(GetInsuranceByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InsuranceCode", request.FilterInsuranceCode ?? (object)DBNull.Value);
                parameters.Add("@InsuranceName", request.FilterInsuranceName ?? (object)DBNull.Value);


                var query = await queryLoader.LoadQueryAsync("Global/Insurance/Sql/get_criteria_insurance");
                var data = await dbConnection.QueryAsync<InsuranceDto>(query, parameters);
                var result = new InsuranceItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    InsuranceList = data.ToList(),
                };
                return new ApiResponse<InsuranceItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<InsuranceItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitInsurance(SubmitInsuranceCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InsuranceCode", request.InsuranceCode);
                parameters.Add("@InsuranceName", request.InsuranceName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/Insurance/Sql/submit_insurance");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.InsuranceCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.InsuranceCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteInsurance(DeleteInsuranceCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@InsuranceCode", request.InsuranceCode);

                var query_single = await queryLoader.LoadQueryAsync("Global/Insurance/Sql/get_single_insurance");

                var data_single = await dbConnection.QueryFirstOrDefaultAsync<InsuranceDto>(query_single, parameters);

                if (data_single == null)
                {
                    return new ApiResponse<InsuranceDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query = await queryLoader.LoadQueryAsync("Global/Insurance/Sql/delete_insurance");
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
