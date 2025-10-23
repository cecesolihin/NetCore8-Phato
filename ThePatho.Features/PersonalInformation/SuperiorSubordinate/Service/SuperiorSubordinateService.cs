using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Service
{
    public class SuperiorSubordinateService : ISuperiorSubordinateService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        #endregion

        #region [CTOR]
        public SuperiorSubordinateService(DapperContext _dapperContext, SqlQueryLoader _queryLoader)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
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
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@EffectiveDate", request.FilterEffectiveDate ?? string.Empty);
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
                return new ApiResponse<SuperiorSubordinateItemDto>(HttpStatusCode.BadRequest, "Error retrieving Blood Type list.", ex.Message);
            }
        }

        public async Task<ApiResponse<SuperiorSubordinateDto>> GetSingleSuperiorSubordinate(GetSingleSuperiorSubordinateCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeSuperiorID", request.EmployeeSuperiorID);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/get_singel_superior_subordinate");
                var data = await db.QueryFirstOrDefaultAsync<SuperiorSubordinateDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<SuperiorSubordinateDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<SuperiorSubordinateDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<SuperiorSubordinateDto>(HttpStatusCode.BadRequest, "Error retrieving Blood Type detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<SuperiorSubordinateItemDto>> GetSuperiorSubordinateByCriteria(GetSuperiorSubordinateByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@EffectiveDate", request.FilterEffectiveDate ?? string.Empty);
                parameters.Add("@Superior", request.FilterSuperior ?? string.Empty);

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
                return new ApiResponse<SuperiorSubordinateItemDto>(HttpStatusCode.BadRequest, "Error filtering Blood Type data.", ex.Message);
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
                parameters.Add("@EndDate", request.EndDate);
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
                parameters.Add("@Superior11ID", request.Superior11ID);
                parameters.Add("@Superior12ID", request.Superior12ID);
                parameters.Add("@Superior13ID", request.Superior13ID);
                parameters.Add("@Superior14ID", request.Superior14ID);
                parameters.Add("@Superior15ID", request.Superior15ID);
                parameters.Add("@Superior16ID", request.Superior16ID);
                parameters.Add("@Superior17ID", request.Superior17ID);
                parameters.Add("@Superior18ID", request.Superior18ID);
                parameters.Add("@Superior19ID", request.Superior19ID);
                parameters.Add("@Superior20ID", request.Superior20ID);
                parameters.Add("@Superior21ID", request.Superior21ID);
                parameters.Add("@Superior22ID", request.Superior22ID);
                parameters.Add("@Superior23ID", request.Superior23ID);
                parameters.Add("@Superior24ID", request.Superior24ID);
                parameters.Add("@Superior25ID", request.Superior25ID);
                parameters.Add("@Superior26ID", request.Superior26ID);
                parameters.Add("@Superior27ID", request.Superior27ID);
                parameters.Add("@Superior28ID", request.Superior28ID);
                parameters.Add("@Superior29ID", request.Superior29ID);
                parameters.Add("@Superior30ID", request.Superior30ID);

                parameters.Add("@InsertedBy", request.InsertedBy);
                parameters.Add("@InsertedDate", request.InsertedDate);
                parameters.Add("@ModifiedBy", request.ModifiedBy);
                parameters.Add("@ModifiedDate", request.ModifiedDate);

                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/submit_superior_subordinate");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
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
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/get_singel_superior_subordinate");
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
                parameters.Add("@EfectiveDate", request.EfectiveDate);
                parameters.Add("@EmployeeID", request.Override ?? false);
                parameters.Add("@EmployeeList", string.Join(",",request.EmployeeList));
                parameters.Add("@Action", "Generate");
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/SuperiorSubordinate/Sql/generate_superior_subordinate");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"generate successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to generate", ex.Message);
            }
        }

        #endregion
    }
}

