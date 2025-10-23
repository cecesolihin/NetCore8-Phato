using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeEducation.Commands;
using ThePatho.Features.PersonalInformation.EmployeeEducation.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeEducation.Service
{
    public class EmployeeEducationService : IEmployeeEducationService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        #endregion

        #region [CTOR]
        public EmployeeEducationService(DapperContext _dapperContext, SqlQueryLoader _queryLoader)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeEducationItemDto>> GetEmployeeEducation(GetEmployeeEducationCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@EduLevelCode", request.FilterEduLevelCode ?? string.Empty);
                parameters.Add("@Institution", request.FilterInstitution ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeEducation/Sql/get_emp_education");
                var data = await db.QueryAsync<EmployeeEducationDto>(query, parameters);

                var result = new EmployeeEducationItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeEducationList = data.ToList()
                };

                return new ApiResponse<EmployeeEducationItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeEducationItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Education list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeEducationDto>> GetSingleEmployeeEducation(GetSingleEmployeeEducationCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeEducationId", request.EmployeeEducationId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeEducation/Sql/get_singel_emp_education");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeEducationDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<EmployeeEducationDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeeEducationDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeEducationDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Education detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeEducationItemDto>> GetEmployeeEducationByCriteria(GetEmployeeEducationByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@EduLevelCode", request.FilterMajorCode ?? string.Empty);
                parameters.Add("@Institution", request.FilterInstitution ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeEducation/Sql/get_criteria_emp_education");
                var data = await db.QueryAsync<EmployeeEducationDto>(query, parameters);

                var result = new EmployeeEducationItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeEducationList = data.ToList()
                };

                return new ApiResponse<EmployeeEducationItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeEducationItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Education data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeEducation(SubmitEmployeeEducationCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeEducationId", request.EmployeeEducationId);
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@EduLevelCode", request.EduLevelCode);
                parameters.Add("@Faculty", request.Faculty);
                parameters.Add("@MajorCode", request.MajorCode);
                parameters.Add("@OtherMajor", request.OtherMajor);
                parameters.Add("@StartYear", request.StartYear);
                parameters.Add("@EndYear", request.EndYear);
                parameters.Add("@Gpa", request.Gpa);
                parameters.Add("@MaxGpa", request.MaxGpa);
                parameters.Add("@Institution", request.Institution);
                parameters.Add("@Address", request.Address);
                parameters.Add("@CityCode", request.CityCode);
                parameters.Add("@GradTypeCode", request.GradTypeCode);
                parameters.Add("@CertificateNo", request.CertificateNo);
                parameters.Add("@CertificateDate", request.CertificateDate);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeEducation/Sql/submit_emp_education");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeEducation(DeleteEmployeeEducationCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeEducationId", request.EmployeeEducationId);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeEducation/Sql/get_single_emp_education");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeEducationDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<EmployeeEducationDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeEducation/Sql/delete_emp_education");
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

