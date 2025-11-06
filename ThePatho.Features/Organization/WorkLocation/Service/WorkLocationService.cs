using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.WorkLocation.Commands;
using ThePatho.Features.Organization.WorkLocation.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.WorkLocation.Service
{
    public class WorkLocationService : IWorkLocationService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public WorkLocationService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<WorkLocationItemDto>> GetWorkLocation(GetWorkLocationCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.WorkLocation)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.WorkLocationName),
                        q => q.WhereContains("WorkLocationCode", request.WorkLocationCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.WorkLocationName),
                        q => q.WhereContains("WorkLocationName", request.WorkLocationName)
                    )
                    .When(
                        request.IsActive.HasValue,
                        q => q.Where("IsActive", request.IsActive.Value)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.TaxLocationCode),
                        q => q.WhereContains("TaxLocationCode", request.TaxLocationCode)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<WorkLocationDto>(query);

                var result = new WorkLocationItemDto
                {
                    DataOfRecords = data.Count(),
                    WorkLocationList = data.ToList(),
                };
                return new ApiResponse<WorkLocationItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<WorkLocationItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<WorkLocationItemDto>> GetWorkLocationByCriteria(GetWorkLocationByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.WorkLocation)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.WorkLocationName),
                        q => q.WhereContains("WorkLocationCode", request.WorkLocationCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.WorkLocationName),
                        q => q.WhereContains("WorkLocationName", request.WorkLocationName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.TaxLocationCode),
                        q => q.WhereContains("TaxLocationCode", request.TaxLocationCode)
                    );

                var data = await db.GetAsync<WorkLocationDto>(query);

                var result = new WorkLocationItemDto
                {
                    DataOfRecords = data.Count(),
                    WorkLocationList = data.ToList(),
                };
                return new ApiResponse<WorkLocationItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<WorkLocationItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitWorkLocation(SubmitWorkLocationCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var existsQuery = new Query(TableOrganization.WorkLocation)
                    .Where("WorkLocationCode", request.WorkLocationCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.WorkLocation).AsInsert(new
                    {
                        WorkLocationCode = request.WorkLocationCode,
                        WorkLocationName = request.WorkLocationName,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow,
                        Latitude = request.Latitude,
                        Longitude = request.Longitude,
                        Radius = request.Radius,
                        IsActive = request.IsActive,
                        TimeZone = request.TimeZone,
                        TaxLocationCode = request.TaxLocationCode,
                        HazardInformation = request.HazardInformation
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.WorkLocation)
                        .Where("WorkLocationCode", request.WorkLocationCode)
                        .AsUpdate(new
                        {
                            WorkLocationName = request.WorkLocationName,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow,
                            Latitude = request.Latitude,
                            Longitude = request.Longitude,
                            Radius = request.Radius,
                            IsActive = request.IsActive,
                            TimeZone = request.TimeZone,
                            TaxLocationCode = request.TaxLocationCode,
                            HazardInformation = request.HazardInformation
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.WorkLocationCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.WorkLocationCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteWorkLocation(DeleteWorkLocationCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.WorkLocationCode))
                {
                    return new ApiResponse<WorkLocationDto>(
                         HttpStatusCode.BadRequest,
                         "WorkLocation is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.WorkLocation)
                                .Where("WorkLocationCode", request.WorkLocationCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.WorkLocationCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.WorkLocationCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<WorkLocationDto>> GetSingleWorkLocation(GetSingleWorkLocationCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.WorkLocation)
                    .Select("*")
                    .Where("WorkLocationCode", request.WorkLocationCode);

                var data = await db.FirstOrDefaultAsync<WorkLocationDto>(query);

                if (data == null)
                {
                    return new ApiResponse<WorkLocationDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<WorkLocationDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<WorkLocationDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion
    }
}
