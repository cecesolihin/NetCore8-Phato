using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeReward.Commands;
using ThePatho.Features.PersonalInformation.EmployeeReward.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeReward.Service
{
    public class EmployeeRewardService : IEmployeeRewardService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        #endregion

        #region [CTOR]
        public EmployeeRewardService(DapperContext _dapperContext, SqlQueryLoader _queryLoader)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeRewardItemDto>> GetEmployeeReward(GetEmployeeRewardCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@LetterNo", request.FilterLetterNo ?? string.Empty);
                parameters.Add("@RewardTypeCode", request.FilterRewardTypeCode ?? string.Empty);

                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeReward/Sql/get_emp_reward");
                var data = await db.QueryAsync<EmployeeRewardDto>(query, parameters);

                var result = new EmployeeRewardItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeRewardList = data.ToList()
                };

                return new ApiResponse<EmployeeRewardItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeRewardItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Reward list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeRewardDto>> GetSingleEmployeeReward(GetSingleEmployeeRewardCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmRewardId", request.FilterEmRewardId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeReward/Sql/get_single_emp_reward");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeRewardDto>(query, parameters);

                return new ApiResponse<EmployeeRewardDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeRewardDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Reward detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeRewardItemDto>> GetEmployeeRewardByCriteria(GetEmployeeRewardByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@LetterNo", request.FilterLetterNo ?? string.Empty);
                parameters.Add("@RewardTypeCode", request.FilterRewardTypeCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeReward/Sql/get_criteria_emp_reward");
                var data = await db.QueryAsync<EmployeeRewardDto>(query, parameters);

                var result = new EmployeeRewardItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeRewardList = data.ToList()
                };

                return new ApiResponse<EmployeeRewardItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeRewardItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Reward data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeReward(SubmitEmployeeRewardCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmRewardId", request.EmRewardId);
                parameters.Add("@LetterNo", request.LetterNo);
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@LetterDate", request.LetterDate);
                parameters.Add("@RewardTypeCode", request.RewardTypeCode);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@CurrencyCode", request.CurrencyCode);
                parameters.Add("@Amount", request.Amount);
                parameters.Add("@Attachment", request.Attachment);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeReward/Sql/submit_emp_reward");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeReward(DeleteEmployeeRewardCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmRewardId", request.EmRewardId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeReward/Sql/delete_emp_reward");
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

