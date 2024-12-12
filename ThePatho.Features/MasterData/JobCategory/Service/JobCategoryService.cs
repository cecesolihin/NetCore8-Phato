using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ThePatho.Features.MasterData.AdsCategory.Commands;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.MasterData.JobCategory.Service
{
    public class JobCategoryService : IJobCategoryService
    {
        private readonly SqlQueryLoader _queryLoader;
        private readonly IDbConnection _dbConnection;
        private readonly DapperContext _dappercontext;
        private readonly ApplicationDbContext _context;
        public JobCategoryService(ApplicationDbContext context, DapperContext dappercontext, SqlQueryLoader queryLoader, IDbConnection dbConnection)
        {
            _context = context;
            _dappercontext = dappercontext;
            _queryLoader = queryLoader;
            _dbConnection = dbConnection;
        }

        public async Task<List<JobCategoryDto>> GetJobCategory(GetJobCategoryCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);
            parameters.Add("@FilterJobCategoryCode", request.FilterJobCategoryCode ?? (object)DBNull.Value);
            parameters.Add("@FilterJobCategoryName", request.FilterJobCategoryName ?? (object)DBNull.Value);
            parameters.Add("@SortBy", request.SortBy);
            parameters.Add("@OrderBy", request.OrderBy);

            var query = await _queryLoader.LoadQueryAsync("MasterData/JobCategory/Sql/search_job_category");
            var JobCategory = await _dbConnection.QueryAsync<JobCategoryDto>(query, parameters);

            return JobCategory.ToList();
        }

        public async Task<JobCategoryDto> GetJobCategoryByCode(GetJobCategoryByCodeCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FilterJobCategoryCode", request.@FilterJobCategoryCode ?? (object)DBNull.Value);

            var query = await _queryLoader.LoadQueryAsync("MasterData/JobCategory/Sql/search_job_category_by_code");

            var JobCategory = await _dbConnection.QueryFirstOrDefaultAsync<JobCategoryDto>(query, parameters);

            return JobCategory;
        }

        public async Task<List<JobCategoryDto>> GetJobCategoryDdl(GetJobCategoryDdlCommand request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@FilterJobCategoryCode", request.@FilterJobCategoryCode ?? (object)DBNull.Value);

            var query = await _queryLoader.LoadQueryAsync("MasterData/JobCategory/Sql/search_job_category_ddl");
            var JobCategory = await _dbConnection.QueryAsync<JobCategoryDto>(query, parameters);

            return JobCategory.ToList();
        }
    }
}
