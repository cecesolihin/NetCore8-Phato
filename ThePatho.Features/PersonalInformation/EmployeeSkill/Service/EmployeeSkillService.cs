using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeSkill.Commands;
using ThePatho.Features.PersonalInformation.EmployeeSkill.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeSkill.Service
{
    public class EmployeeSkillService : IEmployeeSkillService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        #endregion

        #region [CTOR]
        public EmployeeSkillService(DapperContext _dapperContext, SqlQueryLoader _queryLoader)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeSkillItemDto>> GetEmployeeSkill(GetEmployeeSkillCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@SkillCode", request.FilterSkillCode ?? string.Empty);
                parameters.Add("@ProfiencyCode", request.FilterProfiencyCode ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeSkill/Sql/get_emp_skill");
                var data = await db.QueryAsync<EmployeeSkillDto>(query, parameters);

                var result = new EmployeeSkillItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeSkillList = data.ToList()
                };

                return new ApiResponse<EmployeeSkillItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeSkillItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Skill list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeSkillDto>> GetSingleEmployeeSkill(GetSingleEmployeeSkillCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@SkillCode", request.SkillCode);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeSkill/Sql/get_single_emp_skill");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeSkillDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeSkillDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeeSkillDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeSkillDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Skill detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeSkillItemDto>> GetEmployeeSkillByCriteria(GetEmployeeSkillByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@SkillCode", request.FilterSkillCode ?? string.Empty);
                parameters.Add("@ProfiencyCode", request.FilterProfiencyCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeSkill/Sql/get_criteria_emp_skill");
                var data = await db.QueryAsync<EmployeeSkillDto>(query, parameters);

                var result = new EmployeeSkillItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeSkillList = data.ToList()
                };

                return new ApiResponse<EmployeeSkillItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeSkillItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Skill data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeSkill(SubmitEmployeeSkillCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@SkillCode", request.SkillCode);
                parameters.Add("@ProfiencyCode", request.ProfiencyCode);
                parameters.Add("@Description", request.Description);
                parameters.Add("@TakenDate", request.TakenDate);
                parameters.Add("@ExpiredDate", request.ExpiredDate);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@IsDeleted", request.IsDeleted);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeSkill/Sql/submit_emp_skill");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeSkill(DeleteEmployeeSkillCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@SkillCode", request.SkillCode);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeSkill/Sql/get_single_emp_skill");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeSkillDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeSkillDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeSkill/Sql/delete_emp_skill");
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

