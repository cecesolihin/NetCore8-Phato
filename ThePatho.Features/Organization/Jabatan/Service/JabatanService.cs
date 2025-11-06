using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.Jabatan.Commands;
using ThePatho.Features.Organization.Jabatan.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.Jabatan.Service
{
    public class JabatanService : IJabatanService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public JabatanService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<JabatanItemDto>> GetJabatan(GetJabatanCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Jabatan)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.JabatanCode),
                        q => q.WhereContains("JabatanCode", request.JabatanCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.JabatanName),
                        q => q.WhereContains("JabatanName", request.JabatanName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.JabatanDescription),
                        q => q.Where("JabatanDescription", request.JabatanDescription)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<JabatanDto>(query);

                var result = new JabatanItemDto
                {
                    DataOfRecords = data.Count(),
                    JabatanList = data.ToList(),
                };
                return new ApiResponse<JabatanItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JabatanItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<JabatanItemDto>> GetJabatanByCriteria(GetJabatanByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Jabatan)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.JabatanCode),
                        q => q.WhereContains("JabatanCode", request.JabatanCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.JabatanName),
                        q => q.WhereContains("JabatanName", request.JabatanName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.JabatanDescription),
                        q => q.Where("JabatanDescription", request.JabatanDescription)
                    );

                var data = await db.GetAsync<JabatanDto>(query);

                var result = new JabatanItemDto
                {
                    DataOfRecords = data.Count(),
                    JabatanList = data.ToList(),
                };
                return new ApiResponse<JabatanItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JabatanItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitJabatan(SubmitJabatanCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var ArgumentException = new List<string>();
               
                var existsQuery = new Query(TableOrganization.Jabatan)
                    .Where("JabatanCode", request.JabatanCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.Jabatan).AsInsert(new
                    {
                        JabatanCode = request.JabatanCode,
                        JabatanName = request.JabatanName,
                        JabatanDescription = request.JabatanDescription,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.Jabatan)
                        .Where("JabatanCode", request.JabatanCode)
                        .AsUpdate(new
                        {
                            JabatanName = request.JabatanName,
                            JabatanDescription = request.JabatanDescription,
                            IsDeleted = false,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.JabatanCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.JabatanCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteJabatan(DeleteJabatanCommand request)
        {
            try
            {
                if (request.JabatanId == 0)
                {
                    return new ApiResponse<JabatanDto>(
                         HttpStatusCode.BadRequest,
                         "Jabatan is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.Jabatan)
                                .Where("JabatanId", request.JabatanId)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete  successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete ", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<JabatanDto>> GetSingleJabatan(GetSingleJabatanCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Jabatan)
                    .Select("*")
                    .Where("JabatanId", request.JabatanId);

                var data = await db.FirstOrDefaultAsync<JabatanDto>(query);

                if (data == null)
                {
                    return new ApiResponse<JabatanDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<JabatanDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JabatanDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion
    }
}
