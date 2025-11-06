using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.MutationType.Commands;
using ThePatho.Features.Organization.MutationType.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.MutationType.Service
{
    public class MutationTypeService : IMutationTypeService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public MutationTypeService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<MutationTypeItemDto>> GetMutationType(GetMutationTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.MutationType)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.MutationTypeCode),
                        q => q.WhereContains("MutationTypeCode", request.MutationTypeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.MutationTypeName),
                        q => q.WhereContains("MutationTypeName", request.MutationTypeName)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<MutationTypeDto>(query);

                var result = new MutationTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    MutationTypeList = data.ToList(),
                };
                return new ApiResponse<MutationTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<MutationTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<MutationTypeItemDto>> GetMutationTypeByCriteria(GetMutationTypeByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.MutationType)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.MutationTypeCode),
                        q => q.WhereContains("MutationTypeCode", request.MutationTypeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.MutationTypeName),
                        q => q.WhereContains("MutationTypeName", request.MutationTypeName)
                    );

                var data = await db.GetAsync<MutationTypeDto>(query);

                var result = new MutationTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    MutationTypeList = data.ToList(),
                };
                return new ApiResponse<MutationTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<MutationTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitMutationType(SubmitMutationTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var ArgumentException = new List<string>();
                
                var existsQuery = new Query(TableOrganization.MutationType)
                    .Where("MutationTypeCode", request.MutationTypeCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.MutationType).AsInsert(new
                    {
                        MutationTypeCode = request.MutationTypeCode,
                        MutationTypeName = request.MutationTypeName,
                        IsDeleted = false,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.MutationType)
                        .Where("MutationTypeCode", request.MutationTypeCode)
                        .AsUpdate(new
                        {
                            MutationTypeName = request.MutationTypeName,
                            IsDeleted = false,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.MutationTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.MutationTypeCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteMutationType(DeleteMutationTypeCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.MutationTypeCode))
                {
                    return new ApiResponse<MutationTypeDto>(
                         HttpStatusCode.BadRequest,
                         "MutationType is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.MutationType)
                                .Where("MutationTypeCode", request.MutationTypeCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.MutationTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.MutationTypeCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<MutationTypeDto>> GetSingleMutationType(GetSingleMutationTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.MutationType)
                    .Select("*")
                    .Where("MutationTypeCode", request.MutationTypeCode);

                var data = await db.FirstOrDefaultAsync<MutationTypeDto>(query);

                if (data == null)
                {
                    return new ApiResponse<MutationTypeDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<MutationTypeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<MutationTypeDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion
    }
}
