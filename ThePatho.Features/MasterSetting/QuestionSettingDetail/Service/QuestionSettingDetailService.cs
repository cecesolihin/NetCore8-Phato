using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ThePatho.Features.MasterSetting.QuestionSetting.Commands;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Service
{
    public class QuestionSettingDetailService : IQuestionSettingDetailService
    {
        private readonly SqlQueryLoader _queryLoader;
        private readonly IDbConnection _dbConnection;
        private readonly DapperContext _dappercontext;
        private readonly ApplicationDbContext _context;
        public QuestionSettingDetailService(ApplicationDbContext context, DapperContext dappercontext, SqlQueryLoader queryLoader, IDbConnection dbConnection)
        {
            _context = context;
            _dappercontext = dappercontext;
            _queryLoader = queryLoader;
            _dbConnection = dbConnection;
        }

        public async Task<List<QuestionSettingDetailDto>> GetQuestionSettingDetail(GetQuestionSettingDetailCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);
            parameters.Add("@FilterQuestionCode", request.FilterQuestionCode ?? (object)DBNull.Value);
            parameters.Add("@FilterQuestionName", request.FilterQuestionName ?? (object)DBNull.Value);
            parameters.Add("@SortBy", request.SortBy);
            parameters.Add("@OrderBy", request.OrderBy);

            var query = await _queryLoader.LoadQueryAsync("MasterSetting/QuestionSettingDetail/Sql/search_question_setting_detail");
            var QuestionSettingDetail = await _dbConnection.QueryAsync<QuestionSettingDetailDto>(query, parameters);

            return QuestionSettingDetail.ToList();
        }

        public async Task<QuestionSettingDetailDto> GetQuestionSettingDetailByCode(GetQuestionSettingDetailByCodeCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FilterQuestionCode", request.FilterQuestionCode ?? (object)DBNull.Value);

            var query = await _queryLoader.LoadQueryAsync("MasterSetting/QuestionSettingDetail/Sql/search_question_setting_detail_by_code");

            var QuestionSettingDetail = await _dbConnection.QueryFirstOrDefaultAsync<QuestionSettingDetailDto>(query, parameters);

            return QuestionSettingDetail;
        }

        public async Task<List<QuestionSettingDetailDto>> GetQuestionSettingDetailDdl(GetQuestionSettingDetailDdlCommand request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@FilterQuestionCode", request.FilterQuestionCode ?? (object)DBNull.Value);

            var query = await _queryLoader.LoadQueryAsync("MasterSetting/QuestionSettingDetail/Sql/search_question_setting_Detail_ddl");
            var QuestionSettingDetail = await _dbConnection.QueryAsync<QuestionSettingDetailDto>(query, parameters);

            return QuestionSettingDetail.ToList();
        }
    }
}
