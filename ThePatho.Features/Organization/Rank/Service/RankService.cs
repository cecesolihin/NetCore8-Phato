using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.Rank.Commands;
using ThePatho.Features.Organization.Rank.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.Rank.Service
{
    public class RankService : IRankService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public RankService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<RankItemDto>> GetRank(GetRankCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Rank)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.RankCode),
                        q => q.WhereContains("RankCode", request.RankCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.RankCode),
                        q => q.WhereContains("RankName", request.RankName)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<RankDto>(query);

                var result = new RankItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    RankList = data.ToList(),
                };
                return new ApiResponse<RankItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<RankItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<RankItemDto>> GetRankByCriteria(GetRankByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Rank)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.RankCode),
                        q => q.WhereContains("RankCode", request.RankCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.RankName),
                        q => q.WhereContains("RankName", request.RankName)
                    );

                var data = await db.GetAsync<RankDto>(query);

                var result = new RankItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    RankList = data.ToList(),
                };
                return new ApiResponse<RankItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<RankItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitRank(SubmitRankCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var ArgumentException = new List<string>();
                // Validasi field NOT NULL berdasarkan struktur tabel
                if (string.IsNullOrWhiteSpace(request.RankCode))
                    ArgumentException.Add("Rank Code is required.");

                if (string.IsNullOrWhiteSpace(request.RankName))
                    ArgumentException.Add("Rank Name is required.");

                // Validasi panjang field sesuai constraint di database
                if (request.RankCode.Length > 128)
                    ArgumentException.Add("Rank Code cannot exceed 128 characters.");

                if (request.RankName.Length > 255)
                    ArgumentException.Add("Rank Name cannot exceed 255 characters.");

                if (request.Remarks != null && request.Remarks.Length > 500)
                    ArgumentException.Add("Remarks cannot exceed 500 characters.");

                // Validasi Order (tinyint range: 0-255)
                if (request.Order < 0 || request.Order > 255)
                    ArgumentException.Add("Order must be between 0 and 255.");

                if (ArgumentException.Any())
                {
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.RankCode}", string.Join(", ", ArgumentException.ToArray()));
                }
                // Cek apakah RankCode sudah exists
                var existsQuery = new Query(TableOrganization.Rank)
                    .Where("RankCode", request.RankCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.Rank).AsInsert(new
                    {
                        RankCode = request.RankCode,
                        RankName = request.RankName,
                        Order = request.Order,
                        Remarks = request.Remarks,
                        IsDeleted = false,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.Rank)
                        .Where("RankCode", request.RankCode)
                        .AsUpdate(new
                        {
                            RankName = request.RankName,
                            Order = request.Order,
                            Remarks = request.Remarks,
                            IsDeleted = false,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.RankCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.RankCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteRank(DeleteRankCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.RankCode))
                {
                    return new ApiResponse<RankDto>(
                         HttpStatusCode.BadRequest,
                         "Rank is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.Rank)
                                .Where("RankCode", request.RankCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.RankCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.RankCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<RankDto>> GetSingleRank(GetSingleRankCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Rank)
                    .Select("*")
                    .Where("RankCode", request.RankCode);

                var data = await db.FirstOrDefaultAsync<RankDto>(query);

                if (data == null)
                {
                    return new ApiResponse<RankDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<RankDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<RankDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion
    }
}
