using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.PensionType.Commands;
using ThePatho.Features.Organization.PensionType.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.PensionType.Service
{
    public class PensionTypeService : IPensionTypeService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public PensionTypeService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<PensionTypeItemDto>> GetPensionType(GetPensionTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.PensionType)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.PensionTypeCode),
                        q => q.WhereContains("PensionTypeCode", request.PensionTypeName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.PensionTypeName),
                        q => q.WhereContains("PensionTypeName", request.PensionTypeName)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<PensionTypeDto>(query);

                var result = new PensionTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    PensionTypeList = data.ToList(),
                };
                return new ApiResponse<PensionTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<PensionTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<PensionTypeItemDto>> GetPensionTypeByCriteria(GetPensionTypeByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.PensionType)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.PensionTypeCode),
                        q => q.WhereContains("PensionTypeCode", request.PensionTypeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.PensionTypeName),
                        q => q.WhereContains("PensionTypeName", request.PensionTypeName)
                    );

                var data = await db.GetAsync<PensionTypeDto>(query);

                var result = new PensionTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    PensionTypeList = data.ToList(),
                };
                return new ApiResponse<PensionTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<PensionTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitPensionType(SubmitPensionTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var ArgumentException = new List<string>();
                
                var existsQuery = new Query(TableOrganization.PensionType)
                    .Where("PensionTypeCode", request.PensionTypeCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.PensionType).AsInsert(new
                    {
                        PensionTypeCode = request.PensionTypeCode,
                        PensionTypeName = request.PensionTypeName,
                        IsDeleted = false,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.PensionType)
                        .Where("PensionTypeCode", request.PensionTypeCode)
                        .AsUpdate(new
                        {
                            PensionTypeName = request.PensionTypeName,
                            IsDeleted = false,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.PensionTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.PensionTypeCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeletePensionType(DeletePensionTypeCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.PensionTypeCode))
                {
                    return new ApiResponse<PensionTypeDto>(
                         HttpStatusCode.BadRequest,
                         "PensionType is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.PensionType)
                                .Where("PensionTypeCode", request.PensionTypeCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.PensionTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.PensionTypeCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<PensionTypeDto>> GetSinglePensionType(GetSinglePensionTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.PensionType)
                    .Select("*")
                    .Where("PensionTypeCode", request.PensionTypeCode);

                var data = await db.FirstOrDefaultAsync<PensionTypeDto>(query);

                if (data == null)
                {
                    return new ApiResponse<PensionTypeDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<PensionTypeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<PensionTypeDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion
    }
}
