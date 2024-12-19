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
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public QuestionSettingService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<List<QuestionSettingDto>> GetQuestionSetting(GetQuestionSettingCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);
            parameters.Add("@QuestionCode", request.FilterQuestionCode ?? (object)DBNull.Value);
            parameters.Add("@QuestionName", request.FilterQuestionName ?? (object)DBNull.Value);
            parameters.Add("@SortBy", request.SortBy);
            parameters.Add("@OrderBy", request.OrderBy);

            var query = await queryLoader.LoadQueryAsync("MasterSetting/QuestionSetting/Sql/search_question_setting");
            var data = await dbConnection.QueryAsync<QuestionSettingDto>(query, parameters);

            return data.ToList();
        }

        public async Task<QuestionSettingDto> GetQuestionSettingByCode(GetQuestionSettingByCriteriaCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@QuestionCode", request.FilterQuestionCode ?? (object)DBNull.Value);

            var query = await queryLoader.LoadQueryAsync("MasterSetting/QuestionSetting/Sql/search_question_setting_by_code");

            var data = await dbConnection.QueryFirstAsync<QuestionSettingDto>(query, parameters);

            return data;
        }

        public async Task<List<QuestionSettingDto>> GetQuestionSettingDdl(GetQuestionSettingDdlCommand request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@QuestionCode", request.FilterQuestionCode ?? (object)DBNull.Value);

            var query = await queryLoader.LoadQueryAsync("MasterSetting/QuestionSetting/Sql/search_question_setting_ddl");
            var data = await dbConnection.QueryAsync<QuestionSettingDto>(query, parameters);

            return data.ToList();
        }
    }
}
