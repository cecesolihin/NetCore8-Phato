using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ThePatho.Features.MasterSetting.QuestionSetting.Commands;
using ThePatho.Features.MasterSetting.QuestionSetting.DTO;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Service
{
    public class QuestionSettingService : IQuestionSettingService
    {
        private readonly SqlQueryLoader _queryLoader;
        private readonly IDbConnection _dbConnection;
        private readonly DapperContext _dappercontext;
        private readonly ApplicationDbContext _context;
        public QuestionSettingService(ApplicationDbContext context, DapperContext dappercontext, SqlQueryLoader queryLoader, IDbConnection dbConnection)
        {
            _context = context;
            _dappercontext = dappercontext;
            _queryLoader = queryLoader;
            _dbConnection = dbConnection;
        }

        public async Task<List<QuestionSettingDto>> GetQuestionSetting(GetQuestionSettingCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);
            parameters.Add("@FilterQuestionCode", request.FilterQuestionCode ?? (object)DBNull.Value);
            parameters.Add("@FilterQuestionName", request.FilterQuestionName ?? (object)DBNull.Value);
            parameters.Add("@SortBy", request.SortBy);
            parameters.Add("@OrderBy", request.OrderBy);

            var query = await _queryLoader.LoadQueryAsync("MasterSetting/QuestionSetting/Sql/search_question_setting");
            var QuestionSetting = await _dbConnection.QueryAsync<QuestionSettingDto>(query, parameters);

            return QuestionSetting.ToList();
        }

        public async Task<QuestionSettingDto> GetQuestionSettingByCode(GetQuestionSettingByCodeCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FilterQuestionCode", request.FilterQuestionCode ?? (object)DBNull.Value);

            var query = await _queryLoader.LoadQueryAsync("MasterSetting/QuestionSetting/Sql/search_question_setting_by_code");

            var QuestionSetting = await _dbConnection.QueryFirstOrDefaultAsync<QuestionSettingDto>(query, parameters);

            return QuestionSetting;
        }

        public async Task<List<QuestionSettingDto>> GetQuestionSettingDdl(GetQuestionSettingDdlCommand request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@FilterQuestionCode", request.FilterQuestionCode ?? (object)DBNull.Value);

            var query = await _queryLoader.LoadQueryAsync("MasterSetting/QuestionSetting/Sql/search_question_setting_ddl");
            var QuestionSetting = await _dbConnection.QueryAsync<QuestionSettingDto>(query, parameters);

            return QuestionSetting.ToList();
        }
    }
}
