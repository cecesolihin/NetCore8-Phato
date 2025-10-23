using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.ClothSize.Commands;
using ThePatho.Features.Global.ClothSize.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.ClothSize.Service
{
    public class ClothSizeService : IClothSizeService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public ClothSizeService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<ClothSizeItemDto>> GetClothSize(GetClothSizeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@ClothSizeCode", request.FilterClothSizeCode ?? string.Empty);
                parameters.Add("@ClothSizeName", request.FilterClothSizeName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/ClothSize/Sql/get_clothsize");
                var data = await dbConnection.QueryAsync<ClothSizeDto>(query, parameters);
                var result = new ClothSizeItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    ClothSizeList = data.ToList(),
                };
                return new ApiResponse<ClothSizeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ClothSizeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<ClothSizeDto>> GetSingleClothSize(GetSingleClothSizeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ClothSizeCode", request.FilterClothSizeCode);

                var query = await queryLoader.LoadQueryAsync("Global/ClothSize/Sql/get_single_clothsize");

                var data = await dbConnection.QueryFirstOrDefaultAsync<ClothSizeDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<ClothSizeDto>(
                                        HttpStatusCode.BadRequest,
                                        "data not found",
                                        null
                                    );
                }
                return new ApiResponse<ClothSizeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ClothSizeDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<ClothSizeItemDto>> GetClothSizeByCriteria(GetClothSizeByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ClothSizeCode", request.FilterClothSizeCode ?? string.Empty);
                parameters.Add("@ClothSizeName", request.FilterClothSizeName ?? string.Empty);


                var query = await queryLoader.LoadQueryAsync("Global/ClothSize/Sql/get_criteria_clothsize");
                var data = await dbConnection.QueryAsync<ClothSizeDto>(query, parameters);
                var result = new ClothSizeItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    ClothSizeList = data.ToList(),
                };
                return new ApiResponse<ClothSizeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ClothSizeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitClothSize(SubmitClothSizeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ClothSizeCode", request.ClothSizeCode);
                parameters.Add("@ClothSizeName", request.ClothSizeName);                
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/ClothSize/Sql/submit_ClothSize");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.ClothSizeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.ClothSizeCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteClothSize(DeleteClothSizeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ClothSizeCode", request.ClothSizeCode);

                var query_single = await queryLoader.LoadQueryAsync("Global/ClothSize/Sql/get_single_clothsize");

                var data_single = await dbConnection.QueryFirstOrDefaultAsync<ClothSizeDto>(query_single, parameters);
                if (data_single == null)
                {
                    return new ApiResponse(
                                        HttpStatusCode.BadRequest,
                                        "data not found",
                                        null
                                    );
                }
                var query = await queryLoader.LoadQueryAsync("Global/ClothSize/Sql/delete_clothsize");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"Delete successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message.ToString());
            }
        }

    }
}
