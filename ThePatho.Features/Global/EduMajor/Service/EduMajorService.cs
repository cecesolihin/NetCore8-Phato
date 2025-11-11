using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.EduMajor.Commands;
using ThePatho.Features.Global.EduMajor.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.EduMajor.Service
{
    public class EduMajorService : IEduMajorService
    {
        private readonly DapperContext dapperContext;

        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public EduMajorService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<EduMajorItemDto>> GetEduMajor(GetEduMajorCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@MajorCode", request.FilterMajorCode ?? string.Empty);
                parameters.Add("@MajorName", request.FilterMajorName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/EduMajor/Sql/get_edumajor");
                var data = await dbConnection.QueryAsync<EduMajorDto>(query, parameters);
                var result = new EduMajorItemDto
                {
                    DataOfRecords = data.Count(),
                    EduMajorList = data.ToList(),
                };
                return new ApiResponse<EduMajorItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EduMajorItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<EduMajorDto>> GetSingleEduMajor(GetSingleEduMajorCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MajorCode", request.MajorCode);

                var query = await queryLoader.LoadQueryAsync("Global/EduMajor/Sql/get_single_edumajor");

                var data = await dbConnection.QueryFirstOrDefaultAsync<EduMajorDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<EduMajorDto>(HttpStatusCode.OK, data);
                }
                return new ApiResponse<EduMajorDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EduMajorDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<EduMajorItemDto>> GetEduMajorByCriteria(GetEduMajorByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MajorCode", request.FilterMajorCode ?? string.Empty);
                parameters.Add("@MajorName", request.FilterMajorName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/EduMajor/Sql/get_criteria_edumajor");
                var data = await dbConnection.QueryAsync<EduMajorDto>(query, parameters);
                var result = new EduMajorItemDto
                {
                    DataOfRecords = data.Count(),
                    EduMajorList = data.ToList(),
                };
                return new ApiResponse<EduMajorItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EduMajorItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitEduMajor(SubmitEduMajorCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MajorCode", request.MajorCode);
                parameters.Add("@MajorName", request.MajorName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/EduMajor/Sql/submit_edumajor");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.MajorName} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.MajorName}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteEduMajor(DeleteEduMajorCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MajorCode", request.MajorCode);
                var query = await queryLoader.LoadQueryAsync("Global/EduMajor/Sql/get_single_edumajor");

                var data = await dbConnection.QueryFirstOrDefaultAsync<EduMajorDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<EduMajorDto>(HttpStatusCode.OK, data);
                }
                var query_delete = await queryLoader.LoadQueryAsync("Global/EduMajor/Sql/delete_edumajor");
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

