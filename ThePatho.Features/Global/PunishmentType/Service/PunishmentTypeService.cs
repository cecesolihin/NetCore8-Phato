using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.PunishmentType.Commands;
using ThePatho.Features.Global.PunishmentType.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.PunishmentType.Service
{
    public class PunishmentTypeService : IPunishmentTypeService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public PunishmentTypeService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<PunishmentTypeItemDto>> GetPunishmentType(GetPunishmentTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@PunishmentCode", request.FilterPunishmentCode ?? string.Empty);
                parameters.Add("@PunishmentName", request.FilterPunishmentName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/PunishmentType/Sql/get_punishmenttype");
                var data = await dbConnection.QueryAsync<PunishmentTypeDto>(query, parameters);
                var result = new PunishmentTypeItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    PunishmentTypeList = data.ToList(),
                };
                return new ApiResponse<PunishmentTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<PunishmentTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<PunishmentTypeDto>> GetSinglePunishmentType(GetSinglePunishmentTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PunishmentCode", request.FilterPunishmentCode);

                var query = await queryLoader.LoadQueryAsync("Global/PunishmentType/Sql/get_single_punishmenttype");

                var data = await dbConnection.QueryFirstOrDefaultAsync<PunishmentTypeDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<PunishmentTypeDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<PunishmentTypeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<PunishmentTypeDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<PunishmentTypeItemDto>> GetPunishmentTypeByCriteria(GetPunishmentTypeByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PunishmentCode", request.FilterPunishmentCode ?? string.Empty);
                parameters.Add("@PunishmentName", request.FilterPunishmentName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/PunishmentType/Sql/get_criteria_punishmenttype");
                var data = await dbConnection.QueryAsync<PunishmentTypeDto>(query, parameters);
                var result = new PunishmentTypeItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    PunishmentTypeList = data.ToList(),
                };
                return new ApiResponse<PunishmentTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<PunishmentTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitPunishmentType(SubmitPunishmentTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PunishmentCode", request.PunishmentCode);
                parameters.Add("@PunishmentName", request.PunishmentName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/PunishmentType/Sql/submit_punishmenttype");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.PunishmentName} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.PunishmentName}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeletePunishmentType(DeletePunishmentTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PunishmentCode", request.PunishmentCode);

                var query = await queryLoader.LoadQueryAsync("Global/PunishmentType/Sql/get_single_punishmenttype");

                var data = await dbConnection.QueryFirstOrDefaultAsync<PunishmentTypeDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<PunishmentTypeDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("Global/PunishmentType/Sql/delete_punishmenttype");
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
