using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.FamilyRelation.Commands;
using ThePatho.Features.Global.FamilyRelation.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.FamilyRelation.Service
{
    public class FamilyRelationService : IFamilyRelationService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public FamilyRelationService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<FamilyRelationItemDto>> GetFamilyRelation(GetFamilyRelationCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@RelationCode", request.FilterRelationCode ?? string.Empty);
                parameters.Add("@RelationName", request.FilterRelationCode ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/FamilyRelation/Sql/get_familyrelation");
                var data = await dbConnection.QueryAsync<FamilyRelationDto>(query, parameters);
                var result = new FamilyRelationItemDto
                {
                    DataOfRecords = data.Count(),
                    FamilyRelationList = data.ToList(),
                };
                return new ApiResponse<FamilyRelationItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<FamilyRelationItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<FamilyRelationDto>> GetSingleFamilyRelation(GetSingleFamilyRelationCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RelationCode", request.FilterRelationCode);

                var query = await queryLoader.LoadQueryAsync("Global/FamilyRelation/Sql/get_single_familyrelation");

                var data = await dbConnection.QueryFirstOrDefaultAsync<FamilyRelationDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<FamilyRelationDto>(HttpStatusCode.OK, "data not found");
                }
                return new ApiResponse<FamilyRelationDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<FamilyRelationDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<FamilyRelationItemDto>> GetFamilyRelationByCriteria(GetFamilyRelationByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RelationCode", request.RelationCode ?? string.Empty);
                parameters.Add("@RelationName", request.RelationCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("Global/FamilyRelation/Sql/get_criteria_familyrelation");
                var data = await dbConnection.QueryAsync<FamilyRelationDto>(query, parameters);
                var result = new FamilyRelationItemDto
                {
                    DataOfRecords = data.Count(),
                    FamilyRelationList = data.ToList(),
                };
                return new ApiResponse<FamilyRelationItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<FamilyRelationItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitFamilyRelation(SubmitFamilyRelationCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RelationCode", request.RelationCode);
                parameters.Add("@RelationName", request.RelationName);
                parameters.Add("@RelationGender", request.RelationGender);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("Global/FamilyRelation/Sql/submit_familyrelation");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.RelationName} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.RelationName}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteFamilyRelation(DeleteFamilyRelationCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RelationCode", request.RelationCode);
                var query = await queryLoader.LoadQueryAsync("Global/FamilyRelation/Sql/get_single_familyrelation");

                var data = await dbConnection.QueryFirstOrDefaultAsync<FamilyRelationDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<FamilyRelationDto>(HttpStatusCode.OK, "data not found");
                }
                var query_delete = await queryLoader.LoadQueryAsync("Global/FamilyRelation/Sql/delete_familyrelation");
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

