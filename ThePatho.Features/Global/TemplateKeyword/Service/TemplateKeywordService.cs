using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.SkillProficiency.DTO;
using ThePatho.Features.Global.TemplateKeyword.Commands;
using ThePatho.Features.Global.TemplateKeyword.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.TemplateKeyword.Service
{
    public class TemplateKeywordService : ITemplateKeywordService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public TemplateKeywordService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<TemplateKeywordItemDto>> GetTemplateKeyword(GetTemplateKeywordCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@KeywordCode", request.FilterKeywordCode ?? string.Empty);
                parameters.Add("@KeywordName", request.FilterKeywordName ?? string.Empty);
                parameters.Add("@TableName", request.FilterTableName ?? string.Empty);
                parameters.Add("@ColumnName", request.FilterColumnName ?? string.Empty);
                parameters.Add("@Value", request.FilterValue ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/TemplateKeyword/Sql/get_templatekeyword");
                var data = await dbConnection.QueryAsync<TemplateKeywordDto>(query, parameters);
                var result = new TemplateKeywordItemDto
                {
                    DataOfRecords = data.Count(),
                    TemplateKeywordList = data.ToList(),
                };
                return new ApiResponse<TemplateKeywordItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TemplateKeywordItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<TemplateKeywordDto>> GetSingleTemplateKeyword(GetSingleTemplateKeywordCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@KeywordCode", request.FilterKeywordCode);

                var query = await queryLoader.LoadQueryAsync("Global/TemplateKeyword/Sql/get_single_templatekeyword");

                var data = await dbConnection.QueryFirstOrDefaultAsync<TemplateKeywordDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<TemplateKeywordDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<TemplateKeywordDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TemplateKeywordDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<TemplateKeywordItemDto>> GetTemplateKeywordByCriteria(GetTemplateKeywordByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@KeywordCode", request.FilterKeywordCode ?? string.Empty);
                parameters.Add("@KeywordName", request.FilterKeywordName ?? string.Empty);
                parameters.Add("@TableName", request.FilterTableName ?? string.Empty);
                parameters.Add("@ColumnName", request.FilterColumnName ?? string.Empty);
                parameters.Add("@Value", request.FilterValue ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/TemplateKeyword/Sql/get_criteria_templatekeyword");
                var data = await dbConnection.QueryAsync<TemplateKeywordDto>(query, parameters);
                var result = new TemplateKeywordItemDto
                {
                    DataOfRecords = data.Count(),
                    TemplateKeywordList = data.ToList(),
                };
                return new ApiResponse<TemplateKeywordItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TemplateKeywordItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitTemplateKeyword(SubmitTemplateKeywordCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@KeywordCode", request.KeywordCode);
                parameters.Add("@KeywordName", request.KeywordName);
                parameters.Add("@Value", request.Value);
                parameters.Add("@StaticValue", request.StaticValue);
                parameters.Add("@TableName", request.TableName);
                parameters.Add("@ColumnName", request.ColumnName);
                parameters.Add("@Action", request.Action);
                var userName = currentUserService.GetUserName();
                parameters.Add("@User", string.IsNullOrWhiteSpace(userName) ? "admin" : userName);

                var query = await queryLoader.LoadQueryAsync("Global/TemplateKeyword/Sql/submit_templatekeyword");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.KeywordCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.KeywordCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteTemplateKeyword(DeleteTemplateKeywordCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@KeywordCode", request.KeywordCode);

                var query = await queryLoader.LoadQueryAsync("Global/TemplateKeyword/Sql/delete_templatekeyword");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"Delete successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message.ToString());
            }
        }

    }
}
