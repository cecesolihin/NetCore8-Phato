using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeePunishment.Commands;
using ThePatho.Features.PersonalInformation.EmployeePunishment.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.PersonalInformation.EmployeePunishment.Service
{
    public class EmployeePunishmentService : IEmployeePunishmentService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeePunishmentService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeePunishmentItemDto>> GetEmployeePunishment(GetEmployeePunishmentCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@LetterNo", request.FilterLetterNo ?? string.Empty);
                parameters.Add("@LetterDate", request.FilterLetterDate ?? string.Empty);
                parameters.Add("@EmployeeId", request.FilterEmployeeId);
                parameters.Add("@PunishmentType", request.FilterPunishmentType ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePunishment/Sql/get_emp_punishment");
                var data = await db.QueryAsync<EmployeePunishmentDto>(query, parameters);

                var result = new EmployeePunishmentItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeePunishmentList = data.ToList()
                };

                return new ApiResponse<EmployeePunishmentItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeePunishmentItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Punishment list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeePunishmentDto>> GetSingleEmployeePunishment(GetSingleEmployeePunishmentCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmPunishmentId", request.EmPunishmentId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePunishment/Sql/get_single_emp_punishment");
                var data = await db.QueryFirstOrDefaultAsync<EmployeePunishmentDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<EmployeePunishmentDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeePunishmentDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeePunishmentDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Punishment detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeePunishmentItemDto>> GetEmployeePunishmentByCriteria(GetEmployeePunishmentByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@LetterNo", request.FilterLetterNo ?? string.Empty);
                parameters.Add("@LetterDate", request.FilterLetterDate ?? string.Empty);
                parameters.Add("@EmployeeId", request.FilterEmployeeId);
                parameters.Add("@PunishmentType", request.FilterPunishmentType ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePunishment/Sql/get_criteria_emp_punishment");
                var data = await db.QueryAsync<EmployeePunishmentDto>(query, parameters);

                var result = new EmployeePunishmentItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeePunishmentList = data.ToList()
                };

                return new ApiResponse<EmployeePunishmentItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeePunishmentItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Punishment data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeePunishment(SubmitEmployeePunishmentCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmPunishmentId", request.EmPunishmentId);
                parameters.Add("@LetterNo", request.LetterNo);
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@LetterDate", request.LetterDate);
                parameters.Add("@PunishmentType", request.PunishmentType);
                parameters.Add("@ValidFrom", request.ValidFrom);
                parameters.Add("@ValidTo", request.ValidTo);
                parameters.Add("@RecoveryDate", request.RecoveryDate);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@Attachment", request.Attachment);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePunishment/Sql/submit_emp_punishment");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeePunishment(DeleteEmployeePunishmentCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmPunishmentId", request.EmPunishmentId);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePunishment/Sql/get_single_emp_punishment");
                var data = await db.QueryFirstOrDefaultAsync<EmployeePunishmentDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<EmployeePunishmentDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeePunishment/Sql/delete_emp_punishment");
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

