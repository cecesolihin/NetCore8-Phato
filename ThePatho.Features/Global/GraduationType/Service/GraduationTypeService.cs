using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.GraduationType.Commands;
using ThePatho.Features.Global.GraduationType.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.GraduationType.Service
{
    public class GraduationTypeService : IGraduationTypeService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public GraduationTypeService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<GraduationTypeItemDto>> GetGraduationType(GetGraduationTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@GradTypeCode", request.FilterGradTypeCode ?? string.Empty);
                parameters.Add("@GradTypeName", request.FilterGradTypeName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/GraduationType/Sql/get_graduationtype");
                var data = await dbConnection.QueryAsync<GraduationTypeDto>(query, parameters);
                var result = new GraduationTypeItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    GraduationTypeList = data.ToList(),
                };
                return new ApiResponse<GraduationTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<GraduationTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<GraduationTypeDto>> GetSingleGraduationType(GetSingleGraduationTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@GradTypeCode", request.FilterGradTypeCode);

                var query = await queryLoader.LoadQueryAsync("Global/GraduationType/Sql/get_single_graduationtype");

                var data = await dbConnection.QueryFirstOrDefaultAsync<GraduationTypeDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<GraduationTypeDto>(HttpStatusCode.NotFound, "data not found", null);
                }
                return new ApiResponse<GraduationTypeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<GraduationTypeDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<GraduationTypeItemDto>> GetGraduationTypeByCriteria(GetGraduationTypeByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@GradTypeCode", request.FilterGradTypeCode ?? string.Empty);
                parameters.Add("@GradTypeName", request.FilterGradTypeName ?? string.Empty);


                var query = await queryLoader.LoadQueryAsync("Global/GraduationType/Sql/get_criteria_graduationtype");
                var data = await dbConnection.QueryAsync<GraduationTypeDto>(query, parameters);
                var result = new GraduationTypeItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    GraduationTypeList = data.ToList(),
                };
                return new ApiResponse<GraduationTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<GraduationTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitGraduationType(SubmitGraduationTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@GradTypeCode", request.GradTypeCode);
                parameters.Add("@GradTypeName", request.GradTypeName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/GraduationType/Sql/submit_graduationtype");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.GradTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.GradTypeCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteGraduationType(DeleteGraduationTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@GradTypeCode", request.GradTypeCode);
                var query_single = await queryLoader.LoadQueryAsync("Global/GraduationType/Sql/get_single_graduationtype");

                var data_single = await dbConnection.QueryFirstOrDefaultAsync<GraduationTypeDto>(query_single, parameters);
                if (data_single == null)
                {
                    return new ApiResponse(HttpStatusCode.NotFound, $"Failed to delete", "data not found");
                }
                var query = await queryLoader.LoadQueryAsync("Global/GraduationType/Sql/delete_graduationtype");
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
