using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.NumericalSize.Commands;
using ThePatho.Features.Global.NumericalSize.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.NumericalSize.Service
{
    public class NumericalSizeService : INumericalSizeService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public NumericalSizeService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<NumericalSizeItemDto>> GetNumericalSize(GetNumericalSizeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@NumericalSizeName", request.FilterNumericalSizeName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/NumericalSize/Sql/get_numericalsize");
                var data = await dbConnection.QueryAsync<NumericalSizeDto>(query, parameters);
                var result = new NumericalSizeItemDto
                {
                    DataOfRecords = data.Count(),
                    NumericalSizeList = data.ToList(),
                };
                return new ApiResponse<NumericalSizeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<NumericalSizeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<NumericalSizeDto>> GetSingleNumericalSize(GetSingleNumericalSizeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@NumericalSizeId", request.FilterNumericalSizeId);

                var query = await queryLoader.LoadQueryAsync("Global/NumericalSize/Sql/get_single_numericalsize");

                var data = await dbConnection.QueryFirstOrDefaultAsync<NumericalSizeDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<NumericalSizeDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<NumericalSizeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<NumericalSizeDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<NumericalSizeItemDto>> GetNumericalSizeByCriteria(GetNumericalSizeByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@NumericalSizeName", request.FilterNumericalSizeName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/NumericalSize/Sql/get_criteria_numericalsize");
                var data = await dbConnection.QueryAsync<NumericalSizeDto>(query, parameters);
                var result = new NumericalSizeItemDto
                {
                    DataOfRecords = data.Count(),
                    NumericalSizeList = data.ToList(),
                };
                return new ApiResponse<NumericalSizeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<NumericalSizeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitNumericalSize(SubmitNumericalSizeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@NumericalSizeId", request.NumericalSizeId);
                parameters.Add("@NumericalSizeName", request.NumericalSizeName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/NumericalSize/Sql/submit_numericalsize");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.NumericalSizeName} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.NumericalSizeName}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteNumericalSize(DeleteNumericalSizeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@NumericalSizeId", request.NumericalSizeId);

                var query = await queryLoader.LoadQueryAsync("Global/NumericalSize/Sql/get_single_numericalsize");

                var data = await dbConnection.QueryFirstOrDefaultAsync<NumericalSizeDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<NumericalSizeDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("Global/NumericalSize/Sql/delete_numericalsize");
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
