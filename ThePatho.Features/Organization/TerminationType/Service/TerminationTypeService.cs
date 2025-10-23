using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.TerminationType.Commands;
using ThePatho.Features.Organization.TerminationType.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.TerminationType.Service
{
    public class TerminationTypeService : ITerminationTypeService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public TerminationTypeService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<TerminationTypeItemDto>> GetTerminationType(GetTerminationTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.TerminationType)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.TerminationTypeCode),
                        q => q.WhereContains("TerminationTypeCode", request.TerminationTypeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.TerminationTypeName),
                        q => q.WhereContains("TerminationTypeName", request.TerminationTypeName)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<TerminationTypeDto>(query);

                var result = new TerminationTypeItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    TerminationTypeList = data.ToList(),
                };
                return new ApiResponse<TerminationTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TerminationTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<TerminationTypeItemDto>> GetTerminationTypeByCriteria(GetTerminationTypeByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.TerminationType)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.TerminationTypeCode),
                        q => q.WhereContains("TerminationTypeCode", request.TerminationTypeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.TerminationTypeName),
                        q => q.WhereContains("TerminationTypeName", request.TerminationTypeName)
                    );

                var data = await db.GetAsync<TerminationTypeDto>(query);

                var result = new TerminationTypeItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    TerminationTypeList = data.ToList(),
                };
                return new ApiResponse<TerminationTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TerminationTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitTerminationType(SubmitTerminationTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var ArgumentException = new List<string>();
                // Validasi field NOT NULL berdasarkan struktur tabel
                if (string.IsNullOrWhiteSpace(request.TerminationTypeCode))
                    ArgumentException.Add("TerminationType Code is required.");

                if (string.IsNullOrWhiteSpace(request.TerminationTypeName))
                    ArgumentException.Add("TerminationType Name is required.");


                if (ArgumentException.Any())
                {
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.TerminationTypeCode}", string.Join(", ", ArgumentException.ToArray()));
                }
                // Cek apakah TerminationTypeCode sudah exists
                var existsQuery = new Query(TableOrganization.TerminationType)
                    .Where("TerminationTypeCode", request.TerminationTypeCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.TerminationType).AsInsert(new
                    {
                        TerminationTypeCode = request.TerminationTypeCode,
                        TerminationTypeName = request.TerminationTypeName,
                        IsDeleted = false,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.TerminationType)
                        .Where("TerminationTypeCode", request.TerminationTypeCode)
                        .AsUpdate(new
                        {
                            TerminationTypeName = request.TerminationTypeName,
                            IsDeleted = false,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.TerminationTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.TerminationTypeCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteTerminationType(DeleteTerminationTypeCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.TerminationTypeCode))
                {
                    return new ApiResponse<TerminationTypeDto>(
                         HttpStatusCode.BadRequest,
                         "TerminationType is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.TerminationType)
                                .Where("TerminationTypeCode", request.TerminationTypeCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.TerminationTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.TerminationTypeCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<TerminationTypeDto>> GetSingleTerminationType(GetSingleTerminationTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.TerminationType)
                    .Select("*")
                    .Where("TerminationTypeCode", request.TerminationTypeCode);

                var data = await db.FirstOrDefaultAsync<TerminationTypeDto>(query);

                if (data == null)
                {
                    return new ApiResponse<TerminationTypeDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<TerminationTypeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TerminationTypeDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion
    }
}
