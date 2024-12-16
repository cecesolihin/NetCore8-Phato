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
        private readonly SqlQueryLoader _queryLoader;
        private readonly IDbConnection _dbConnection;
        private readonly DapperContext _dappercontext;
        private readonly ApplicationDbContext _context;
        public OnlineTestSettingService(ApplicationDbContext context, DapperContext dappercontext, SqlQueryLoader queryLoader, IDbConnection dbConnection)
        {
            _context = context;
            _dappercontext = dappercontext;
            _queryLoader = queryLoader;
            _dbConnection = dbConnection;
        }

        public async Task<List<OnlineTestSettingDto>> GetOnlineTestSetting(GetOnlineTestSettingCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);
            parameters.Add("@FilterOnlineTestCode", request.FilterOnlineTestCode ?? (object)DBNull.Value);
            parameters.Add("@FilterOnlineTestName", request.FilterOnlineTestName ?? (object)DBNull.Value);
            parameters.Add("@FilterTestQuestion", request.FilterTestQuestion ?? (object)DBNull.Value);
            parameters.Add("@SortBy", request.SortBy);
            parameters.Add("@OrderBy", request.OrderBy);

            var query = await _queryLoader.LoadQueryAsync("MasterSetting/OnlineTestSetting/Sql/search_online_setting");
            var OnlineTestSetting = await _dbConnection.QueryAsync<OnlineTestSettingDto>(query, parameters);

            return OnlineTestSetting.ToList();
        }

        public async Task<OnlineTestSettingDto> GetOnlineTestSettingByCode(GetOnlineTestSettingByCodeCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FilterOnlineTestCode", request.FilterOnlineTestCode ?? (object)DBNull.Value);

            var query = await _queryLoader.LoadQueryAsync("MasterSetting/OnlineTestSetting/Sql/search_online_setting_by_code");

            var OnlineTestSetting = await _dbConnection.QueryFirstOrDefaultAsync<OnlineTestSettingDto>(query, parameters);

            return OnlineTestSetting;
        }

        public async Task<List<OnlineTestSettingDto>> GetOnlineTestSettingDdl(GetOnlineTestSettingDdlCommand request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@FilterQuestion", request.FilterQuestion ?? (object)DBNull.Value);
            parameters.Add("@FilterRecruitmentRequestNo", request.FilterRecruitmentRequestNo ?? (object)DBNull.Value);

            var query = await _queryLoader.LoadQueryAsync("MasterSetting/OnlineTestSetting/Sql/search_online_setting_ddl");
            var OnlineTestSetting = await _dbConnection.QueryAsync<OnlineTestSettingDto>(query, parameters);

            return OnlineTestSetting.ToList();
        }
    }
}
