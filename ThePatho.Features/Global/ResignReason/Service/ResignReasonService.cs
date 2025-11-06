using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.ResignReason.Commands;
using ThePatho.Features.Global.ResignReason.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.ResignReason.Service
{
    public class ResignReasonService : IResignReasonService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public ResignReasonService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<ResignReasonItemDto>> GetResignReason(GetResignReasonCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@ResignReasonCode", request.FilterResignReasonCode ?? string.Empty);
                parameters.Add("@ResignReasonName", request.FilterResignReasonName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/ResignReason/Sql/get_resignreason");
                var data = await dbConnection.QueryAsync<ResignReasonDto>(query, parameters);
                var result = new ResignReasonItemDto
                {
                    DataOfRecords = data.Count(),
                    ResignReasonList = data.ToList(),
                };
                return new ApiResponse<ResignReasonItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ResignReasonItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<ResignReasonDto>> GetSingleResignReason(GetSingleResignReasonCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ResignReasonId", request.FilterResignReasonCode);

                var query = await queryLoader.LoadQueryAsync("Global/ResignReason/Sql/get_single_resignreason");

                var data = await dbConnection.QueryFirstOrDefaultAsync<ResignReasonDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<ResignReasonDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<ResignReasonDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ResignReasonDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<ResignReasonItemDto>> GetResignReasonByCriteria(GetResignReasonByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ResignReasonCode", request.FilterResignReasonCode ?? string.Empty);
                parameters.Add("@ResignReasonName", request.FilterResignReasonName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/ResignReason/Sql/get_criteria_resignreason");
                var data = await dbConnection.QueryAsync<ResignReasonDto>(query, parameters);
                var result = new ResignReasonItemDto
                {
                    DataOfRecords = data.Count(),
                    ResignReasonList = data.ToList(),
                };
                return new ApiResponse<ResignReasonItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ResignReasonItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitResignReason(SubmitResignReasonCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ResignReasonCode", request.ResignReasonCode);
                parameters.Add("@ResignReasonName", request.ResignReasonName);
                parameters.Add("@IsDeleted", request.IsDeleted);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/ResignReason/Sql/submit_resignreason");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.ResignReasonCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.ResignReasonCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteResignReason(DeleteResignReasonCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ResignReasonId", request.ResignReasonCode);

                var query = await queryLoader.LoadQueryAsync("Global/ResignReason/Sql/get_single_resignreason");

                var data = await dbConnection.QueryFirstOrDefaultAsync<ResignReasonDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<ResignReasonDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("Global/ResignReason/Sql/delete_resignreason");
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
