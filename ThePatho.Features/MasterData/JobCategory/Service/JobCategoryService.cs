using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using ThePatho.Provider.ApiResponse;
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

        public async Task<ApiResponse<JobCategoryItemDto>> GetJobCategory(GetJobCategoryCommand request)
        {
            try
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

                var result = new JobCategoryItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    JobCategoryList = data.ToList(),
                };
                return new ApiResponse<JobCategoryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new ApiResponse<JobCategoryItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
            
        }

        public async Task<ApiResponse<JobCategoryDto>> GetJobCategoryByCriteria(GetJobCategoryByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@JobCategoryCode", request.@FilterJobCategoryCode ?? (object)DBNull.Value);

                var query = await queryLoader.LoadQueryAsync("MasterData/JobCategory/Sql/search_job_category_by_code");

                var data = await dbConnection.QueryFirstOrDefaultAsync<JobCategoryDto>(query, parameters);

                return new ApiResponse<JobCategoryDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobCategoryDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
            
        }

        public async Task<ApiResponse<JobCategoryItemDto>> GetJobCategoryDdl(GetJobCategoryDdlCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@JobCategoryCode", request.@FilterJobCategoryCode ?? (object)DBNull.Value);

                var query = await queryLoader.LoadQueryAsync("MasterData/JobCategory/Sql/search_job_category_ddl");
                var data = await dbConnection.QueryAsync<JobCategoryDto>(query, parameters);

                var result = new JobCategoryItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    JobCategoryList = data.ToList(),
                };
                return new ApiResponse<JobCategoryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new ApiResponse<JobCategoryItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
            
        }

        public async Task<ApiResponse> SubmitJobCategory(SubmitJobCategoryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@JobCategoryCode", request.JobCategoryCode);
                parameters.Add("@JobCategoryName", request.JobCategoryName);
                parameters.Add("@IsCategory", request.IsCategory);
                parameters.Add("@ParentCategory", request.ParentCategory);
                parameters.Add("@Action", request.Action); // "ADD" or "EDIT"
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("MasterData/JobCategory/Sql/submit_job_category");
                await dbConnection.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.JobCategoryCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.JobCategoryCode}", ex.Message.ToString());
            }
            
        }
        public async Task<ApiResponse> DeleteJobCategory(DeleteJobCategoryCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@JobCategoryCode", request.JobCategoryCode);

                var query = await queryLoader.LoadQueryAsync("MasterData/JobCategory/Sql/delete_job_category");
                await dbConnection.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.JobCategoryCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.JobCategoryCode}", ex.Message.ToString());
            }
            
        }
    }
}
