using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.MedicalGroup.Commands;
using ThePatho.Features.Global.MedicalGroup.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.MedicalGroup.Service
{
    public class MedicalGroupService : IMedicalGroupService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public MedicalGroupService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<MedicalGroupItemDto>> GetMedicalGroup(GetMedicalGroupCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@MedicalGroupCode", request.FilterMedicalGroupCode ?? string.Empty);
                parameters.Add("@MedicalGroupName", request.FilterMedicalGroupName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/MedicalGroup/Sql/get_medicalgroup");
                var data = await dbConnection.QueryAsync<MedicalGroupDto>(query, parameters);
                var result = new MedicalGroupItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    MedicalGroupList = data.ToList(),
                };
                return new ApiResponse<MedicalGroupItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<MedicalGroupItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<MedicalGroupDto>> GetSingleMedicalGroup(GetSingleMedicalGroupCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MedicalGroupCode", request.FilterMedicalGroupCode);

                var query = await queryLoader.LoadQueryAsync("Global/MedicalGroup/Sql/get_single_medicalgroup");

                var data = await dbConnection.QueryFirstOrDefaultAsync<MedicalGroupDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<MedicalGroupDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<MedicalGroupDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<MedicalGroupDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<MedicalGroupItemDto>> GetMedicalGroupByCriteria(GetMedicalGroupByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MedicalGroupCode", request.FilterMedicalGroupCode ?? string.Empty);
                parameters.Add("@MedicalGroupName", request.FilterMedicalGroupName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/MedicalGroup/Sql/get_criteria_medicalgroup");
                var data = await dbConnection.QueryAsync<MedicalGroupDto>(query, parameters);
                var result = new MedicalGroupItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    MedicalGroupList = data.ToList(),
                };
                return new ApiResponse<MedicalGroupItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<MedicalGroupItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitMedicalGroup(SubmitMedicalGroupCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MedicalGroupCode", request.MedicalGroupCode);
                parameters.Add("@MedicalGroupName", request.MedicalGroupName);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/MedicalGroup/Sql/submit_medicalgroup");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.MedicalGroupCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.MedicalGroupCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteMedicalGroup(DeleteMedicalGroupCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MedicalGroupCode", request.MedicalGroupCode);

                var query = await queryLoader.LoadQueryAsync("Global/MedicalGroup/Sql/get_single_medicalgroup");

                var data = await dbConnection.QueryFirstOrDefaultAsync<MedicalGroupDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<MedicalGroupDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("Global/MedicalGroup/Sql/delete_medicalgroup");
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
