using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.CareerType.Commands;
using ThePatho.Features.Global.CareerType.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.CareerType.Service
{
    public class CareerTypeService : ICareerTypeService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public CareerTypeService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<CareerTypeItemDto>> GetCareerType(GetCareerTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@CareerTypeCode", request.FilterCareerTypeCode ?? (object)DBNull.Value);
                parameters.Add("@CareerTypeName", request.FilterCareerTypeName ?? (object)DBNull.Value);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/CareerType/Sql/get_careertype");
                var data = await dbConnection.QueryAsync<CareerTypeDto>(query, parameters);
                var result = new CareerTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    CareerTypeList = data.ToList(),
                };
                return new ApiResponse<CareerTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CareerTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<CareerTypeDto>> GetSingleCareerType(GetSingleCareerTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CareerTypeCode", request.FilterCareerTypeCode ?? (object)DBNull.Value);

                var query = await queryLoader.LoadQueryAsync("Global/CareerType/Sql/get_single_careertype");

                var data = await dbConnection.QueryFirstOrDefaultAsync<CareerTypeDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<CareerTypeDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<CareerTypeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CareerTypeDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<CareerTypeItemDto>> GetCareerTypeByCriteria(GetCareerTypeByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CareerTypeCode", request.CareerTypeCode ?? "");
                parameters.Add("@CareerTypeName", request.CareerTypeName ?? "");


                var query = await queryLoader.LoadQueryAsync("Global/CareerType/Sql/get_criteria_careertype");
                var data = await dbConnection.QueryAsync<CareerTypeDto>(query, parameters);
                var result = new CareerTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    CareerTypeList = data.ToList(),
                };
                return new ApiResponse<CareerTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CareerTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitCareerType(SubmitCareerTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CareerTypeCode", request.CareerTypeCode);
                parameters.Add("@CareerTypeName", request.CareerTypeName);
                parameters.Add("@Action", request.Action);
                var userName = currentUserService.GetUserName();
                parameters.Add("@User", string.IsNullOrWhiteSpace(userName) ? "admin" : userName);

                var query = await queryLoader.LoadQueryAsync("Global/CareerType/Sql/submit_careertype");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.CareerTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.CareerTypeCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteCareerType(DeleteCareerTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CareerTypeCode", request.CareerTypeCode);

                var query_single = await queryLoader.LoadQueryAsync("Global/CareerType/Sql/get_single_careertype");

                var data_single = await dbConnection.QueryFirstOrDefaultAsync<CareerTypeDto>(query_single, parameters);

                if (data_single == null)
                {
                    return new ApiResponse<CareerTypeDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query = await queryLoader.LoadQueryAsync("Global/CareerType/Sql/delete_careertype");
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
