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

        public async Task<List<AdsCategoryDto>> GetAllAdsCategoriesAsync(GetAdsCategoryCommand request)
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

            return data.ToList();
        }

        public async Task<AdsCategoryDto> GetAdsCategoryByCriteria(GetAdsCategoryByCriteriaCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AdsCategoryCode", request.FilterAdsCategoryCode ?? (object)DBNull.Value);

            var query = await queryLoader.LoadQueryAsync("MasterData/AdsCategory/Sql/search_ads_category_by_code");

            var data = await dbConnection.QueryFirstOrDefaultAsync<AdsCategoryDto>(query, parameters);

            return data;
        }
        public async Task<List<AdsCategoryDto>> GetAdsCategoriesDdl(GetAdsCategoryDdlCommand request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@AdsCategoryCode", request.FilterAdsCategoryCode ?? (object)DBNull.Value);
            parameters.Add("@AdsCategoryName", request.FilterAdsCategoryName ?? (object)DBNull.Value);

            var query = await queryLoader.LoadQueryAsync("MasterData/AdsCategory/Sql/search_ads_category_ddl");
            var data = await dbConnection.QueryAsync<AdsCategoryDto>(query, parameters);

            return data.ToList();
        }
    }
}
