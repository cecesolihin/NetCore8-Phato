using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Commands;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Service
{
    public class EmployeeWorkingExperienceService : IEmployeeWorkingExperienceService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeeWorkingExperienceService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeWorkingExperienceItemDto>> GetEmployeeWorkingExperience(GetEmployeeWorkingExperienceCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeID", request.FilterEmployeeId ?? 0);
                parameters.Add("@Company", request.FilterCompany ?? string.Empty);
                parameters.Add("@EmploymentTypeCode", request.FilterEmploymentTypeCode ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeWorkingExperience/Sql/get_emp_working_experience");
                var data = await db.QueryAsync<EmployeeWorkingExperienceDto>(query, parameters);

                var result = new EmployeeWorkingExperienceItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeWorkingExperienceList = data.ToList()
                };

                return new ApiResponse<EmployeeWorkingExperienceItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeWorkingExperienceItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Working Experience list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeWorkingExperienceDto>> GetSingleEmployeeWorkingExperience(GetSingleEmployeeWorkingExperienceCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmpWorkExperienceId", request.EmpWorkExperienceId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeWorkingExperience/Sql/get_single_emp_working_experience");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeWorkingExperienceDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeWorkingExperienceDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeeWorkingExperienceDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeWorkingExperienceDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Working Experience detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeWorkingExperienceItemDto>> GetEmployeeWorkingExperienceByCriteria(GetEmployeeWorkingExperienceByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@Company", request.FilterCompany ?? string.Empty);
                parameters.Add("@EmploymentTypeCode", request.FilterEmploymentTypeCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeWorkingExperience/Sql/get_criteria_emp_working_experience");
                var data = await db.QueryAsync<EmployeeWorkingExperienceDto>(query, parameters);

                var result = new EmployeeWorkingExperienceItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeWorkingExperienceList = data.ToList()
                };

                return new ApiResponse<EmployeeWorkingExperienceItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeWorkingExperienceItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Working Experience data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeWorkingExperience(SubmitEmployeeWorkingExperienceCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmpWorkExperienceId", request.EmpWorkExperienceId);
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@StartWorking", request.StartWorking);
                parameters.Add("@EndWorking", request.EndWorking);
                parameters.Add("@EmploymentTypeCode", request.EmploymentTypeCode);
                parameters.Add("@Organization", request.Organization);
                parameters.Add("@Company", request.Company);
                parameters.Add("@BusinessField", request.BusinessField);
                parameters.Add("@Address", request.Address);
                parameters.Add("@CityId", request.CityId);
                parameters.Add("@JobLevel", request.JobLevel);
                parameters.Add("@JobDescription", request.JobDescription);
                parameters.Add("@Phone", request.Phone);
                parameters.Add("@Website", request.Website);
                parameters.Add("@ReferenceName", request.ReferenceName);
                parameters.Add("@ReferencePhone", request.ReferencePhone);
                parameters.Add("@ReferenceEmail", request.ReferenceEmail);
                parameters.Add("@CurrencyCode21", request.CurrencyCode21);
                parameters.Add("@CurrencyCode15", request.CurrencyCode15);
                parameters.Add("@PphA21", request.PphA21);
                parameters.Add("@PphA15", request.PphA15);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeWorkingExperience/Sql/submit_emp_working_experience");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeWorkingExperience(DeleteEmployeeWorkingExperienceCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmpWorkExperienceId", request.EmpWorkExperienceId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeWorkingExperience/Sql/get_single_emp_working_experience");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeWorkingExperienceDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeWorkingExperienceDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeWorkingExperience/Sql/delete_emp_working_experience");
                await db.ExecuteAsync(query_delete, parameters);

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

