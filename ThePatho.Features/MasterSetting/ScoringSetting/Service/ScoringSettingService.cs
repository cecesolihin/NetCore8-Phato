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

        public async Task<ScoringSettingDto> GetScoringSettingByCriteria(GetScoringSettingByCriteriaCommand request)
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

        public async Task SubmitScoringSetting(SubmitScoringSettingCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ScoringCode", request.ScoringCode);
            parameters.Add("@MaxValue", request.MaxValue);
            parameters.Add("@MinValue", request.MinValue);
            parameters.Add("@NumericalType", request.NumericalType);
            parameters.Add("@ScoringName", request.ScoringName);
            parameters.Add("@ScoringType", request.ScoringType);
            parameters.Add("@Remark", request.Remark);
            parameters.Add("@Action", request.Action); 
            parameters.Add("@User", "admin");

            var query = await queryLoader.LoadQueryAsync("MasterSetting/ScoringSetting/Sql/submit_scoring_setting");
            await dbConnection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteScoringSetting(DeleteScoringSettingCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ScoringCode", request.ScoringCode);

            var query = await queryLoader.LoadQueryAsync("MasterSetting/ScoringSetting/Sql/delete_scoring_setting");
            await dbConnection.ExecuteAsync(query, parameters);
        }

    }
}
