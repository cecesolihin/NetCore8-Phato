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
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public QuestionSettingDetailService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<List<QuestionSettingDetailDto>> GetQuestionSettingDetail(GetQuestionSettingDetailCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);
            parameters.Add("@QuestionCode", request.FilterQuestionCode ?? (object)DBNull.Value);
            parameters.Add("@QuestionName", request.FilterQuestionName ?? (object)DBNull.Value);
            parameters.Add("@SortBy", request.SortBy);
            parameters.Add("@OrderBy", request.OrderBy);

            var query = await queryLoader.LoadQueryAsync("MasterSetting/QuestionSettingDetail/Sql/search_question_setting_detail");
            var data = await dbConnection.QueryAsync<QuestionSettingDetailDto>(query, parameters);

            return data.ToList();
        }

        public async Task<List<QuestionSettingDetailDto>> GetQuestionSettingDetailByCode(GetQuestionSettingDetailByCriteriaCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@QuestionCode", request.FilterQuestionCode ?? (object)DBNull.Value);

            var query = await queryLoader.LoadQueryAsync("MasterSetting/QuestionSettingDetail/Sql/search_question_setting_detail_by_code");

            var data = await dbConnection.QueryAsync<QuestionSettingDetailDto>(query, parameters);

            return data.ToList();
        }

        public async Task<List<QuestionSettingDetailDto>> GetQuestionSettingDetailDdl(GetQuestionSettingDetailDdlCommand request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@QuestionCode", request.FilterQuestionCode ?? (object)DBNull.Value);

            var query = await queryLoader.LoadQueryAsync("MasterSetting/QuestionSettingDetail/Sql/search_question_setting_Detail_ddl");
            var data = await dbConnection.QueryAsync<QuestionSettingDetailDto>(query, parameters);

            return data.ToList();
        }
    }
}
