using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Service
{
    public class ScoringSettingDetailService : IScoringSettingDetailService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext; 
        private readonly ApplicationDbContext context;
        public ScoringSettingDetailService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<List<ScoringSettingDetailDto>> GetScoringSettingDetail(GetScoringSettingDetailCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);
            parameters.Add("@ScoringCode", request.FilterScoringCode ?? (object)DBNull.Value);
            parameters.Add("@ScoringName", request.FilterScoringName ?? (object)DBNull.Value);
            parameters.Add("@SortBy", request.SortBy);
            parameters.Add("@OrderBy", request.OrderBy);

            var query = await queryLoader.LoadQueryAsync("MasterSetting/ScoringSettingDetail/Sql/search_scoring_setting_detail");
            var data = await dbConnection.QueryAsync<ScoringSettingDetailDto>(query, parameters);

            return data.ToList();
        }

        public async Task<List<ScoringSettingDetailDto>> GetScoringSettingDetailByCriteria(GetScoringSettingDetailByCriteriaCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ScoringCode", request.FilterScoringCode ?? (object)DBNull.Value);

            var query = await queryLoader.LoadQueryAsync("MasterSetting/ScoringSettingDetail/Sql/search_scoring_setting_detail_by_code");

            var data = await dbConnection.QueryAsync<ScoringSettingDetailDto>(query, parameters);

            return data.ToList();
        }

        public async Task<List<ScoringSettingDetailDto>> GetScoringSettingDetailDdl(GetScoringSettingDetailDdlCommand request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@ScoringCode", request.FilterScoringCode ?? (object)DBNull.Value);

            var query = await queryLoader.LoadQueryAsync("MasterSetting/ScoringSettingDetail/Sql/search_scoring_setting_detail_ddl");
            var data = await dbConnection.QueryAsync<ScoringSettingDetailDto>(query, parameters);

            return data.ToList();
        }
    }
}
