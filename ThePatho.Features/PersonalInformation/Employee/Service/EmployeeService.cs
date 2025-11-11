using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.Employee.Commands;
using ThePatho.Features.PersonalInformation.Employee.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.QueryExecute;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.PersonalInformation.Employee.Service
{
    public class EmployeeService : IEmployeeService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeeService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
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
                parameters.Add("@EmployeeNo", request.FilterEmployeeNo ?? string.Empty);
                parameters.Add("@Fullname", request.FilterFullname ?? string.Empty);
                parameters.Add("@EmploymentType", request.FilterEmploymentType ?? string.Empty);
                parameters.Add("@JobClass", request.FilterJobClass ?? string.Empty);
                parameters.Add("@Position", request.FilterPosition ?? string.Empty);
                parameters.Add("@WorkLocation", request.FilterWorkLocation ?? string.Empty);
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
                return new ApiResponse<EmployeeItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeDto>> GetSingleEmployee(GetSingleEmployeeCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/Employee/Sql/get_single_employee");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeDto>(query, parameters);

                return new ApiResponse<EmployeeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeDto>(HttpStatusCode.BadRequest, "Error retrieving Employee detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeItemDto>> GetEmployeeByCriteria(GetEmployeeByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeNo", request.FilterEmployeeNo ?? string.Empty);
                parameters.Add("@Fullname", request.FilterFullname ?? string.Empty);
                parameters.Add("@EmploymentType", request.FilterEmploymentType ?? string.Empty);
                parameters.Add("@JobClass", request.FilterJobClass ?? string.Empty);
                parameters.Add("@Position", request.FilterPosition ?? string.Empty);
                parameters.Add("@WorkLocation", request.FilterWorkLocation ?? string.Empty);

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
                return new ApiResponse<EmployeeItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee data.", ex.Message);
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
                parameters.Add("@Gender", request.Gender);
                parameters.Add("@BirthPlace", request.BirthPlace);
                parameters.Add("@BirthDate", request.BirthDate);

                parameters.Add("@JoinDate", request.JoinDate);
                parameters.Add("@TerminateDate", request.TerminateDate);
                parameters.Add("@PermanentDate", request.PermanentDate);
                parameters.Add("@PensionDate", request.PensionDate);
                parameters.Add("@ContractEndDate", request.ContractEndDate);

                parameters.Add("@PositionCode", request.PositionCode);
                parameters.Add("@JobClassCode", request.JobClassCode);
                parameters.Add("@EmploymentTypeCode", request.EmploymentTypeCode);
                parameters.Add("@CostCenterCode", request.CostCenterCode);
                parameters.Add("@WorkLocationCode", request.WorkLocationCode);
                parameters.Add("@JabatanId", request.JabatanId);
                parameters.Add("@IsEligibleRehire", request.IsEligibleRehire);

                parameters.Add("@TaxType", request.TaxType);
                parameters.Add("@TaxStatusCode", request.TaxStatusCode);
                parameters.Add("@NPWP", request.Npwp);
                parameters.Add("@TaxLocationId", request.TaxLocationId);
                parameters.Add("@NeedReplacement", request.NeedReplacement);
                parameters.Add("@PayGroup", request.PayGroup);
             
                parameters.Add("@NationalityId", request.NationalityId);
                parameters.Add("@ReligionId", request.ReligionId);
                parameters.Add("@MaritalStatus", request.MaritalStatus);
                parameters.Add("@MarriedDate", request.MarriedDate);
                parameters.Add("@BPJSTK", request.BPJSTK);
                parameters.Add("@BPJSKES", request.BPJSKES);
                parameters.Add("@NickName", request.NickName);
                parameters.Add("@Phone", request.Phone);
                parameters.Add("@MobilePhone", request.MobilePhone);
                parameters.Add("@Email", request.Email);
                parameters.Add("@BloodType", request.BloodType);
                parameters.Add("@Height", request.Height);
                parameters.Add("@Weight", request.Weight);

                parameters.Add("@OfficePhone", request.OfficePhone);
                parameters.Add("@OfficeEmail", request.OfficeEmail);
                parameters.Add("@BuildingCode", request.BuildingCode);
                parameters.Add("@RoomCode", request.RoomCode);
                parameters.Add("@ComputerName", request.ComputerName);
                parameters.Add("@StaticIPAddress", request.StaticIPAddress);

                parameters.Add("@Glasses", request.Glasses);
                parameters.Add("@LeftEye", request.LeftEye);
                parameters.Add("@RightEye", request.RightEye);
                parameters.Add("@Hat", request.Hat);
                parameters.Add("@Helmet", request.Helmet);
                parameters.Add("@Clothes", request.Clothes);
                parameters.Add("@Jacket", request.Jacket);
                parameters.Add("@Pants", request.Pants);
                parameters.Add("@Shoes", request.Shoes);
                parameters.Add("@Boots", request.Boots);

                parameters.Add("@PhotoPath", request.PhotoPath);
                parameters.Add("@RFID", request.RFID);
                parameters.Add("@Recruiter", request.Recruiter);
                parameters.Add("@HireOrigin", request.HireOrigin);
                parameters.Add("@BPJSTKLocation", request.BPJSTKLocation);
                parameters.Add("@BPJSKesLocation", request.BPJSKesLocation);
                parameters.Add("@CapColorId", request.CapColorId);
                parameters.Add("@PickUpId", request.PickUpId);
                parameters.Add("@FaskesId", request.FaskesId);

                parameters.Add("@Action", request.Action);
                var userName = currentUserService.GetUserName();
                parameters.Add("@User", string.IsNullOrWhiteSpace(userName) ? "admin" : userName);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/Employee/Sql/submit_employee");
                var result = await db.QueryFirstOrDefaultAsync<ExecuteResult>(query, parameters);

                if (result != null && result.Success)
                    return new ApiResponse(HttpStatusCode.OK, result.Message);
                else
                    return new ApiResponse(HttpStatusCode.BadRequest, result?.Message ?? "Unknown error", result?.ErrorNote);

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
                var userName = currentUserService.GetUserName();
                parameters.Add("@User", string.IsNullOrWhiteSpace(userName) ? "admin" : userName);

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

