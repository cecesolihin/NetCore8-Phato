using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ThePatho.Features.MasterSetting.ScoringSetting.Commands;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Service
{
    public class ScoringSettingService : IScoringSettingService
    {
        private readonly SqlQueryLoader _queryLoader;
        private readonly IDbConnection _dbConnection;
        private readonly DapperContext _dappercontext;
        private readonly ApplicationDbContext _context;
        public ScoringSettingService(ApplicationDbContext context, DapperContext dappercontext, SqlQueryLoader queryLoader, IDbConnection dbConnection)
        {
            _context = context;
            _dappercontext = dappercontext;
            _queryLoader = queryLoader;
            _dbConnection = dbConnection;
        }

        public async Task<List<ScoringSettingDto>> GetScoringSetting(GetScoringSettingCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);
            parameters.Add("@FilterScoringCode", request.FilterScoringCode ?? (object)DBNull.Value);
            parameters.Add("@FilterScoringName", request.FilterScoringName ?? (object)DBNull.Value);
            parameters.Add("@SortBy", request.SortBy);
            parameters.Add("@OrderBy", request.OrderBy);

            var query = await _queryLoader.LoadQueryAsync("MasterSetting/ScoringSetting/Sql/search_scoring_setting");
            var ScoringSetting = await _dbConnection.QueryAsync<ScoringSettingDto>(query, parameters);

            return ScoringSetting.ToList();
        }

        public async Task<ScoringSettingDto> GetScoringSettingByCode(GetScoringSettingByCodeCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FilterScoringCode", request.FilterScoringCode ?? (object)DBNull.Value);

            var query = await _queryLoader.LoadQueryAsync("MasterSetting/ScoringSetting/Sql/search_scoring_setting_by_code");

            var ScoringSetting = await _dbConnection.QueryFirstOrDefaultAsync<ScoringSettingDto>(query, parameters);

            return ScoringSetting;
        }

        public async Task<List<ScoringSettingDto>> GetScoringSettingDdl(GetScoringSettingDdlCommand request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@FilterScoringCode", request.FilterScoringCode ?? (object)DBNull.Value);

            var query = await _queryLoader.LoadQueryAsync("MasterSetting/ScoringSetting/Sql/search_scoring_setting_ddl");
            var ScoringSetting = await _dbConnection.QueryAsync<ScoringSettingDto>(query, parameters);

            return ScoringSetting.ToList();
        }
    }
}
