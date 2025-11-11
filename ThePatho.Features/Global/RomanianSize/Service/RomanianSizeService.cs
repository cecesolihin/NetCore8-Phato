using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.RomanianSize.Commands;
using ThePatho.Features.Global.RomanianSize.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.RomanianSize.Service
{
    public class RomanianSizeService : IRomanianSizeService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public RomanianSizeService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<RomanianSizeItemDto>> GetRomanianSize(GetRomanianSizeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@RomanianSizeName", request.FilterRomanianSizeName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/RomanianSize/Sql/get_romaniansize");
                var data = await dbConnection.QueryAsync<RomanianSizeDto>(query, parameters);
                var result = new RomanianSizeItemDto
                {
                    DataOfRecords = data.Count(),
                    RomanianSizeList = data.ToList(),
                };
                return new ApiResponse<RomanianSizeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<RomanianSizeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<RomanianSizeDto>> GetSingleRomanianSize(GetSingleRomanianSizeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RomanianSizeId", request.FilterRomanianSizeId);

                var query = await queryLoader.LoadQueryAsync("Global/RomanianSize/Sql/get_single_romaniansize");

                var data = await dbConnection.QueryFirstOrDefaultAsync<RomanianSizeDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<RomanianSizeDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<RomanianSizeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<RomanianSizeDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<RomanianSizeItemDto>> GetRomanianSizeByCriteria(GetRomanianSizeByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RomanianSizeName", request.FilterRomanianSizeName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/RomanianSize/Sql/get_criteria_romaniansize");
                var data = await dbConnection.QueryAsync<RomanianSizeDto>(query, parameters);
                var result = new RomanianSizeItemDto
                {
                    DataOfRecords = data.Count(),
                    RomanianSizeList = data.ToList(),
                };
                return new ApiResponse<RomanianSizeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<RomanianSizeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitRomanianSize(SubmitRomanianSizeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RomanianSizeId", request.RomanianSizeId);
                parameters.Add("@RomanianSizeName", request.RomanianSizeName);
            
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/RomanianSize/Sql/submit_romaniansize");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.RomanianSizeName} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.RomanianSizeName}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteRomanianSize(DeleteRomanianSizeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RomanianSizeId", request.RomanianSizeId);

                var query = await queryLoader.LoadQueryAsync("Global/RomanianSize/Sql/get_single_romaniansize");

                var data = await dbConnection.QueryFirstOrDefaultAsync<RomanianSizeDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<RomanianSizeDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("Global/RomanianSize/Sql/delete_romaniansize");
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
