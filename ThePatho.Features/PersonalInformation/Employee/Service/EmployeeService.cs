using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.Employee.Commands;
using ThePatho.Features.PersonalInformation.Employee.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.Employee.Service
{
    public class EmployeeService : IEmployeeService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        #endregion

        #region [CTOR]
        public EmployeeService(DapperContext _dapperContext, SqlQueryLoader _queryLoader)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeItemDto>> GetEmployee(GetEmployeeCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeNo", request.FilterEmployeeNo ?? (object)DBNull.Value);
                parameters.Add("@Fullname", request.FilterFullname ?? (object)DBNull.Value);
                parameters.Add("@EmploymentTypeCode", request.FilterEmploymentTypeCode ?? (object)DBNull.Value);
                parameters.Add("@JobClassCode", request.FilterJobClassCode ?? (object)DBNull.Value);
                parameters.Add("@PositionCode", request.FilterPositionCode ?? (object)DBNull.Value);
                parameters.Add("@WorkLocationCode", request.FilterWorkLocationCode ?? (object)DBNull.Value);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/Employee/Sql/get_employee");
                var data = await db.QueryAsync<EmployeeDto>(query, parameters);

                var result = new EmployeeItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeList = data.ToList()
                };

                return new ApiResponse<EmployeeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeItemDto>(HttpStatusCode.BadRequest, "Error retrieving Blood Type list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeDto>> GetSingleEmployee(GetSingleEmployeeCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/Employee/Sql/get_singel_employee");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeDto>(query, parameters);

                return new ApiResponse<EmployeeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeDto>(HttpStatusCode.BadRequest, "Error retrieving Blood Type detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeItemDto>> GetEmployeeByCriteria(GetEmployeeByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeNo", request.FilterEmployeeNo ?? (object)DBNull.Value);
                parameters.Add("@Fullname", request.FilterFullname ?? (object)DBNull.Value);
                parameters.Add("@EmploymentTypeCode", request.FilterEmploymentTypeCode ?? (object)DBNull.Value);
                parameters.Add("@JobClassCode", request.FilterJobClassCode ?? (object)DBNull.Value);
                parameters.Add("@PositionCode", request.FilterPositionCode ?? (object)DBNull.Value);
                parameters.Add("@WorkLocationCode", request.FilterWorkLocationCode ?? (object)DBNull.Value);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/Employee/Sql/get_criteria_employee");
                var data = await db.QueryAsync<EmployeeDto>(query, parameters);

                var result = new EmployeeItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeList = data.ToList()
                };

                return new ApiResponse<EmployeeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeItemDto>(HttpStatusCode.BadRequest, "Error filtering Blood Type data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployee(SubmitEmployeeCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@EmployeeNo", request.EmployeeNo);
                parameters.Add("@CompanyCode", request.CompanyCode);
                parameters.Add("@Firstname", request.Firstname);
                parameters.Add("@MiddleName", request.MiddleName);
                parameters.Add("@LastName", request.LastName);
                parameters.Add("@Fullname", request.Fullname);
                parameters.Add("@PositionCode", request.PositionCode);
                parameters.Add("@Gender", request.Gender);
                parameters.Add("@BirthPlace", request.BirthPlace);
                parameters.Add("@BirthDate", request.BirthDate);
                parameters.Add("@JoinDate", request.JoinDate);
                parameters.Add("@TerminateDate", request.TerminateDate);
                parameters.Add("@PermanentDate", request.PermanentDate);
                parameters.Add("@PensionDate", request.PensionDate);
                parameters.Add("@JobClassCode", request.JobClassCode);
                parameters.Add("@EmploymentTypeCode", request.EmploymentTypeCode);
                parameters.Add("@CostCenterCode", request.CostCenterCode);
                parameters.Add("@TaxType", request.TaxType);
                parameters.Add("@TaxStatusCode", request.TaxStatusCode);
                parameters.Add("@Npwp", request.Npwp);
                parameters.Add("@AttendanceId", request.AttendanceId);
                parameters.Add("@IsDeleted", request.IsDeleted);
                parameters.Add("@WorkLocationCode", request.WorkLocationCode);
                parameters.Add("@InsertedBy", request.InsertedBy);
                parameters.Add("@InsertedDate", request.InsertedDate);
                parameters.Add("@ModifiedBy", request.ModifiedBy);
                parameters.Add("@ModifiedDate", request.ModifiedDate);
                parameters.Add("@TaxLocationId", request.TaxLocationId);
                parameters.Add("@NeedReplacement", request.NeedReplacement);
                parameters.Add("@BpjstkLocation", request.BpjstkLocation);
                parameters.Add("@BpjskesLocation", request.BpjskesLocation);
                parameters.Add("@CapColorId", request.CapColorId);
                parameters.Add("@PickUpId", request.PickUpId);
                parameters.Add("@ContractEndDate", request.ContractEndDate);
                parameters.Add("@JabatanId", request.JabatanId);
                parameters.Add("@IsEligibleRehire", request.IsEligibleRehire);
                parameters.Add("@FaskesId", request.FaskesId);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/Employee/Sql/submit_employee");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployee(DeleteEmployeeCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/Employee/Sql/delete_employee");
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

