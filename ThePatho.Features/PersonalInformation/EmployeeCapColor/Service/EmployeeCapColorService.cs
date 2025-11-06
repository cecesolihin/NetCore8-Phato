using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeCapColor.Commands;
using ThePatho.Features.PersonalInformation.EmployeeCapColor.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeCapColor.Service
{
    public class EmployeeCapColorService : IEmployeeCapColorService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        #endregion

        #region [CTOR]
        public EmployeeCapColorService(DapperContext _dapperContext, SqlQueryLoader _queryLoader)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeCapColorItemDto>> GetEmployeeCapColor(GetEmployeeCapColorCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@ColorName", request.FilterColorName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeCapColor/Sql/get_emp_capcolor");
                var data = await db.QueryAsync<EmployeeCapColorDto>(query, parameters);

                var result = new EmployeeCapColorItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeCapColorList = data.ToList()
                };

                return new ApiResponse<EmployeeCapColorItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeCapColorItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Cap Color list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeCapColorDto>> GetSingleEmployeeCapColor(GetSingleEmployeeCapColorCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@CapColorId", request.CapColorId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeCapColor/Sql/get_single_emp_capcolor");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeCapColorDto>(query, parameters);

                return new ApiResponse<EmployeeCapColorDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeCapColorDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Cap Color detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeCapColorItemDto>> GetEmployeeCapColorByCriteria(GetEmployeeCapColorByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@ColorName", request.FilterColorName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeCapColor/Sql/get_criteria_emp_capcolor");
                var data = await db.QueryAsync<EmployeeCapColorDto>(query, parameters);

                var result = new EmployeeCapColorItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeCapColorList = data.ToList()
                };

                return new ApiResponse<EmployeeCapColorItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeCapColorItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Cap Color data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeCapColor(SubmitEmployeeCapColorCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@CapColorId", request.CapColorId);
                parameters.Add("@ColorName", request.ColorName);
                parameters.Add("@InsertedBy", request.InsertedBy);
                parameters.Add("@InsertedDate", request.InsertedDate);
                parameters.Add("@ModifiedBy", request.ModifiedBy);
                parameters.Add("@ModifiedDate", request.ModifiedDate);
                parameters.Add("@IsDeleted", request.IsDeleted);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeCapColor/Sql/submit_emp_capcolor");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeCapColor(DeleteEmployeeCapColorCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@CapColorId", request.CapColorId);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeCapColor/Sql/delete_emp_capcolor");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message);
            }
        }
        #endregion
    }
}

