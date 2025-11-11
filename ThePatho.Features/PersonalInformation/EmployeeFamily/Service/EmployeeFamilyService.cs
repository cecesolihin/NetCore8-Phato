using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeFamily.Commands;
using ThePatho.Features.PersonalInformation.EmployeeFamily.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.PersonalInformation.EmployeeFamily.Service
{
    public class EmployeeFamilyService : IEmployeeFamilyService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeeFamilyService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeFamilyItemDto>> GetEmployeeFamily(GetEmployeeFamilyCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@RelationCode", request.FilterRelationCode ?? string.Empty);
                parameters.Add("@FamilyName", request.FilterFamilyName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeFamily/Sql/get_emp_family");
                var data = await db.QueryAsync<EmployeeFamilyDto>(query, parameters);

                var result = new EmployeeFamilyItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeFamilyList = data.ToList()
                };

                return new ApiResponse<EmployeeFamilyItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeFamilyItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Family list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeFamilyDto>> GetSingleEmployeeFamily(GetSingleEmployeeFamilyCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeFamilyId", request.EmployeeFamilyId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeFamily/Sql/get_single_emp_family");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeFamilyDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<EmployeeFamilyDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeeFamilyDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeFamilyDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Family detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeFamilyItemDto>> GetEmployeeFamilyByCriteria(GetEmployeeFamilyByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@RelationCode", request.FilterRelationCode ?? string.Empty);
                parameters.Add("@FamilyName", request.FilterFamilyName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeFamily/Sql/get_criteria_emp_family");
                var data = await db.QueryAsync<EmployeeFamilyDto>(query, parameters);

                var result = new EmployeeFamilyItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeFamilyList = data.ToList()
                };

                return new ApiResponse<EmployeeFamilyItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeFamilyItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Family data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeFamily(SubmitEmployeeFamilyCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeFamilyId", request.EmployeeFamilyId);
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@RelationCode", request.RelationCode);
                parameters.Add("@FamilyName", request.FamilyName);
                parameters.Add("@Gender", request.Gender);
                parameters.Add("@BirthPlace", request.BirthPlace);
                parameters.Add("@BirthDate", request.BirthDate);
                parameters.Add("@Address", request.Address);
                parameters.Add("@Phone", request.Phone);
                parameters.Add("@BloodTypeCode", request.BloodTypeCode);
                parameters.Add("@EduLevelCode", request.EduLevelCode);
                parameters.Add("@MaritalStatusCode", request.MaritalStatusCode);
                parameters.Add("@DependentStatus", request.DependentStatus);
                parameters.Add("@EmergencyContact", request.EmergencyContact);
                parameters.Add("@WorkingStatus", request.WorkingStatus);
                parameters.Add("@VitalStatus", request.VitalStatus);
                parameters.Add("@Company", request.Company);
                parameters.Add("@Position", request.Position);
                parameters.Add("@KkNo", request.KkNo);
                parameters.Add("@IdentityNo", request.IdentityNo);
                parameters.Add("@BpjsNo", request.BpjsNo);
                parameters.Add("@InsuranceName", request.InsuranceName);
                parameters.Add("@PolisNo", request.PolisNo);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeFamily/Sql/submit_emp_family");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeFamily(DeleteEmployeeFamilyCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeFamilyId", request.EmployeeFamilyId);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeFamily/Sql/get_single_emp_family");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeFamilyDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<EmployeeFamilyDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeFamily/Sql/delete_emp_family");
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

