using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.LetterTemplate.Commands;
using ThePatho.Features.Global.LetterTemplate.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.LetterTemplate.Service
{
    public class LetterTemplateService : ILetterTemplateService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public LetterTemplateService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<LetterTemplateItemDto>> GetLetterTemplate(GetLetterTemplateCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@LetterTemplateCode", request.FilterLetterTemplateCode ?? string.Empty);
                parameters.Add("@LetterTemplateName", request.FilterLetterTemplateName ?? string.Empty);
                parameters.Add("@Content", request.Content ?? string.Empty);
                parameters.Add("@LetterTemplateType", request.LetterTemplateType ?? string.Empty);
                parameters.Add("@LetterCategoryCode", request.FilterLetterCategoryCode ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/LetterTemplate/Sql/get_lettertemplate");
                var data = await dbConnection.QueryAsync<LetterTemplateDto>(query, parameters);
                var result = new LetterTemplateItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    LetterTemplateList = data.ToList(),
                };
                return new ApiResponse<LetterTemplateItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<LetterTemplateItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<LetterTemplateDto>> GetSingleLetterTemplate(GetSingleLetterTemplateCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@LetterTemplateCode", request.FilterLetterTemplateCode);

                var query = await queryLoader.LoadQueryAsync("Global/LetterTemplate/Sql/get_single_lettertemplate");

                var data = await dbConnection.QueryFirstOrDefaultAsync<LetterTemplateDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<LetterTemplateDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<LetterTemplateDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<LetterTemplateDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<LetterTemplateItemDto>> GetLetterTemplateByCriteria(GetLetterTemplateByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@LetterTemplateCode", request.FilterLetterTemplateCode ?? string.Empty);
                parameters.Add("@LetterTemplateName", request.FilterLetterTemplateName ?? string.Empty);
                parameters.Add("@Content", request.Content ?? string.Empty);
                parameters.Add("@LetterTemplateType", request.LetterTemplateType ?? string.Empty);
                parameters.Add("@LetterCategoryCode", request.FilterLetterCategoryCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/LetterTemplate/Sql/get_criteria_lettertemplate");
                var data = await dbConnection.QueryAsync<LetterTemplateDto>(query, parameters);
                var result = new LetterTemplateItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    LetterTemplateList = data.ToList(),
                };
                return new ApiResponse<LetterTemplateItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<LetterTemplateItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitLetterTemplate(SubmitLetterTemplateCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@LetterCategoryCode", request.LetterCategoryCode);
                parameters.Add("@LetterTemplateName", request.LetterTemplateName);
                parameters.Add("@LetterTemplateType", request.LetterTemplateType);
                parameters.Add("@Content", request.Content);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@FileUpload", request.FileUpload);
                parameters.Add("@LetterCategoryCode", request.LetterCategoryCode);
                
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/LetterTemplate/Sql/submit_lettertemplate");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.LetterCategoryCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.LetterCategoryCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteLetterTemplate(DeleteLetterTemplateCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@LetterTemplateCode", request.LetterTemplateCode);

                var query = await queryLoader.LoadQueryAsync("Global/LetterTemplate/Sql/get_single_lettertemplate");

                var data = await dbConnection.QueryFirstOrDefaultAsync<LetterTemplateDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<LetterTemplateDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("Global/LetterTemplate/Sql/delete_lettertemplate");
                await dbConnection.ExecuteAsync(query_delete, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"Delete successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message.ToString());
            }
        }

    }
}
