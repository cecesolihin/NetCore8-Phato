using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ThePatho.Features.MasterData.JobCategory.Commands;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.MasterData.JobCategory.Service
{
    public class JobCategoryService : IJobCategoryService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public JobCategoryService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<List<JobCategoryDto>> GetJobCategory(GetJobCategoryCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);
            parameters.Add("@JobCategoryCode", request.FilterJobCategoryCode ?? (object)DBNull.Value);
            parameters.Add("@JobCategoryName", request.FilterJobCategoryName ?? (object)DBNull.Value);
            parameters.Add("@SortBy", request.SortBy);
            parameters.Add("@OrderBy", request.OrderBy);

            var query = await queryLoader.LoadQueryAsync("MasterData/JobCategory/Sql/search_job_category");
            var data = await dbConnection.QueryAsync<JobCategoryDto>(query, parameters);

            return data.ToList();
        }

        public async Task<JobCategoryDto> GetJobCategoryByCode(GetJobCategoryByCriteriaCommand request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@JobCategoryCode", request.@FilterJobCategoryCode ?? (object)DBNull.Value);

            var query = await queryLoader.LoadQueryAsync("MasterData/JobCategory/Sql/search_job_category_by_code");

            var data = await dbConnection.QueryFirstOrDefaultAsync<JobCategoryDto>(query, parameters);

            return data;
        }

        public async Task<List<JobCategoryDto>> GetJobCategoryDdl(GetJobCategoryDdlCommand request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@JobCategoryCode", request.@FilterJobCategoryCode ?? (object)DBNull.Value);

            var query = await queryLoader.LoadQueryAsync("MasterData/JobCategory/Sql/search_job_category_ddl");
            var data = await dbConnection.QueryAsync<JobCategoryDto>(query, parameters);

            return data.ToList();
        }
    }
}
