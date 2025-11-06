using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.SkillProficiency.Commands;
using ThePatho.Features.Global.SkillProficiency.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.SkillProficiency.Service
{
    public class SkillProficiencyService : ISkillProficiencyService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public SkillProficiencyService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<SkillProficiencyItemDto>> GetSkillProficiency(GetSkillProficiencyCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@ProfiencyCode", request.FilterProfiencyCode ?? string.Empty);
                parameters.Add("@ProfiencyName", request.FilterProfiencyName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/SkillProficiency/Sql/get_skillproficiency");
                var data = await dbConnection.QueryAsync<SkillProficiencyDto>(query, parameters);
                var result = new SkillProficiencyItemDto
                {
                    DataOfRecords = data.Count(),
                    SkillProficiencyList = data.ToList(),
                };
                return new ApiResponse<SkillProficiencyItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<SkillProficiencyItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<SkillProficiencyDto>> GetSingleSkillProficiency(GetSingleSkillProficiencyCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProfiencyCode", request.FilterProfiencyCode);

                var query = await queryLoader.LoadQueryAsync("Global/SkillProficiency/Sql/get_single_skillproficiency");

                var data = await dbConnection.QueryFirstOrDefaultAsync<SkillProficiencyDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<SkillProficiencyDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<SkillProficiencyDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<SkillProficiencyDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<SkillProficiencyItemDto>> GetSkillProficiencyByCriteria(GetSkillProficiencyByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProfiencyCode", request.FilterProfiencyCode ?? string.Empty);
                parameters.Add("@ProfiencyName", request.FilterProfiencyName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/SkillProficiency/Sql/get_criteria_skillproficiency");
                var data = await dbConnection.QueryAsync<SkillProficiencyDto>(query, parameters);
                var result = new SkillProficiencyItemDto
                {
                    DataOfRecords = data.Count(),
                    SkillProficiencyList = data.ToList(),
                };
                return new ApiResponse<SkillProficiencyItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<SkillProficiencyItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitSkillProficiency(SubmitSkillProficiencyCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProfiencyCode", request.ProfiencyCode);
                parameters.Add("@ProfiencyName", request.ProfiencyName);
          
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/SkillProficiency/Sql/submit_skillproficiency");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.ProfiencyCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.ProfiencyCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteSkillProficiency(DeleteSkillProficiencyCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProfiencyCode", request.ProfiencyCode);

                var query = await queryLoader.LoadQueryAsync("Global/SkillProficiency/Sql/delete_skillproficiency");
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
