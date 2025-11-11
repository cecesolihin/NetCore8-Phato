using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeMedical.Commands;
using ThePatho.Features.PersonalInformation.EmployeeMedical.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.PersonalInformation.EmployeeMedical.Service
{
    public class EmployeeMedicalService : IEmployeeMedicalService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeeMedicalService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeMedicalItemDto>> GetEmployeeMedical(GetEmployeeMedicalCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@DiseaseName", request.FilterDiseaseName ?? string.Empty);
                parameters.Add("@Hospital", request.FilterHospital ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeMedical/Sql/get_emp_medical");
                var data = await db.QueryAsync<EmployeeMedicalDto>(query, parameters);

                var result = new EmployeeMedicalItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeMedicalList = data.ToList()
                };

                return new ApiResponse<EmployeeMedicalItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeMedicalItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Medical list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeMedicalDto>> GetSingleEmployeeMedical(GetSingleEmployeeMedicalCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@DiseaseCategoryCode", request.DiseaseCategoryCode);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeMedical/Sql/get_single_emp_medical");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeMedicalDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeMedicalDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeeMedicalDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeMedicalDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Medical detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeMedicalItemDto>> GetEmployeeMedicalByCriteria(GetEmployeeMedicalByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@DiseaseName", request.FilterDiseaseName ?? string.Empty);
                parameters.Add("@Hospital", request.FilterHospital ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeMedical/Sql/get_criteria_emp_medical");
                var data = await db.QueryAsync<EmployeeMedicalDto>(query, parameters);

                var result = new EmployeeMedicalItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeMedicalList = data.ToList()
                };

                return new ApiResponse<EmployeeMedicalItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeMedicalItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Medical data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeMedical(SubmitEmployeeMedicalCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@DiseaseCategoryCode", request.DiseaseCategoryCode);
                parameters.Add("@DiseaseName", request.DiseaseName);
                parameters.Add("@StartDate", request.StartDate);
                parameters.Add("@EndDate", request.EndDate);
                parameters.Add("@Therapy", request.Therapy);
                parameters.Add("@Hospital", request.Hospital);
                parameters.Add("@CountryId", request.CountryId);
                parameters.Add("@ProvinceId", request.ProvinceId);
                parameters.Add("@CityCode", request.CityCode);
                parameters.Add("@Doctor", request.Doctor);
                parameters.Add("@Phone", request.Phone);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@IsDeleted", request.IsDeleted);
                parameters.Add("@InsertedBy", request.InsertedBy);
                parameters.Add("@InsertedDate", request.InsertedDate);
                parameters.Add("@ModifiedBy", request.ModifiedBy);
                parameters.Add("@ModifiedDate", request.ModifiedDate);
                parameters.Add("@TimeIn", request.TimeIn);
                parameters.Add("@TimeOut", request.TimeOut);
                parameters.Add("@Obat", request.Obat);
                parameters.Add("@TindakanPertama", request.TindakanPertama);
                parameters.Add("@TindakanKedua", request.TindakanKedua);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeMedical/Sql/submit_emp_medical");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeMedical(DeleteEmployeeMedicalCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@DiseaseCategoryCode", request.DiseaseCategoryCode);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeMedical/Sql/get_single_emp_medical");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeMedicalDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeMedicalDto>(HttpStatusCode.NotFound, "data not found");
                }
                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeMedical/Sql/delete_emp_medical");
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

