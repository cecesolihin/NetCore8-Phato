using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.Skill.Commands;
using ThePatho.Features.Global.Skill.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Skill.Service
{
    public class SkillService : ISkillService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public SkillService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<SkillItemDto>> GetSkill(GetSkillCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@SkillCode", request.FilterSkillCode ?? string.Empty);
                parameters.Add("@SkillName", request.FilterSkillName ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/Skill/Sql/get_skill");
                var data = await dbConnection.QueryAsync<SkillDto>(query, parameters);
                var result = new SkillItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    SkillList = data.ToList(),
                };
                return new ApiResponse<SkillItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<SkillItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<SkillDto>> GetSingleSkill(GetSingleSkillCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SkillCode", request.FilterSkillCode);

                var query = await queryLoader.LoadQueryAsync("Global/Skill/Sql/get_single_skill");

                var data = await dbConnection.QueryFirstOrDefaultAsync<SkillDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<SkillDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<SkillDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<SkillDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<SkillItemDto>> GetSkillByCriteria(GetSkillByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SkillCode", request.FilterSkillCode ?? string.Empty);
                parameters.Add("@SkillName", request.FilterSkillName ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/Skill/Sql/get_criteria_skill");
                var data = await dbConnection.QueryAsync<SkillDto>(query, parameters);
                var result = new SkillItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    SkillList = data.ToList(),
                };
                return new ApiResponse<SkillItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<SkillItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitSkill(SubmitSkillCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SkillCode", request.SkillCode);
                parameters.Add("@SkillName", request.SkillName);
                parameters.Add("@IsDeleted", request.IsDeleted);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/Skill/Sql/submit_skill");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.SkillCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.SkillCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteSkill(DeleteSkillCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SkillCode", request.SkillCode);

                var query = await queryLoader.LoadQueryAsync("Global/Skill/Sql/delete_skill");
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
