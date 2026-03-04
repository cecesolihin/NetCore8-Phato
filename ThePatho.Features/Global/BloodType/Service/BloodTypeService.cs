using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.BloodType.Commands;
using ThePatho.Features.Global.BloodType.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.BloodType.Service
{
    public class BloodTypeService : IBloodTypeService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;

        public BloodTypeService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<BloodTypeItemDto>> GetBloodType(GetBloodTypeCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@BloodTypeCode", request.FilterBloodTypeCode ?? string.Empty);
                parameters.Add("@BloodTypeName", request.FilterBloodTypeName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/BloodType/Sql/get_blood_type");
                var data = await db.QueryAsync<BloodTypeDto>(query, parameters);

                var result = new BloodTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    BloodTypeList = data.ToList()
                };

                return new ApiResponse<BloodTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<BloodTypeItemDto>(HttpStatusCode.BadRequest, "Error retrieving Blood Type list.", ex.Message);
            }
        }

        public async Task<ApiResponse<BloodTypeDto>> GetSingleBloodType(GetSingleBloodTypeCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@BloodTypeCode", request.FilterBloodTypeCode);

                var query = await queryLoader.LoadQueryAsync("Global/BloodType/Sql/get_single_blood_type");
                var data = await db.QueryFirstOrDefaultAsync<BloodTypeDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<BloodTypeDto>(HttpStatusCode.NotFound, $"Data not Found", "Data not Found");
                }

                return new ApiResponse<BloodTypeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<BloodTypeDto>(HttpStatusCode.BadRequest, "Error retrieving Blood Type detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<BloodTypeItemDto>> GetBloodTypeByCriteria(GetBloodTypeByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@BloodTypeCode", request.BloodTypeCode);
                parameters.Add("@BloodTypeName", request.BloodTypeName);

                var query = await queryLoader.LoadQueryAsync("Global/BloodType/Sql/get_criteria_blood_type");
                var data = await db.QueryAsync<BloodTypeDto>(query, parameters);

                var result = new BloodTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    BloodTypeList = data.ToList()
                };

                return new ApiResponse<BloodTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<BloodTypeItemDto>(HttpStatusCode.BadRequest, "Error filtering Blood Type data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitBloodType(SubmitBloodTypeCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var ArgumentException = new List<string>();

                if (string.IsNullOrWhiteSpace(request.BloodTypeCode))
                    ArgumentException.Add("Blood Type Code is required.");

                if (string.IsNullOrWhiteSpace(request.BloodTypeName))
                    ArgumentException.Add("Blood Type Name is required.");

                if (ArgumentException.Any())
                {
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.BloodTypeName}", string.Join(", ", ArgumentException.ToArray()));
                }

                var parameters = new DynamicParameters();
                parameters.Add("@BloodTypeCode", request.BloodTypeCode);
                parameters.Add("@BloodTypeName", request.BloodTypeName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/BloodType/Sql/submit_blood_type");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.BloodTypeCode} successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.BloodTypeCode}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteBloodType(DeleteBloodTypeCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@BloodTypeCode", request.BloodTypeCode);
                var query_single = await queryLoader.LoadQueryAsync("Global/BloodType/Sql/get_single_blood_type");
                var data_single = await db.QueryFirstOrDefaultAsync<BloodTypeDto>(query_single, parameters);
                if (data_single == null)
                {
                    return new ApiResponse(HttpStatusCode.NotFound, $"Failed to delete", "Data not Found");
                }
                var query = await queryLoader.LoadQueryAsync("Global/BloodType/Sql/delete_blood_type");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.BloodTypeCode} successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.BloodTypeCode}", ex.Message);
            }
        }
    }
}
