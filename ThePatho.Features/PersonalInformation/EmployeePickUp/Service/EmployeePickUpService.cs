using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeePickUp.Commands;
using ThePatho.Features.PersonalInformation.EmployeePickUp.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeePickUp.Service
{
    public class EmployeePickUpService : IEmployeePickUpService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        #endregion

        #region [CTOR]
        public EmployeePickUpService(DapperContext _dapperContext, SqlQueryLoader _queryLoader)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeePickUpItemDto>> GetEmployeePickUp(GetEmployeePickUpCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@PickUpId", request.FilterPickUpId ?? (object)DBNull.Value);
                parameters.Add("@PickUpLocation", request.FilterPickUpLocation ?? (object)DBNull.Value);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePickUp/Sql/get_employeepickup");
                var data = await db.QueryAsync<EmployeePickUpDto>(query, parameters);

                var result = new EmployeePickUpItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeePickUpList = data.ToList()
                };

                return new ApiResponse<EmployeePickUpItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeePickUpItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Pick Up list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeePickUpDto>> GetSingleEmployeePickUp(GetSingleEmployeePickUpCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PickUpId", request.FilterPickUpId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePickUp/Sql/get_single_employeepickup");
                var data = await db.QueryFirstOrDefaultAsync<EmployeePickUpDto>(query, parameters);

                return new ApiResponse<EmployeePickUpDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeePickUpDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Pick Up detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeePickUpItemDto>> GetEmployeePickUpByCriteria(GetEmployeePickUpByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PickUpId", request.FilterPickUpId ?? (object)DBNull.Value);
                parameters.Add("@PickUpLocation", request.FilterPickUpLocation ?? (object)DBNull.Value);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePickUp/Sql/get_criteria_employeepickup");
                var data = await db.QueryAsync<EmployeePickUpDto>(query, parameters);

                var result = new EmployeePickUpItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeePickUpList = data.ToList()
                };

                return new ApiResponse<EmployeePickUpItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeePickUpItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Pick Up data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeePickUp(SubmitEmployeePickUpCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.PickUpId);
                parameters.Add("@TrainingCourseCode", request.PickUpLocation);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePickUp/Sql/submit_employeepickup");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeePickUp(DeleteEmployeePickUpCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PickUpId", request.FilterPickUpId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePickUp/Sql/delete_employeepickup");
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

