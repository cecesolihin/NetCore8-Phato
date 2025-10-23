using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.DiseaseCategory.Commands;
using ThePatho.Features.Global.DiseaseCategory.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.DiseaseCategory.Service
{
    public class DiseaseCategoryService : IDiseaseCategoryService
    {
        private readonly DapperContext dapperContext;

        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public DiseaseCategoryService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<DiseaseCategoryItemDto>> GetDiseaseCategory(GetDiseaseCategoryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@DiseaseCategoryCode", request.FilterDiseaseCategoryCode ?? string.Empty);
                parameters.Add("@DiseaseCategoryName", request.FilterDiseaseCategoryName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/DiseaseCategory/Sql/get_diseasecategory");
                var data = await dbConnection.QueryAsync<DiseaseCategoryDto>(query, parameters);
                var result = new DiseaseCategoryItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    DiseaseCategoryList = data.ToList(),
                };
                return new ApiResponse<DiseaseCategoryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<DiseaseCategoryItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<DiseaseCategoryDto>> GetSingleDiseaseCategory(GetSingleDiseaseCategoryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DiseaseCategoryCode", request.FilterDiseaseCategoryCode);

                var query = await queryLoader.LoadQueryAsync("Global/DiseaseCategory/Sql/get_single_diseasecategory");

                var data = await dbConnection.QueryFirstOrDefaultAsync<DiseaseCategoryDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<DiseaseCategoryDto>(HttpStatusCode.OK, "data not found");
                }
                return new ApiResponse<DiseaseCategoryDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<DiseaseCategoryDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<DiseaseCategoryItemDto>> GetDiseaseCategoryByCriteria(GetDiseaseCategoryByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DiseaseCategoryCode", request.FilterDiseaseCategoryCode ?? string.Empty);
                parameters.Add("@DiseaseCategoryName", request.FilterDiseaseCategoryName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/DiseaseCategory/Sql/get_criteria_diseasecategory");
                var data = await dbConnection.QueryAsync<DiseaseCategoryDto>(query, parameters);
                var result = new DiseaseCategoryItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    DiseaseCategoryList = data.ToList(),
                };
                return new ApiResponse<DiseaseCategoryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<DiseaseCategoryItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitDiseaseCategory(SubmitDiseaseCategoryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DiseaseCategoryCode", request.DiseaseCategoryCode);
                parameters.Add("@DiseaseCategoryName", request.DiseaseCategoryName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/DiseaseCategory/Sql/submit_diseasecategory");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.DiseaseCategoryName} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.DiseaseCategoryName}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteDiseaseCategory(DeleteDiseaseCategoryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DiseaseCategoryCode", request.DiseaseCategoryCode);
                var query = await queryLoader.LoadQueryAsync("Global/DiseaseCategory/Sql/get_single_diseasecategory");

                var data = await dbConnection.QueryFirstOrDefaultAsync<DiseaseCategoryDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse(HttpStatusCode.OK, "data not found");
                }
                var query_delete = await queryLoader.LoadQueryAsync("Global/DiseaseCategory/Sql/delete_diseasecategory");
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

