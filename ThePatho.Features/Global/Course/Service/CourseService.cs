using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.Course.Commands;
using ThePatho.Features.Global.Course.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Course.Service
{
    public class CourseService : ICourseService
    {
        private readonly DapperContext dapperContext;

        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public CourseService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<CourseItemDto>> GetCourse(GetCourseCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@CourseCode", request.FilterCourseCode ?? string.Empty);
                parameters.Add("@CourseName", request.FilterCourseName ?? string.Empty);
                parameters.Add("@TrainingFieldCode", request.FilterTrainingFieldCode ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/Course/Sql/get_course");
                var data = await dbConnection.QueryAsync<CourseDto>(query, parameters);
                var result = new CourseItemDto
                {
                    DataOfRecords = data.Count(),
                    CourseList = data.ToList(),
                };
                return new ApiResponse<CourseItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CourseItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<CourseDto>> GetSingleCourse(GetSingleCourseCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CourseCode", request.FilterCourseCode);

                var query = await queryLoader.LoadQueryAsync("Global/Course/Sql/get_single_course");

                var data = await dbConnection.QueryFirstOrDefaultAsync<CourseDto>(query, parameters);
                if (data ==null)
                {
                    return new ApiResponse<CourseDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<CourseDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CourseDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<CourseItemDto>> GetCourseByCriteria(GetCourseByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CourseCode", request.FilterCourseCode ?? string.Empty);
                parameters.Add("@CourseName", request.FilterCourseName ?? string.Empty);
                parameters.Add("@TrainingFieldCode", request.FilterTrainingFieldCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/Course/Sql/get_criteria_course");
                var data = await dbConnection.QueryAsync<CourseDto>(query, parameters);
                var result = new CourseItemDto
                {
                    DataOfRecords = data.Count(),
                    CourseList = data.ToList(),
                };
                return new ApiResponse<CourseItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CourseItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitCourse(SubmitCourseCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CourseCode", request.CourseCode);
                parameters.Add("@CourseName", request.CourseName);
                parameters.Add("@TrainingFieldCode", request.TrainingFieldCode);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/Course/Sql/submit_course");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.CourseName} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.CourseName}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteCourse(DeleteCourseCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CourseCode", request.CourseCode);
                var query = await queryLoader.LoadQueryAsync("Global/Course/Sql/get_single_course");

                var data = await dbConnection.QueryFirstOrDefaultAsync<CourseDto>(query, parameters);
                if (data == null)
                    return new ApiResponse<CourseDto>(HttpStatusCode.NotFound, "data not found");

                var query_delete = await queryLoader.LoadQueryAsync("Global/Course/Sql/delete_course");
                await dbConnection.ExecuteAsync(query_delete, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"Delete successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message.ToString());
            }
        }

    }
}

