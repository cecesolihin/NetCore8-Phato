using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgLevel.Commands;
using ThePatho.Features.Organization.OrgLevel.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Organization.OrgLevel.Service
{
    public class OrgLevelService : IOrgLevelService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public OrgLevelService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<OrgLevelItemDto>> GetOrgLevel(GetOrgLevelCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.OrgLevel)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgLevelCode),
                        q => q.WhereContains("OrgLevelCode", request.OrgLevelCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgLevelName),
                        q => q.WhereContains("OrgLevelName", request.OrgLevelName)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<OrgLevelDto>(query);

                var result = new OrgLevelItemDto
                {
                    DataOfRecords = data.Count(),
                    OrgLevelList = data.ToList(),
                };
                return new ApiResponse<OrgLevelItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<OrgLevelItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<OrgLevelItemDto>> GetOrgLevelByCriteria(GetOrgLevelByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.OrgLevel)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgLevelCode),
                        q => q.WhereContains("OrgLevelCode", request.OrgLevelCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgLevelName),
                        q => q.WhereContains("OrgLevelName", request.OrgLevelName)
                    );

                var data = await db.GetAsync<OrgLevelDto>(query);

                var result = new OrgLevelItemDto
                {
                    DataOfRecords = data.Count(),
                    OrgLevelList = data.ToList(),
                };
                return new ApiResponse<OrgLevelItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<OrgLevelItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitOrgLevel(SubmitOrgLevelCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var ArgumentException = new List<string>();
               
                var existsQuery = new Query(TableOrganization.OrgLevel)
                    .Where("OrgLevelCode", request.OrgLevelCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.OrgLevel).AsInsert(new
                    {
                        OrgLevelCode = request.OrgLevelCode,
                        OrgLevelName = request.OrgLevelName,
                        Sort = request.Sort,
                        IsDeleted = false,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.OrgLevel)
                        .Where("OrgLevelCode", request.OrgLevelCode)
                        .AsUpdate(new
                        {
                            OrgLevelName = request.OrgLevelName,
                            Sort = request.Sort,
                            IsDeleted = false,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.OrgLevelCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.OrgLevelCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteOrgLevel(DeleteOrgLevelCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.OrgLevelCode))
                {
                    return new ApiResponse<OrgLevelDto>(
                         HttpStatusCode.BadRequest,
                         "OrgLevel is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.OrgLevel)
                                .Where("OrgLevelCode", request.OrgLevelCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.OrgLevelCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.OrgLevelCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<OrgLevelDto>> GetSingleOrgLevel(GetSingleOrgLevelCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.OrgLevel)
                    .Select("*")
                    .Where("OrgLevelCode", request.OrgLevelCode);

                var data = await db.FirstOrDefaultAsync<OrgLevelDto>(query);

                if (data == null)
                {
                    return new ApiResponse<OrgLevelDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<OrgLevelDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<OrgLevelDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion
    }
}
