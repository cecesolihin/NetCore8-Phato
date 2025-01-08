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

        public async Task<QuestionSettingDto> GetQuestionSettingByCriteria(GetQuestionSettingByCriteriaCommand request)
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

        public async Task SubmitQuestionSetting(SubmitQuestionSettingCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@QuestionnaireCode", request.QuestionnaireCode);
            parameters.Add("@QuestionnaireName", request.QuestionnaireName);
            parameters.Add("@QuestionnaireType", request.QuestionnaireType);
            parameters.Add("@Remarks", request.Remarks);
            parameters.Add("@Active", request.Active);
            parameters.Add("@AnswerMethod", request.AnswerMethod);
            parameters.Add("@RandomQuestion", request.RandomQuestion);
            parameters.Add("@Action", request.Action); // "ADD" or "EDIT"
            parameters.Add("@User", "admin");

            var query = await queryLoader.LoadQueryAsync("MasterSetting/QuestionSetting/Sql/submit_question_setting");
            await dbConnection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteQuestionSetting(DeleteQuestionSettingCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@QuestionnaireCode", request.QuestionnaireCode);

            var query = await queryLoader.LoadQueryAsync("MasterSetting/QuestionSetting/Sql/delete_question_setting");
            await dbConnection.ExecuteAsync(query, parameters);
        }


    }
}
