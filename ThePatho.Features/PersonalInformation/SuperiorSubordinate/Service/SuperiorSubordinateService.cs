using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.QueryExecute;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Service
{
    public class SuperiorSubordinateService : ISuperiorSubordinateService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public SuperiorSubordinateService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<SuperiorSubordinateItemDto>> GetSuperiorSubordinate(GetSuperiorSubordinateCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@Employee", request.FilterEmployee ?? string.Empty);
                parameters.Add("@Superior", request.FilterSuperior ?? string.Empty);
                parameters.Add("@Status", request.FilterStatus ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/get_superior_subordinate");
                var data = await db.QueryAsync<SuperiorSubordinateDto>(query, parameters);

                var result = new SuperiorSubordinateItemDto
                {
                    DataOfRecords = data.Count(),
                    SuperiorSubordinateList = data.ToList()
                };

                return new ApiResponse<SuperiorSubordinateItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<SuperiorSubordinateItemDto>(HttpStatusCode.BadRequest, "Error retrieving Superior Subordinate list.", ex.Message);
            }
        }

        public async Task<ApiResponse<SuperiorSubordinateDto>> GetSingleSuperiorSubordinate(GetSingleSuperiorSubordinateCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeSuperiorID", request.EmployeeSuperiorID);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/get_single_superior_subordinate");
                var data = await db.QueryFirstOrDefaultAsync<SuperiorSubordinateDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<SuperiorSubordinateDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<SuperiorSubordinateDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<SuperiorSubordinateDto>(HttpStatusCode.BadRequest, "Error retrieving Superior Subordinate detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<SuperiorSubordinateItemDto>> GetSuperiorSubordinateByCriteria(GetSuperiorSubordinateByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@Employee", request.FilterEmployee ?? string.Empty);
                parameters.Add("@Superior", request.FilterSuperior ?? string.Empty);
                parameters.Add("@Status", request.FilterStatus ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/get_criteria_superior_subordinate");
                var data = await db.QueryAsync<SuperiorSubordinateDto>(query, parameters);

                var result = new SuperiorSubordinateItemDto
                {
                    DataOfRecords = data.Count(),
                    SuperiorSubordinateList = data.ToList()
                };

                return new ApiResponse<SuperiorSubordinateItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<SuperiorSubordinateItemDto>(HttpStatusCode.BadRequest, "Error filtering Superior Subordinate data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitSuperiorSubordinate(SubmitSuperiorSubordinateCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeSuperiorID", request.EmployeeSuperiorID);
                parameters.Add("@EmployeeID", request.EmployeeID);
                parameters.Add("@EffectiveDate", request.EffectiveDate);
                parameters.Add("@Remarks", request.Remarks);

                parameters.Add("@Superior1ID", request.Superior1ID);
                parameters.Add("@Superior2ID", request.Superior2ID);
                parameters.Add("@Superior3ID", request.Superior3ID);
                parameters.Add("@Superior4ID", request.Superior4ID);
                parameters.Add("@Superior5ID", request.Superior5ID);
                parameters.Add("@Superior6ID", request.Superior6ID);
                parameters.Add("@Superior7ID", request.Superior7ID);
                parameters.Add("@Superior8ID", request.Superior8ID);
                parameters.Add("@Superior9ID", request.Superior9ID);
                parameters.Add("@Superior10ID", request.Superior10ID);

                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/submit_superior_subordinate");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }
        public async Task<ApiResponse> SubmitMultiSuperiorSubordinate(SubmitMultiSuperiorSubordinateCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeList", string.Join(",", request.EmployeeList));
                parameters.Add("@EffectiveDate", request.EffectiveDate);
                parameters.Add("@Remarks", request.Remarks);

                parameters.Add("@Superior1ID", request.Superior1ID);
                parameters.Add("@Superior2ID", request.Superior2ID);
                parameters.Add("@Superior3ID", request.Superior3ID);
                parameters.Add("@Superior4ID", request.Superior4ID);
                parameters.Add("@Superior5ID", request.Superior5ID);
                parameters.Add("@Superior6ID", request.Superior6ID);
                parameters.Add("@Superior7ID", request.Superior7ID);
                parameters.Add("@Superior8ID", request.Superior8ID);
                parameters.Add("@Superior9ID", request.Superior9ID);
                parameters.Add("@Superior10ID", request.Superior10ID);

                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/submit_multi_superior_subordinate");
                var result = await db.QueryFirstOrDefaultAsync<ExecuteResult>(query, parameters);

                if (result != null && result.Success)
                    return new ApiResponse(HttpStatusCode.OK, result.Message);
                else
                    return new ApiResponse(HttpStatusCode.BadRequest, result?.Message ?? "Unknown error", result?.ErrorNote);
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteSuperiorSubordinate(DeleteSuperiorSubordinateCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeSuperiorID", request.EmployeeSuperiorID);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/get_single_superior_subordinate");
                var data = await db.QueryFirstOrDefaultAsync<SuperiorSubordinateDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<SuperiorSubordinateDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/delete_superior_subordinate");
                await db.ExecuteAsync(query_delete, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message);
            }
        }

        public async Task<ApiResponse> GenerateSuperiorSubordinate(GenerateSuperiorSubordinateCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EffectiveDate", request.EffectiveDate);
                parameters.Add("@IsOverWrite", request.OverWrite ?? false);
                parameters.Add("@EmployeeList", string.Join(",",request.EmployeeList));
                parameters.Add("@Remarks", request.Remarks);
                parameters.Add("@Action", "Generate");
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/generate_superior_subordinate");
                var result = await db.QueryFirstOrDefaultAsync<ExecuteResult>(query, parameters);

                if (result != null && result.Success)
                    return new ApiResponse(HttpStatusCode.OK, result.Message);
                else
                    return new ApiResponse(HttpStatusCode.BadRequest, result?.Message ?? "Unknown error", result?.ErrorNote);
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to generate", ex.Message);
            }
        }

        #endregion
    }
}

