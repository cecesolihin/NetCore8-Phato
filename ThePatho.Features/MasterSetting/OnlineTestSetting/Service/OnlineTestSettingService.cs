using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ThePatho.Features.MasterSetting.OnlineTestSetting.Commands;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Service
{
    public class OnlineTestSettingService : IOnlineTestSettingService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection; 
        //private readonly DapperContext dappercontext;
        //private readonly ApplicationDbContext _context;
        public OnlineTestSettingService(SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<List<OnlineTestSettingDto>> GetOnlineTestSetting(GetOnlineTestSettingCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);
            parameters.Add("@OnlineTestCode", request.FilterOnlineTestCode ?? (object)DBNull.Value);
            parameters.Add("@OnlineTestName", request.FilterOnlineTestName ?? (object)DBNull.Value);
            parameters.Add("@TestQuestion", request.FilterTestQuestion ?? (object)DBNull.Value);
            parameters.Add("@SortBy", request.SortBy);
            parameters.Add("@OrderBy", request.OrderBy);

            var query = await queryLoader.LoadQueryAsync("MasterSetting/OnlineTestSetting/Sql/search_online_setting");
            var data = await dbConnection.QueryAsync<OnlineTestSettingDto>(query, parameters);

            return data.ToList();
        }

        public async Task<OnlineTestSettingDto> GetOnlineTestSettingByCriteria(GetOnlineTestSettingByCriteriaCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OnlineTestCode", request.FilterOnlineTestCode ?? (object)DBNull.Value);

            var query = await queryLoader.LoadQueryAsync("MasterSetting/OnlineTestSetting/Sql/search_online_setting_by_code");

            var data = await dbConnection.QueryFirstOrDefaultAsync<OnlineTestSettingDto>(query, parameters);

            return data;
        }

        public async Task<List<OnlineTestSettingDto>> GetOnlineTestSettingDdl(GetOnlineTestSettingDdlCommand request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@RecruitmentRequestNo", request.FilterRecruitmentRequestNo ?? (object)DBNull.Value);

            var query = await queryLoader.LoadQueryAsync("MasterSetting/OnlineTestSetting/Sql/search_online_setting_ddl");
            var data = await dbConnection.QueryAsync<OnlineTestSettingDto>(query, parameters);

            return data.ToList();
        }
        public async Task SubmitOnlineTestSetting(SubmitOnlineTestSettingCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OnlineTestCode", request.OnlineTestCode);
            parameters.Add("@OnlineTestName", request.OnlineTestName);
            parameters.Add("@TestQuestion", request.TestQuestion);
            parameters.Add("@TestLocation", request.TestLocation);
            parameters.Add("@Status", request.Status);
            parameters.Add("@RecruitmentReqNo", request.RecruitmentReqNo);
            parameters.Add("@OnlineTestDateFrom", request.OnlineTestDateFrom);
            parameters.Add("@OnlineTestDateTo", request.OnlineTestDateTo);
            parameters.Add("@OnlineTestTimeFrom", request.OnlineTestTimeFrom);
            parameters.Add("@OnlineTestTimeTo", request.OnlineTestTimeTo);
            parameters.Add("@ScoringType", request.ScoringType);
            parameters.Add("@EmailTemplate", request.EmailTemplate);
            parameters.Add("@RecruitmentStep", request.RecruitmentStep);
            parameters.Add("@MinScore", request.MinScore);
            parameters.Add("@Quota", request.Quota);
            parameters.Add("@Action", request.Action);
            parameters.Add("@User", "admin");

            var query = await queryLoader.LoadQueryAsync("MasterSetting/OnlineTestSetting/Sql/submit_online_test_setting");
            await dbConnection.ExecuteAsync(query, parameters);
        }
        public async Task DeleteOnlineTestSetting(DeleteOnlineTestSettingCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OnlineTestCode", request.OnlineTestSettingCode);

            var query = await queryLoader.LoadQueryAsync("MasterSetting/OnlineTestSetting/Sql/delete_online_test_setting");
            await dbConnection.ExecuteAsync(query, parameters);
        }
    }
}
