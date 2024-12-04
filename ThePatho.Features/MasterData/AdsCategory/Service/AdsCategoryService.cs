using ThePatho.Features.MasterData.AdsCategory.Service;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data;

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

        public async Task<List<AdsCategoryDto>> GetAllAdsCategoriesAsync()
        {
            var adsCategoryDto = new List<AdsCategoryDto>();
            
            var query = await _queryLoader.LoadQueryAsync("MasterData/AdsCategory/Sql/search_all_ads_category");

            var adsCategories = await _dbConnection.QueryAsync<AdsCategoryDto>(query);
     
            return adsCategories.ToList();
        }

        public Task<AdsCategoryDto?> GetAdsCategoryByCodeAsync(string adsCategoryCode)
        {
            throw new NotImplementedException();
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
