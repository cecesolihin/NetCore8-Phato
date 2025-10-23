using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.Commands;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.Service
{
    public class EmployeeIdentityService : IEmployeeIdentityService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        #endregion

        #region [CTOR]
        public EmployeeIdentityService(DapperContext _dapperContext, SqlQueryLoader _queryLoader)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeIdentityItemDto>> GetEmployeeIdentity(GetEmployeeIdentityCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@IdentityNo", request.FilterIdentityNo ?? string.Empty);
                parameters.Add("@IdentityCode", request.FilterIdentityCode ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeIdentity/Sql/get_emp_identity");
                var data = await db.QueryAsync<EmployeeIdentityDto>(query, parameters);

                var result = new EmployeeIdentityItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeIdentityList = data.ToList()
                };

                return new ApiResponse<EmployeeIdentityItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeIdentityItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Identity list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeIdentityDto>> GetSingleEmployeeIdentity(GetSingleEmployeeIdentityCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@IdentityCode", request.IdentityCode);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeIdentity/Sql/get_single_emp_identity");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeIdentityDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeIdentityDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeeIdentityDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeIdentityDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Identity detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeIdentityItemDto>> GetEmployeeIdentityByCriteria(GetEmployeeIdentityByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@IdentityNo", request.FilterIdentityNo ?? string.Empty);
                parameters.Add("@IdentityCode", request.FilterIdentityCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeIdentity/Sql/get_criteria_emp_identity");
                var data = await db.QueryAsync<EmployeeIdentityDto>(query, parameters);

                var result = new EmployeeIdentityItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeIdentityList = data.ToList()
                };

                return new ApiResponse<EmployeeIdentityItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeIdentityItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Identity data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeIdentity(SubmitEmployeeIdentityCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@IdentityCode", request.IdentityCode);
                parameters.Add("@CompanyCode", request.CompanyCode);
                parameters.Add("@IdentityNo", request.IdentityNo);
                parameters.Add("@IssuedDate", request.IssuedDate);
                parameters.Add("@ExpiredDate", request.ExpiredDate);
                parameters.Add("@FileUpload", request.FileUpload);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@FileFullPath", request.FileFullPath);
                parameters.Add("@FileName", request.FileName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeIdentity/Sql/submit_emp_identity");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeIdentity(DeleteEmployeeIdentityCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@IdentityCode", request.IdentityCode);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeIdentity/Sql/get_single_emp_identity");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeIdentityDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeIdentityDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeIdentity/Sql/delete_emp_identity");
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

