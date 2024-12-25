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
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<List<AdsMediaDto>> GetAdsMedia(GetAdsMediaCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);
            parameters.Add("@AdsCode", request.FilterAdsCode ?? (object)DBNull.Value);
            parameters.Add("@AdsName", request.FilterAdsName ?? (object)DBNull.Value);
            parameters.Add("@AdsCategoryCode", request.FilterAdsCategoryCode ?? (object)DBNull.Value);
            parameters.Add("@SortBy", request.SortBy);
            parameters.Add("@OrderBy", request.OrderBy);

            var query = await queryLoader.LoadQueryAsync("MasterData/AdsMedia/Sql/search_ads_media");
            var data = await dbConnection.QueryAsync<AdsMediaDto>(query, parameters);

            return data.ToList();
        }

        public async Task<AdsMediaDto> GetAdsMediaByCriteria(GetAdsMediaByCriteriaCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AdsCode", request.FilterAdsCode ?? (object)DBNull.Value);

            var query = await queryLoader.LoadQueryAsync("MasterData/AdsMedia/Sql/search_ads_media_by_code");

            var data = await dbConnection.QueryFirstOrDefaultAsync<AdsMediaDto>(query, parameters);

            return data;
        }

        public async Task<List<AdsMediaDto>> GetAdsMediaDdl(GetAdsMediaDdlCommand request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@AdsCode", request.FilterAdsCategoryCode ?? (object)DBNull.Value);

            var query = await queryLoader.LoadQueryAsync("MasterData/AdsMedia/Sql/search_ads_media_ddl");
            var data = await dbConnection.QueryAsync<AdsMediaDto>(query, parameters);

            return data.ToList();
        }
    }
}
