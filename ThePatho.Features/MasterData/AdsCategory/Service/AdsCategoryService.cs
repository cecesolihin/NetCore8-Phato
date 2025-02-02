using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data;
using ThePatho.Features.MasterData.AdsCategory.Commands;
using ThePatho.Features.ConfigurationExtensions;
using System.Net;

namespace ThePatho.Features.MasterData.AdsCategory.Service
{
    public class AdsCategoryService : IAdsCategoryService
    {
        
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext; 
        private readonly ApplicationDbContext context;
        public AdsCategoryService(ApplicationDbContext _context,DapperContext _dappercontext ,SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<NewApiResponse<AdsCategoryItemDto>> GetAllAdsCategories(GetAdsCategoryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@AdsCategoryCode", request.FilterAdsCategoryCode ?? (object)DBNull.Value);
                parameters.Add("@AdsCategoryName", request.FilterAdsCategoryName ?? (object)DBNull.Value);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("MasterData/AdsCategory/Sql/search_ads_category");
                var data = await dbConnection.QueryAsync<AdsCategoryDto>(query, parameters);

                var result = new AdsCategoryItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    AdsCategoryList = data.ToList(),
                };
                return new NewApiResponse<AdsCategoryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<AdsCategoryItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }

        }

        public async Task<NewApiResponse<AdsCategoryDto>> GetAdsCategoryByCriteria(GetAdsCategoryByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AdsCategoryCode", request.FilterAdsCategoryCode, DbType.String, ParameterDirection.Input);
                var query = await queryLoader.LoadQueryAsync("MasterData/AdsCategory/Sql/search_ads_category_by_code");

                var data = await dbConnection.QueryFirstOrDefaultAsync<AdsCategoryDto>(query, parameters);

                return new NewApiResponse<AdsCategoryDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<AdsCategoryDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
            
        }
        public async Task<NewApiResponse<AdsCategoryItemDto>> GetAdsCategoriesDdl(GetAdsCategoryDdlCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@AdsCategoryCode", request.FilterAdsCategoryCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@AdsCategoryName", request.FilterAdsCategoryName, DbType.String, ParameterDirection.Input);


                var query = await queryLoader.LoadQueryAsync("MasterData/AdsCategory/Sql/search_ads_category_ddl");
                var data = await dbConnection.QueryAsync<AdsCategoryDto>(query, parameters);

                var result = new AdsCategoryItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    AdsCategoryList = data.ToList(),
                };
                return new NewApiResponse<AdsCategoryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<AdsCategoryItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }
        public async Task<ApiResponse> SubmitAdsCategory(SubmitAdsCategoryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Action", request.Action);
                parameters.Add("@AdsCategoryCode", request.AdsCategoryCode);
                parameters.Add("@AdsCategoryName", request.AdsCategoryName);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("MasterData/AdsCategory/Sql/submit_ads_category");
                await dbConnection.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.AdsCategoryCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.AdsCategoryCode}", ex.Message.ToString());
            }
            
        }
        public async Task<ApiResponse> DeleteAdsCategory(DeleteAdsCategoryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AdsCategoryCode", request.AdsCategoryCode);

                var query = await queryLoader.LoadQueryAsync("MasterData/AdsCategory/Sql/delete_ads_category");
                await dbConnection.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.AdsCategoryCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.AdsCategoryCode}",ex.Message.ToString());
            }
            
        }

    }
}
