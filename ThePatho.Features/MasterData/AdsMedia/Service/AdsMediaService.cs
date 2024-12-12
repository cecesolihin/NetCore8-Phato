using Azure.Core;
using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Numerics;
using ThePatho.Domain.Models.MasterData;
using ThePatho.Features.MasterData.AdsCategory.Commands;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.MasterData.AdsMedia.DTO;
using ThePatho.Features.MasterData.AdsMedia.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.MasterData.AdsMedia.Service
{
    public class AdsMediaService : IAdsMediaService
    {
        private readonly SqlQueryLoader _queryLoader;
        private readonly IDbConnection _dbConnection;
        private readonly DapperContext _dappercontext;
        private readonly ApplicationDbContext _context;
        public AdsMediaService(ApplicationDbContext context, DapperContext dappercontext, SqlQueryLoader queryLoader, IDbConnection dbConnection)
        {
            _context = context;
            _dappercontext = dappercontext;
            _queryLoader = queryLoader;
            _dbConnection = dbConnection;
        }

        public async Task<List<AdsMediaDto>> GetAdsMedia(GetAdsMediaCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);
            parameters.Add("@FilterAdsCode", request.FilterAdsCode ?? (object)DBNull.Value);
            parameters.Add("@FilterAdsName", request.FilterAdsName ?? (object)DBNull.Value);
            parameters.Add("@FilterAdsCategoryCode", request.FilterAdsCategoryCode ?? (object)DBNull.Value);
            parameters.Add("@SortBy", request.SortBy);
            parameters.Add("@OrderBy", request.OrderBy);

            var query = await _queryLoader.LoadQueryAsync("MasterData/AdsMedia/Sql/search_ads_media");
            var adsMedia = await _dbConnection.QueryAsync<AdsMediaDto>(query, parameters);

            return adsMedia.ToList();
        }

        public async Task<AdsMediaDto> GetAdsMediaByCode(GetAdsMediaByCodeCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FilterAdsCode", request.FilterAdsCode ?? (object)DBNull.Value);

            var query = await _queryLoader.LoadQueryAsync("MasterData/AdsMedia/Sql/search_ads_media_by_code");

            var adsMedia = await _dbConnection.QueryFirstOrDefaultAsync<AdsMediaDto>(query, parameters);

            return adsMedia;
        }

        public async Task<List<AdsMediaDto>> GetAdsMediaDdl(GetAdsMediaDdlCommand request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@FilterAdsCategoryCode", request.FilterAdsCategoryCode ?? (object)DBNull.Value);

            var query = await _queryLoader.LoadQueryAsync("MasterData/AdsMedia/Sql/search_ads_media_ddl");
            var adsMedia = await _dbConnection.QueryAsync<AdsMediaDto>(query, parameters);

            return adsMedia.ToList();
        }
    }
}
