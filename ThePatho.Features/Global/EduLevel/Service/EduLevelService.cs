using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.EduLevel.Commands;
using ThePatho.Features.Global.EduLevel.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.EduLevel.Service
{
    public class EduLevelService : IEduLevelService
    {
        private readonly DapperContext dapperContext;

        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public EduLevelService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<EduLevelItemDto>> GetEduLevel(GetEduLevelCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EduLevelCode", request.FilterEduLevelCode ?? string.Empty);
                parameters.Add("@EduLevelName", request.FilterEduLevelName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/EduLevel/Sql/get_edulevel");
                var data = await dbConnection.QueryAsync<EduLevelDto>(query, parameters);
                var result = new EduLevelItemDto
                {
                    DataOfRecords = data.Count(),
                    EduLevelList = data.ToList(),
                };
                return new ApiResponse<EduLevelItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EduLevelItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<EduLevelDto>> GetSingleEduLevel(GetSingleEduLevelCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EduLevelCode", request.EduLevelCode);

                var query = await queryLoader.LoadQueryAsync("Global/EduLevel/Sql/get_single_edulevel");

                var data = await dbConnection.QueryFirstOrDefaultAsync<EduLevelDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<EduLevelDto>(HttpStatusCode.OK, "data not found");
                }
                return new ApiResponse<EduLevelDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EduLevelDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<EduLevelItemDto>> GetEduLevelByCriteria(GetEduLevelByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EduLevelCode", request.FilterEduLevelCode ?? string.Empty);
                parameters.Add("@EduLevelName", request.FilterEduLevelName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/EduLevel/Sql/get_criteria_edulevel");
                var data = await dbConnection.QueryAsync<EduLevelDto>(query, parameters);
                var result = new EduLevelItemDto
                {
                    DataOfRecords = data.Count(),
                    EduLevelList = data.ToList(),
                };
                return new ApiResponse<EduLevelItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EduLevelItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitEduLevel(SubmitEduLevelCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EduLevelCode", request.EduLevelCode);
                parameters.Add("@EduLevelName", request.EduLevelName);
                parameters.Add("@Sort", request.Sort);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/EduLevel/Sql/submit_edulevel");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.EduLevelName} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.EduLevelName}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteEduLevel(DeleteEduLevelCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EduLevelCode", request.EduLevelCode);
                var query = await queryLoader.LoadQueryAsync("Global/EduLevel/Sql/get_single_edulevel");

                var data = await dbConnection.QueryFirstOrDefaultAsync<EduLevelDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<EduLevelDto>(HttpStatusCode.OK, "data not found");
                }
                var query_delete = await queryLoader.LoadQueryAsync("Global/EduLevel/Sql/delete_edulevel");
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

