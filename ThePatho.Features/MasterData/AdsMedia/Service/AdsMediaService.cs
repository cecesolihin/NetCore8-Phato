using Dapper;
using System.Data;
using System.Net;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.MasterData.AdsMedia.Commands;
using ThePatho.Features.MasterData.AdsMedia.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.MasterData.AdsMedia.Service
{
    public class AdsMediaService : IAdsMediaService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext; 
        private readonly ApplicationDbContext context;
        public AdsMediaService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<AdsMediaItemDto>> GetAdsMedia(GetAdsMediaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@AdsCode", request.FilterAdsCode ?? (object)DBNull.Value);
                parameters.Add("@AdsName", request.FilterAdsName ?? (object)DBNull.Value);
                parameters.Add("@@AdsCategoryCode", request.FilterAdsCategoryCode ?? (object)DBNull.Value);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("MasterData/AdsMedia/Sql/search_ads_media");
                var data = await dbConnection.QueryAsync<AdsMediaDto>(query, parameters);

                var result = new AdsMediaItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    AdsMediaList = data.ToList(),
                };
                return new ApiResponse<AdsMediaItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new ApiResponse<AdsMediaItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
            
        }

        public async Task<ApiResponse<AdsMediaDto>> GetAdsMediaByCriteria(GetAdsMediaByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@AdsCode", request.FilterAdsCode, DbType.String, ParameterDirection.Input);
                var query = await queryLoader.LoadQueryAsync("MasterData/AdsMedia/Sql/search_ads_media_by_code");

                var data = await dbConnection.QueryFirstOrDefaultAsync<AdsMediaDto>(query, parameters);

                return new ApiResponse<AdsMediaDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<AdsMediaDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
            
        }

        public async Task<ApiResponse<AdsMediaItemDto>> GetAdsMediaDdl(GetAdsMediaDdlCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@AdsCategoryCode", request.FilterAdsCategoryCode, DbType.String, ParameterDirection.Input);

                var query = await queryLoader.LoadQueryAsync("MasterData/AdsMedia/Sql/search_ads_media_ddl");
                var data = await dbConnection.QueryAsync<AdsMediaDto>(query, parameters);

                var result = new AdsMediaItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    AdsMediaList = data.ToList(),
                };
                return new ApiResponse<AdsMediaItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<AdsMediaItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
            
        }

        public async Task<ApiResponse> SubmitAdsMedia(SubmitAdsMediaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AdsCode", request.AdsMediaCode);
                parameters.Add("@AdsName", request.AdsMediaName);
                parameters.Add("@AdsCategoryCode", request.AdsCategoryCode);
                parameters.Add("@Phone", request.Phone);
                parameters.Add("@ContactPerson", request.ContactPerson);
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@UseRecruitmentFee", request.UseRecruitmentFee);
                parameters.Add("@RecruitmentFee", request.RecruitmentFee);
                parameters.Add("@RecruitmentFee2", request.RecruitmentFee2);
                parameters.Add("@RecruitmentFee3", request.RecruitmentFee3);
                parameters.Add("@Action", request.Action); // "ADD" or "EDIT"
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("MasterData/AdsMedia/Sql/submit_ads_media");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.AdsMediaCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.AdsMediaCode}", ex.Message.ToString());
            }
            
        }
        public async Task<ApiResponse> DeleteAdsMedia(DeleteAdsMediaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AdsCode", request.AdsMediaCode);

                var query = await queryLoader.LoadQueryAsync("MasterData/AdsMedia/Sql/delete_ads_media");
                await dbConnection.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.AdsMediaCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.AdsMediaCode}", ex.Message.ToString());
            }
            
        }
    }
}
