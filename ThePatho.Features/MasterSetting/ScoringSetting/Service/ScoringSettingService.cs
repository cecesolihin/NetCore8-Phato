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
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public ScoringSettingService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<List<ScoringSettingDto>> GetScoringSetting(GetScoringSettingCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);
            parameters.Add("@ScoringCode", request.FilterScoringCode ?? (object)DBNull.Value);
            parameters.Add("@ScoringName", request.FilterScoringName ?? (object)DBNull.Value);
            parameters.Add("@SortBy", request.SortBy);
            parameters.Add("@OrderBy", request.OrderBy);

            var query = await queryLoader.LoadQueryAsync("MasterSetting/ScoringSetting/Sql/search_scoring_setting");
            var data = await dbConnection.QueryAsync<ScoringSettingDto>(query, parameters);

            return data.ToList();
        }

        public async Task<ScoringSettingDto> GetScoringSettingByCode(GetScoringSettingByCriteriaCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ScoringCode", request.FilterScoringCode ?? (object)DBNull.Value);

            var query = await queryLoader.LoadQueryAsync("MasterSetting/ScoringSetting/Sql/search_scoring_setting_by_code");

            var data = await dbConnection.QueryFirstOrDefaultAsync<ScoringSettingDto>(query, parameters);

            return data;
        }

        public async Task<List<ScoringSettingDto>> GetScoringSettingDdl(GetScoringSettingDdlCommand request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@ScoringCode", request.FilterScoringCode ?? (object)DBNull.Value);

            var query = await queryLoader.LoadQueryAsync("MasterSetting/ScoringSetting/Sql/search_scoring_setting_ddl");
            var data = await dbConnection.QueryAsync<ScoringSettingDto>(query, parameters);

            return data.ToList();
        }
    }
}
