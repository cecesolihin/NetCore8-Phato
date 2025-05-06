using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.QuestionSetting.Commands;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;
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

        public async Task<ApiResponse<QuestionSettingDetailItemDto>> GetQuestionSettingDetail(GetQuestionSettingDetailCommand request)
        {
            try
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
                var result = new QuestionSettingDetailItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    QuestionSettingDetailList = data.ToList(),
                };
                return new ApiResponse<QuestionSettingDetailItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<QuestionSettingDetailItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<QuestionSettingDetailItemDto>> GetQuestionSettingDetailByCriteria(GetQuestionSettingDetailByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@QuestionCode", request.FilterQuestionCode ?? (object)DBNull.Value);

                var query = await queryLoader.LoadQueryAsync("MasterSetting/QuestionSettingDetail/Sql/search_question_setting_detail_by_code");

                var data = await dbConnection.QueryAsync<QuestionSettingDetailDto>(query, parameters);
                var result = new QuestionSettingDetailItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    QuestionSettingDetailList = data.ToList(),
                };
                return new ApiResponse<QuestionSettingDetailItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<QuestionSettingDetailItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<QuestionSettingDetailItemDto>> GetQuestionSettingDetailDdl(GetQuestionSettingDetailDdlCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@QuestionCode", request.FilterQuestionCode ?? (object)DBNull.Value);

                var query = await queryLoader.LoadQueryAsync("MasterSetting/QuestionSettingDetail/Sql/search_question_setting_Detail_ddl");
                var data = await dbConnection.QueryAsync<QuestionSettingDetailDto>(query, parameters);
                
                var result = new QuestionSettingDetailItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    QuestionSettingDetailList = data.ToList(),
                };
                return new ApiResponse<QuestionSettingDetailItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<QuestionSettingDetailItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitQuestionSettingDetail(SubmitQuestionSettingDetailCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@QuestDetailId", request.QuestDetailId);
                parameters.Add("@QuestionnaireCode", request.QuestionnaireCode);
                parameters.Add("@IsCategory", request.IsCategory);
                parameters.Add("@Question", request.Question);
                parameters.Add("@QuestParent", request.QuestParent);
                parameters.Add("@ScoringCode", request.ScoringCode);
                parameters.Add("@Order", request.Order);
                parameters.Add("@Attachment", request.Attachment);
                parameters.Add("@MultiChoiceOption", request.MultiChoiceOption);
                parameters.Add("@CorrectAnswer", request.CorrectAnswer);
                parameters.Add("@WeightPoint", request.WeightPoint);
                parameters.Add("@Action", request.Action); // "ADD" or "EDIT"
                parameters.Add("@User", "admin");


                var query = await queryLoader.LoadQueryAsync("MasterSetting/QuestionSettingDetail/Sql/submit_question_setting_detail");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.QuestDetailId.ToString()} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.QuestDetailId.ToString()}", ex.Message.ToString());
            }

        }
        public async Task<ApiResponse> DeleteQuestionSettingDetail(DeleteQuestionSettingDetailCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@QuestDetailId", request.QuestDetailId);

                var query = await queryLoader.LoadQueryAsync("MasterSetting/QuestionSettingDetail/Sql/delete_question_setting_detail");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.QuestDetailId.ToString()} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.QuestDetailId.ToString()}", ex.Message.ToString());
            }
        }

    }
}
