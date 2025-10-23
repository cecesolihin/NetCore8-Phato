using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.ResignType.Commands;
using ThePatho.Features.Organization.ResignType.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.ResignType.Service
{
    public class ResignTypeService : IResignTypeService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public ResignTypeService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<ResignTypeItemDto>> GetResignType(GetResignTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.ResignType)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.ResignTypeCode),
                        q => q.WhereContains("ResignTypeCode", request.ResignTypeName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.ResignTypeName),
                        q => q.WhereContains("ResignTypeName", request.ResignTypeName)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<ResignTypeDto>(query);

                var result = new ResignTypeItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    ResignTypeList = data.ToList(),
                };
                return new ApiResponse<ResignTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ResignTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<ResignTypeItemDto>> GetResignTypeByCriteria(GetResignTypeByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.ResignType)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.ResignTypeCode),
                        q => q.WhereContains("ResignTypeCode", request.ResignTypeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.ResignTypeName),
                        q => q.WhereContains("ResignTypeName", request.ResignTypeName)
                    );

                var data = await db.GetAsync<ResignTypeDto>(query);

                var result = new ResignTypeItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    ResignTypeList = data.ToList(),
                };
                return new ApiResponse<ResignTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ResignTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitResignType(SubmitResignTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var ArgumentException = new List<string>();
                // Validasi field NOT NULL berdasarkan struktur tabel
                if (string.IsNullOrWhiteSpace(request.ResignTypeCode))
                    ArgumentException.Add("ResignType Code is required.");

                if (string.IsNullOrWhiteSpace(request.ResignTypeName))
                    ArgumentException.Add("ResignType Name is required.");


                if (ArgumentException.Any())
                {
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.ResignTypeCode}", string.Join(", ", ArgumentException.ToArray()));
                }
                // Cek apakah ResignTypeCode sudah exists
                var existsQuery = new Query(TableOrganization.ResignType)
                    .Where("ResignTypeCode", request.ResignTypeCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.ResignType).AsInsert(new
                    {
                        ResignTypeCode = request.ResignTypeCode,
                        ResignTypeName = request.ResignTypeName,
                        IsDeleted = false,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.ResignType)
                        .Where("ResignTypeCode", request.ResignTypeCode)
                        .AsUpdate(new
                        {
                            ResignTypeName = request.ResignTypeName,
                            IsDeleted = false,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.ResignTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.ResignTypeCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteResignType(DeleteResignTypeCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.ResignTypeCode))
                {
                    return new ApiResponse<ResignTypeDto>(
                         HttpStatusCode.BadRequest,
                         "ResignType is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.ResignType)
                                .Where("ResignTypeCode", request.ResignTypeCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.ResignTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.ResignTypeCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<ResignTypeDto>> GetSingleResignType(GetSingleResignTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.ResignType)
                    .Select("*")
                    .Where("ResignTypeCode", request.ResignTypeCode);

                var data = await db.FirstOrDefaultAsync<ResignTypeDto>(query);

                if (data == null)
                {
                    return new ApiResponse<ResignTypeDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<ResignTypeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ResignTypeDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion
    }
}
