using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeTraining.Commands;
using ThePatho.Features.PersonalInformation.EmployeeTraining.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeTraining.Service
{
    public class EmployeeTrainingService : IEmployeeTrainingService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        #endregion

        #region [CTOR]
        public EmployeeTrainingService(DapperContext _dapperContext, SqlQueryLoader _queryLoader)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeTrainingItemDto>> GetEmployeeTraining(GetEmployeeTrainingCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@TrainingCourseCode", request.FilterTrainingCourseCode ?? string.Empty);
                parameters.Add("@TrainingTypeCode", request.FilterTrainingTypeCode ?? string.Empty);
                parameters.Add("@TrainingFieldCode", request.FilterTrainingFieldCode ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeTraining/Sql/get_emp_training");
                var data = await db.QueryAsync<EmployeeTrainingDto>(query, parameters);

                var result = new EmployeeTrainingItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeTrainingList = data.ToList()
                };

                return new ApiResponse<EmployeeTrainingItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeTrainingItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Training list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeTrainingDto>> GetSingleEmployeeTraining(GetSingleEmployeeTrainingCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmpTrainingId", request.EmpTrainingId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeTraining/Sql/get_single_emp_training");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeTrainingDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeTrainingDto>(HttpStatusCode.NotFound, "data not found");
                }

                return new ApiResponse<EmployeeTrainingDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeTrainingDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Training detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeTrainingItemDto>> GetEmployeeTrainingByCriteria(GetEmployeeTrainingByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@TrainingCourseCode", request.FilterTrainingCourseCode ?? string.Empty);
                parameters.Add("@TrainingTypeCode", request.FilterTrainingTypeCode ?? string.Empty);
                parameters.Add("@TrainingFieldCode", request.FilterTrainingFieldCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeTraining/Sql/get_criteria_emp_training");
                var data = await db.QueryAsync<EmployeeTrainingDto>(query, parameters);

                var result = new EmployeeTrainingItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeTrainingList = data.ToList()
                };

                return new ApiResponse<EmployeeTrainingItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeTrainingItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Training data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeTraining(SubmitEmployeeTrainingCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmpTrainingId", request.EmpTrainingId);
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@TrainingCourseCode", request.TrainingCourseCode);
                parameters.Add("@StartDate", request.StartDate);
                parameters.Add("@TrainingTypeCode", request.TrainingTypeCode);
                parameters.Add("@TrainingFieldCode", request.TrainingFieldCode);
                parameters.Add("@Institution", request.Institution);
                parameters.Add("@Address", request.Address);
                parameters.Add("@CityCode", request.CityCode);
                parameters.Add("@CertificateNo", request.CertificateNo);
                parameters.Add("@CertificateDate", request.CertificateDate);
                parameters.Add("@EndDate", request.EndDate);
                parameters.Add("@TrainingPayerCode", request.TrainingPayerCode);
                parameters.Add("@CompanyBondDate", request.CompanyBondDate);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@TrainingBatchCode", request.TrainingBatchCode);
                parameters.Add("@IsDeleted", request.IsDeleted);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeTraining/Sql/submit_emp_training");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeTraining(DeleteEmployeeTrainingCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmpTrainingId", request.EmpTrainingId);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeTraining/Sql/get_single_emp_training");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeTrainingDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeTrainingDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeTraining/Sql/delete_emp_training");
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

