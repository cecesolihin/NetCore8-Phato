using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Commands;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Service
{
    public class EmployeeCareerHistoryService : IEmployeeCareerHistoryService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        #endregion

        #region [CTOR]
        public EmployeeCareerHistoryService(DapperContext _dapperContext, SqlQueryLoader _queryLoader)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeCareerHistoryItemDto>> GetEmployeeCareerHistory(GetEmployeeCareerHistoryCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? (object)DBNull.Value);
                parameters.Add("@CareerHistoryNo", request.FilterCareerHistoryNo ?? (object)DBNull.Value);
                parameters.Add("@PositionCode", request.FilterPositionCode ?? (object)DBNull.Value);
                parameters.Add("@CompanyCode", request.FilterCompanyCode ?? (object)DBNull.Value);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeCareerHistory/Sql/get_emp_career");
                var data = await db.QueryAsync<EmployeeCareerHistoryDto>(query, parameters);

                var result = new EmployeeCareerHistoryItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeCareerHistoryList = data.ToList()
                };

                return new ApiResponse<EmployeeCareerHistoryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeCareerHistoryItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Career History list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeCareerHistoryDto>> GetSingleEmployeeCareerHistory(GetSingleEmployeeCareerHistoryCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@CareerHistoryNo", request.CareerHistoryNo);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeCareerHistory/Sql/get_single_emp_career");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeCareerHistoryDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeCareerHistoryDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeeCareerHistoryDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeCareerHistoryDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Career History detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeCareerHistoryItemDto>> GetEmployeeCareerHistoryByCriteria(GetEmployeeCareerHistoryByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@CareerHistoryNo", request.FilterCareerHistoryNo ?? (object)DBNull.Value);
                parameters.Add("@PositionCode", request.FilterPositionCode ?? (object)DBNull.Value);
                parameters.Add("@CompanyCode", request.FilterCompanyCode ?? (object)DBNull.Value);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeCareerHistory/Sql/get_criteria_emp_career");
                var data = await db.QueryAsync<EmployeeCareerHistoryDto>(query, parameters);

                var result = new EmployeeCareerHistoryItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeCareerHistoryList = data.ToList()
                };

                return new ApiResponse<EmployeeCareerHistoryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeCareerHistoryItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Career History data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeCareerHistory(SubmitEmployeeCareerHistoryCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@CareerHistoryNo", request.CareerHistoryNo);
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@EmployeeNo", request.EmployeeNo);
                parameters.Add("@CompanyCode", request.CompanyCode);
                parameters.Add("@EmploymentTypeCode", request.EmploymentTypeCode);
                parameters.Add("@ChangeType", request.ChangeType);
                parameters.Add("@PositionCode", request.PositionCode);
                parameters.Add("@OrgStructureId", request.OrgStructureId);
                parameters.Add("@JobLevelCode", request.JobLevelCode);
                parameters.Add("@JobClassCode", request.JobClassCode);
                parameters.Add("@GradeCode", request.GradeCode);
                parameters.Add("@RankCode", request.RankCode);
                parameters.Add("@CostCenterCode", request.CostCenterCode);
                parameters.Add("@StartDate", request.StartDate);
                parameters.Add("@EndDate", request.EndDate);
                parameters.Add("@Remark", request.Remark);
                parameters.Add("@IsDeleted", request.IsDeleted);
                parameters.Add("@WorkLocationCode", request.WorkLocationCode);
                parameters.Add("@ResignTypeCode", request.ResignTypeCode);
                parameters.Add("@TerminationTypeCode", request.TerminationTypeCode);
                parameters.Add("@PensionTypeCode", request.PensionTypeCode);
                parameters.Add("@AssignmentLocation", request.AssignmentLocation);
                parameters.Add("@EffectiveDateTo", request.EffectiveDateTo);
                parameters.Add("@TaxLocationId", request.TaxLocationId);
                parameters.Add("@IsIncludeSalary", request.IsIncludeSalary);
                parameters.Add("@EmpSalCompId", request.EmpSalCompId);
                parameters.Add("@MutationTypeCode", request.MutationTypeCode);
                parameters.Add("@UsePayrollData", request.UsePayrollData);
                parameters.Add("@UseOldJoinDate", request.UseOldJoinDate);
                parameters.Add("@JoinDate", request.JoinDate);
                parameters.Add("@OldEmployeeId", request.OldEmployeeId);
                parameters.Add("@Path", request.Path);
                parameters.Add("@JabatanId", request.JabatanId);
                parameters.Add("@IsEligibleRehire", request.IsEligibleRehire);
                parameters.Add("@InsertedBy", request.InsertedBy);
                parameters.Add("@InsertedDate", request.InsertedDate);
                parameters.Add("@ModifiedBy", request.ModifiedBy);
                parameters.Add("@ModifiedDate", request.ModifiedDate);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeCareerHistory/Sql/submit_emp_career");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeCareerHistory(DeleteEmployeeCareerHistoryCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeID", request.EmployeeId);
                parameters.Add("@CareerHistoryNo", request.CareerHistoryNo);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeCareerHistory/Sql/get_single_emp_career");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeCareerHistoryDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeCareerHistoryDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeCareerHistory/Sql/delete_emp_career");
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

