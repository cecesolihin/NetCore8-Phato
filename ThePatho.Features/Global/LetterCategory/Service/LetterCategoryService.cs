using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.LetterCategory.Commands;
using ThePatho.Features.Global.LetterCategory.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.LetterCategory.Service
{
    public class LetterCategoryService : ILetterCategoryService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public LetterCategoryService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<LetterCategoryItemDto>> GetLetterCategory(GetLetterCategoryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@LetterCategoryCode", request.FilterLetterCategoryCode ?? string.Empty);
                parameters.Add("@LetterCategoryName", request.FilterLetterCategoryName ?? string.Empty);
                parameters.Add("@DocPattern", request.FilterDocPattern ?? string.Empty);
                parameters.Add("@ResetType", request.ResetType ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/LetterCategory/Sql/get_lettercategory");
                var data = await dbConnection.QueryAsync<LetterCategoryDto>(query, parameters);
                var result = new LetterCategoryItemDto
                {
                    DataOfRecords = data.Count(),
                    LetterCategoryList = data.ToList(),
                };
                return new ApiResponse<LetterCategoryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<LetterCategoryItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<LetterCategoryDto>> GetSingleLetterCategory(GetSingleLetterCategoryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@LetterCategoryCode", request.FilterLetterCategoryCode);

                var query = await queryLoader.LoadQueryAsync("Global/LetterCategory/Sql/get_single_lettercategory");

                var data = await dbConnection.QueryFirstOrDefaultAsync<LetterCategoryDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<LetterCategoryDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<LetterCategoryDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<LetterCategoryDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<LetterCategoryItemDto>> GetLetterCategoryByCriteria(GetLetterCategoryByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@LetterCategoryCode", request.FilterLetterCategoryCode ?? string.Empty);
                parameters.Add("@LetterCategoryName", request.FilterLetterCategoryName ?? string.Empty);
                parameters.Add("@DocPattern", request.FilterDocPattern ?? string.Empty);
                parameters.Add("@ResetType", request.ResetType ?? string.Empty);


                var query = await queryLoader.LoadQueryAsync("Global/LetterCategory/Sql/get_criteria_lettercategory");
                var data = await dbConnection.QueryAsync<LetterCategoryDto>(query, parameters);
                var result = new LetterCategoryItemDto
                {
                    DataOfRecords = data.Count(),
                    LetterCategoryList = data.ToList(),
                };
                return new ApiResponse<LetterCategoryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<LetterCategoryItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitLetterCategory(SubmitLetterCategoryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@LetterCategoryCode", request.LetterCategoryCode);
                parameters.Add("@LetterCategoryName", request.LetterCategoryName);
                parameters.Add("@MappingLetterTemplate", request.MappingLetterTemplate);
                parameters.Add("@ResetType", request.ResetType);
                parameters.Add("@DocPattern", request.DocPattern);
                parameters.Add("@SequenceNo", request.SequenceNo);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/LetterCategory/Sql/submit_lettercategory");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.LetterCategoryCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.LetterCategoryCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteLetterCategory(DeleteLetterCategoryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@LetterCategoryCode", request.LetterCategoryCode);

                var query = await queryLoader.LoadQueryAsync("Global/LetterCategory/Sql/get_single_lettercategory");

                var data = await dbConnection.QueryFirstOrDefaultAsync<LetterCategoryDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<LetterCategoryDto>(HttpStatusCode.NotFound, "data not found");
                }
                var query_delete = await queryLoader.LoadQueryAsync("Global/LetterCategory/Sql/delete_lettercategory");
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
