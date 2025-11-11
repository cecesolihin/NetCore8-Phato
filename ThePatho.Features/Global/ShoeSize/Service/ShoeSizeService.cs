using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.ShoeSize.Commands;
using ThePatho.Features.Global.ShoeSize.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.ShoeSize.Service
{
    public class ShoeSizeService : IShoeSizeService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public ShoeSizeService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<ShoeSizeItemDto>> GetShoeSize(GetShoeSizeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@ShoeSizeCode", request.FilterShoeSizeCode ?? string.Empty);
                parameters.Add("@ShoeSizeName", request.FilterShoeSizeName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/ShoeSize/Sql/get_shoesize");
                var data = await dbConnection.QueryAsync<ShoeSizeDto>(query, parameters);
                var result = new ShoeSizeItemDto
                {
                    DataOfRecords = data.Count(),
                    ShoeSizeList = data.ToList(),
                };
                return new ApiResponse<ShoeSizeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ShoeSizeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<ShoeSizeDto>> GetSingleShoeSize(GetSingleShoeSizeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ShoeSizeCode", request.FilterShoeSizeCode);

                var query = await queryLoader.LoadQueryAsync("Global/ShoeSize/Sql/get_single_shoesize");

                var data = await dbConnection.QueryFirstOrDefaultAsync<ShoeSizeDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<ShoeSizeDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<ShoeSizeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ShoeSizeDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<ShoeSizeItemDto>> GetShoeSizeByCriteria(GetShoeSizeByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ShoeSizeCode", request.FilterShoeSizeCode ?? string.Empty);
                parameters.Add("@ShoeSizeName", request.FilterShoeSizeName ?? string.Empty);


                var query = await queryLoader.LoadQueryAsync("Global/ShoeSize/Sql/get_criteria_shoesize");
                var data = await dbConnection.QueryAsync<ShoeSizeDto>(query, parameters);
                var result = new ShoeSizeItemDto
                {
                    DataOfRecords = data.Count(),
                    ShoeSizeList = data.ToList(),
                };
                return new ApiResponse<ShoeSizeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ShoeSizeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitShoeSize(SubmitShoeSizeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ShoeSizeCode", request.ShoeSizeCode ?? string.Empty);
                parameters.Add("@ShoeSizeName", request.ShoeSizeName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/ShoeSize/Sql/submit_shoesize");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.ShoeSizeName} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.ShoeSizeName}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteShoeSize(DeleteShoeSizeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ShoeSizeCode", request.ShoeSizeCode);

                var query = await queryLoader.LoadQueryAsync("Global/ShoeSize/Sql/get_single_shoesize");

                var data = await dbConnection.QueryFirstOrDefaultAsync<ShoeSizeDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<ShoeSizeDto>(HttpStatusCode.NotFound, "data not found");
                }
                var query_delete = await queryLoader.LoadQueryAsync("Global/ShoeSize/Sql/delete_shoesize");
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
