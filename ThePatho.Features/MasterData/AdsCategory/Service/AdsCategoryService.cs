using ThePatho.Features.MasterData.AdsCategory.Service;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data;
using Azure.Core;
using ThePatho.Features.MasterData.AdsCategory.Commands;
using MediatR;

namespace ThePatho.Features.MasterData.AdsCategory.Service
{
    public class AdsCategoryService : IAdsCategoryService
    {
        
        private readonly SqlQueryLoader _queryLoader;
        private readonly IDbConnection _dbConnection;
        private readonly DapperContext _dappercontext;
        private readonly ApplicationDbContext _context;
        public AdsCategoryService(ApplicationDbContext context,DapperContext dappercontext ,SqlQueryLoader queryLoader, IDbConnection dbConnection)
        {
            _context = context;
            _dappercontext = dappercontext;
            _queryLoader = queryLoader;
            _dbConnection = dbConnection;
        }

        public async Task<List<AdsCategoryDto>> GetAllAdsCategoriesAsync(GetAdsCategoryCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);
            parameters.Add("@FilterAdsCategoryCode", request.FilterAdsCategoryCode ?? (object)DBNull.Value);
            parameters.Add("@FilterAdsCategoryName", request.FilterAdsCategoryName ?? (object)DBNull.Value);
            parameters.Add("@SortBy", request.SortBy);
            parameters.Add("@OrderBy", request.OrderBy);

            var query = await _queryLoader.LoadQueryAsync("MasterData/AdsCategory/Sql/search_all_ads_category");
            var adsCategories = await _dbConnection.QueryAsync<AdsCategoryDto>(query, parameters);

            return adsCategories.ToList();
        }

        public async Task<AdsCategoryDto> GetAdsCategoryByCode(GetAdsCategoryByCodeCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FilterAdsCategoryCode", request.FilterAdsCategoryCode ?? (object)DBNull.Value);

            var query = await _queryLoader.LoadQueryAsync("MasterData/AdsCategory/Sql/search_ads_category_by_code");

            var adsCategory = await _dbConnection.QueryFirstOrDefaultAsync<AdsCategoryDto>(query, parameters);

            return adsCategory;
        }
        public async Task<List<AdsCategoryDto>> GetAdsCategoriesDdl(GetAdsCategoryDdlCommand request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@FilterAdsCategoryCode", request.FilterAdsCategoryCode ?? (object)DBNull.Value);
            parameters.Add("@FilterAdsCategoryName", request.FilterAdsCategoryName ?? (object)DBNull.Value);

            var query = await _queryLoader.LoadQueryAsync("MasterData/AdsCategory/Sql/search_ads_category_ddl");
            var adsCategories = await _dbConnection.QueryAsync<AdsCategoryDto>(query, parameters);

            return adsCategories.ToList();
        }
        public Task<AdsCategoryDto> AddAdsCategoryAsync(AdsCategoryDto adsCategory)
        {
            throw new NotImplementedException();
        }

        public Task<AdsCategoryDto?> UpdateAdsCategoryAsync(AdsCategoryDto adsCategory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAdsCategoryAsync(string adsCategoryCode)
        {
            throw new NotImplementedException();
        }
    }
}
