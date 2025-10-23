using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.WorkLocationGroup.Commands;
using ThePatho.Features.Organization.WorkLocationGroup.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.WorkLocationGroup.Service
{
    public class WorkLocationGroupService : IWorkLocationGroupService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public WorkLocationGroupService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<WorkLocationGroupItemDto>> GetWorkLocationGroup(GetWorkLocationGroupCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.WorkLocationGroup)
                    .Select("*")
                    .When(
                        request.FilterGroupId.HasValue && request.FilterGroupId > 0,
                        q => q.Where("GroupId", request.FilterGroupId.Value)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterWorkLocationCode),
                        q => q.WhereContains("WorkLocationCode", request.FilterWorkLocationCode)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<WorkLocationGroupDto>(query);

                var result = new WorkLocationGroupItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    WorkLocationGroupList = data.ToList(),
                };
                return new ApiResponse<WorkLocationGroupItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<WorkLocationGroupItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<WorkLocationGroupItemDto>> GetWorkLocationGroupByCriteria(GetWorkLocationGroupByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.WorkLocationGroup)
                    .Select("*")
                    .When(
                        request.FilterGroupId.HasValue && request.FilterGroupId > 0,
                        q => q.Where("GroupId", request.FilterGroupId.Value)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterWorkLocationCode),
                        q => q.WhereContains("WorkLocationCode", request.FilterWorkLocationCode)
                    );

                var data = await db.GetAsync<WorkLocationGroupDto>(query);

                var result = new WorkLocationGroupItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    WorkLocationGroupList = data.ToList(),
                };
                return new ApiResponse<WorkLocationGroupItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<WorkLocationGroupItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitWorkLocationGroup(SubmitWorkLocationGroupCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var ArgumentException = new List<string>();

                // Validasi field NOT NULL berdasarkan struktur tabel TOGDWorkLocationGroup
                if (request.GroupId <= 0)
                    ArgumentException.Add("Group ID is required and must be greater than 0.");

                // Validasi panjang field sesuai constraint di database
                if (!string.IsNullOrWhiteSpace(request.WorkLocationCode) && request.WorkLocationCode.Length > 128)
                    ArgumentException.Add("WorkLocation Code cannot exceed 128 characters.");

                if (ArgumentException.Any())
                {
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", string.Join(", ", ArgumentException.ToArray()));
                }

                // Untuk insert/update WorkLocationGroupDetail, kita gunakan GroupDetailId
                if (request.GroupDetailId == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.WorkLocationGroupDetail).AsInsert(new
                    {
                        GroupId = request.GroupId,
                        WorkLocationCode = request.WorkLocationCode,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update - cek apakah data exists
                    var existsQuery = new Query(TableOrganization.WorkLocationGroupDetail)
                        .Where("GroupDetailId", request.GroupDetailId)
                        .SelectRaw("COUNT(1)");

                    var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                    if (exists == 0)
                    {
                        return new ApiResponse(HttpStatusCode.NotFound, $"WorkLocationGroup Detail with ID {request.GroupDetailId} not found.");
                    }

                    // Update
                    var updateQuery = new Query(TableOrganization.WorkLocationGroupDetail)
                        .Where("GroupDetailId", request.GroupDetailId)
                        .AsUpdate(new
                        {
                            GroupId = request.GroupId,
                            WorkLocationCode = request.WorkLocationCode,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} WorkLocationGroup Detail successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} WorkLocationGroup Detail", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteWorkLocationGroup(DeleteWorkLocationGroupCommand request)
        {
            try
            {
                if (request.GroupDetailId == 0)
                {
                    return new ApiResponse<WorkLocationGroupDto>(
                         HttpStatusCode.BadRequest,
                         "WorkLocationGroup is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.WorkLocationGroup)
                                .Where("GroupDetailId", request.GroupDetailId)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete ", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<WorkLocationGroupDto>> GetSingleWorkLocationGroup(GetSingleWorkLocationGroupCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.WorkLocationGroup)
                    .Select("*")
                    .Where("GroupDetailId", request.GroupDetailId);

                var data = await db.FirstOrDefaultAsync<WorkLocationGroupDto>(query);

                if (data == null)
                {
                    return new ApiResponse<WorkLocationGroupDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<WorkLocationGroupDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<WorkLocationGroupDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion
    }
}
