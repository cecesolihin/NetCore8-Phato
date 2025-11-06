using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.CostCenter.Commands;
using ThePatho.Features.Organization.CostCenter.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.CostCenter.Service
{
    public class CostCenterService : ICostCenterService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public CostCenterService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<CostCenterItemDto>> GetCostCenter(GetCostCenterCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.CostCenter)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterCostCenterCode),
                        q => q.WhereContains("CostCenterCode", request.FilterCostCenterCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterCostCenterName),
                        q => q.WhereContains("CostCenterName", request.FilterCostCenterName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterCostCenterType),
                        q => q.Where("CostCenterType", request.FilterCostCenterType)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<CostCenterDto>(query);

                var result = new CostCenterItemDto
                {
                    DataOfRecords = data.Count(),
                    CostCenterList = data.ToList(),
                };
                return new ApiResponse<CostCenterItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CostCenterItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<CostCenterItemDto>> GetCostCenterByCriteria(GetCostCenterByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.CostCenter)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterCostCenterCode),
                        q => q.WhereContains("CostCenterCode", request.FilterCostCenterCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterCostCenterName),
                        q => q.WhereContains("CostCenterName", request.FilterCostCenterName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterCostCenterType),
                        q => q.Where("CostCenterType", request.FilterCostCenterType)
                    );

                var data = await db.GetAsync<CostCenterDto>(query);

                var result = new CostCenterItemDto
                {
                    DataOfRecords = data.Count(),
                    CostCenterList = data.ToList(),
                };
                return new ApiResponse<CostCenterItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CostCenterItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitCostCenter(SubmitCostCenterCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var argumentException = new List<string>();
                
                // Cek apakah CostCenterCode sudah exists
                var existsQuery = new Query(TableOrganization.CostCenter)
                    .Where("CostCenterCode", request.CostCenterCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.CostCenter).AsInsert(new
                    {
                        CostCenterCode = request.CostCenterCode,
                        CostCenterName = request.CostCenterName,
                        Sort = request.Sort,
                        CostCenterType = request.CostCenterType,
                        IsDeleted = 0,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.CostCenter)
                        .Where("CostCenterCode", request.CostCenterCode) 
                        .AsUpdate(new
                        {
                            CostCenterName = request.CostCenterName,
                            Sort = request.Sort,
                            CostCenterType = request.CostCenterType,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.CostCenterCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.CostCenterCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteCostCenter(DeleteCostCenterCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.CostCenterCode))
                    return new ApiResponse(HttpStatusCode.NotFound, $"Delete {request.CostCenterCode} CostCenter is required.");
               
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.CostCenter)
                                .Where("CostCenterCode", request.CostCenterCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.CostCenterCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.CostCenterCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<CostCenterDto>> GetSingleCostCenter(GetSingleCostCenterCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.CostCenter)
                    .Select("*")
                    .Where("CostCenterCode", request.CostCenterCode);
                   
                var data = await db.FirstOrDefaultAsync<CostCenterDto>(query);
                return new ApiResponse<CostCenterDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CostCenterDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion
    }
}
