using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.JobClass.Commands;
using ThePatho.Features.Organization.JobClass.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.JobClass.Service
{
    public class JobClassService : IJobClassService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public JobClassService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<JobClassItemDto>> GetJobClass(GetJobClassCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.JobClass)
                    .Select("*")
                    .When(
                         !string.IsNullOrWhiteSpace(request.JobClassCode),
                        q => q.WhereContains("JobClassCode", request.JobClassCode)
                    )
                    .When(
                       !string.IsNullOrWhiteSpace(request.JobClassName),
                        q => q.WhereContains("JobClassName", request.JobClassName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.GradeCode),
                        q => q.WhereContains("GradeCode", request.GradeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.RankCode),
                        q => q.WhereContains("RankCode", request.RankCode)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<JobClassDto>(query);

                var result = new JobClassItemDto
                {
                    DataOfRecords = data.Count(),
                    JobClassList = data.ToList(),
                };
                return new ApiResponse<JobClassItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobClassItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<JobClassItemDto>> GetJobClassByCriteria(GetJobClassByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.JobClass)
                    .Select("*")
                    .When(
                         !string.IsNullOrWhiteSpace(request.JobClassCode),
                        q => q.WhereContains("JobClassCode", request.JobClassCode)
                    )
                    .When(
                       !string.IsNullOrWhiteSpace(request.JobClassName),
                        q => q.WhereContains("JobClassName", request.JobClassName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.GradeCode),
                        q => q.WhereContains("GradeCode", request.GradeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.RankCode),
                        q => q.WhereContains("RankCode", request.RankCode)
                    );

                var data = await db.GetAsync<JobClassDto>(query);

                var result = new JobClassItemDto
                {
                    DataOfRecords = data.Count(),
                    JobClassList = data.ToList(),
                };
                return new ApiResponse<JobClassItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobClassItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitJobClass(SubmitJobClassCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var existsQuery = new Query(TableOrganization.JobClass)
                    .Where("JobClassCode", request.JobClassCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.JobClass).AsInsert(new
                    {
                        JobClassCode = request.JobClassCode,
                        JobClassName = request.JobClassName,
                        GradeCode = request.GradeCode,
                        RankCode = request.RankCode,
                        Remarks = request.Remarks,
                        IsDeleted = false,
                        IsActive = request.IsActive,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.JobClass)
                        .Where("JobClassCode", request.JobClassCode)
                        .AsUpdate(new
                        {
                            JobClassName = request.JobClassName,
                            GradeCode = request.GradeCode,
                            RankCode = request.RankCode,
                            Remarks = request.Remarks,
                            IsDeleted = false,
                            IsActive = request.IsActive,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.JobClassCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.JobClassCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteJobClass(DeleteJobClassCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.JobClassCode))
                {
                    return new ApiResponse<JobClassDto>(
                         HttpStatusCode.BadRequest,
                         "JobClass is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.JobClass)
                                .Where("JobClassCode", request.JobClassCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.JobClassCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.JobClassCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<JobClassDto>> GetSingleJobClass(GetSingleJobClassCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.JobClass)
                    .Select("*")
                    .Where("JobClassCode", request.JobClassCode);

                var data = await db.FirstOrDefaultAsync<JobClassDto>(query);

                if (data == null)
                {
                    return new ApiResponse<JobClassDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<JobClassDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobClassDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion
    }
}
