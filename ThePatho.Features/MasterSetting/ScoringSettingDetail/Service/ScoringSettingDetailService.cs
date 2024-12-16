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
        private readonly SqlQueryLoader _queryLoader;
        private readonly IDbConnection _dbConnection;
        private readonly DapperContext _dappercontext;
        private readonly ApplicationDbContext _context;
        public ScoringSettingDetailService(ApplicationDbContext context, DapperContext dappercontext, SqlQueryLoader queryLoader, IDbConnection dbConnection)
        {
            _context = context;
            _dappercontext = dappercontext;
            _queryLoader = queryLoader;
            _dbConnection = dbConnection;
        }

        public async Task<List<ScoringSettingDetailDto>> GetScoringSettingDetail(GetScoringSettingDetailCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);
            parameters.Add("@FilterScoringCode", request.FilterScoringCode ?? (object)DBNull.Value);
            parameters.Add("@FilterScoringName", request.FilterScoringName ?? (object)DBNull.Value);
            parameters.Add("@SortBy", request.SortBy);
            parameters.Add("@OrderBy", request.OrderBy);

            var query = await _queryLoader.LoadQueryAsync("MasterSetting/ScoringSettingDetail/Sql/search_scoring_setting_detail");
            var ScoringSettingDetail = await _dbConnection.QueryAsync<ScoringSettingDetailDto>(query, parameters);

            return ScoringSettingDetail.ToList();
        }

        public async Task<ScoringSettingDetailDto> GetScoringSettingDetailByCode(GetScoringSettingDetailByCodeCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FilterScoringCode", request.FilterScoringCode ?? (object)DBNull.Value);

            var query = await _queryLoader.LoadQueryAsync("MasterSetting/ScoringSettingDetail/Sql/search_scoring_setting_detail_by_code");

            var ScoringSettingDetail = await _dbConnection.QueryFirstOrDefaultAsync<ScoringSettingDetailDto>(query, parameters);

            return ScoringSettingDetail;
        }

        public async Task<List<ScoringSettingDetailDto>> GetScoringSettingDetailDdl(GetScoringSettingDetailDdlCommand request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@FilterScoringCode", request.FilterScoringCode ?? (object)DBNull.Value);

            var query = await _queryLoader.LoadQueryAsync("MasterSetting/ScoringSettingDetail/Sql/search_scoring_setting_detail_ddl");
            var ScoringSettingDetail = await _dbConnection.QueryAsync<ScoringSettingDetailDto>(query, parameters);

            return ScoringSettingDetail.ToList();
        }
    }
}
