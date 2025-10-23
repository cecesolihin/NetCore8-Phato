using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.JobLevelJobClass.Commands;
using ThePatho.Features.Organization.JobLevelJobClass.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.JobLevelJobClass.Service
{
    public class JobLevelJobClassService : IJobLevelJobClassService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public JobLevelJobClassService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<JobLevelJobClassItemDto>> GetJobLevelJobClass(GetJobLevelJobClassCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.JobLevelJobClass)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.JobLevelCode),
                        q => q.WhereContains("JobLevelCode", request.JobLevelCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.JobClassCode),
                        q => q.WhereContains("JobClassCode", request.JobClassCode)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<JobLevelJobClassDto>(query);

                var result = new JobLevelJobClassItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    JobLevelJobClassList = data.ToList(),
                };
                return new ApiResponse<JobLevelJobClassItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobLevelJobClassItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<JobLevelJobClassItemDto>> GetJobLevelJobClassByCriteria(GetJobLevelJobClassByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.JobLevelJobClass)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.JobLevelCode),
                        q => q.WhereContains("JobLevelCode", request.JobLevelCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.JobClassCode),
                        q => q.WhereContains("JobClassCode", request.JobClassCode)
                    );

                var data = await db.GetAsync<JobLevelJobClassDto>(query);

                var result = new JobLevelJobClassItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    JobLevelJobClassList = data.ToList(),
                };
                return new ApiResponse<JobLevelJobClassItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobLevelJobClassItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitJobLevelJobClass(SubmitJobLevelJobClassCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var ArgumentException = new List<string>();

                if (string.IsNullOrWhiteSpace(request.JobLevelCode))
                    ArgumentException.Add("JobLevel Code is required.");

                if (string.IsNullOrWhiteSpace(request.JobClassCode))
                    ArgumentException.Add("JobClass Code is required.");


                if (ArgumentException.Any())
                {
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", string.Join(", ", ArgumentException.ToArray()));
                }

                // Cek apakah relasi JobLevel-JobClass sudah exists
                var existsQuery = new Query(TableOrganization.JobLevelJobClass)
                    .Where("JobLevelCode", request.JobLevelCode)
                    .Where("JobClassCode", request.JobClassCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert relasi baru
                    var insertQuery = new Query(TableOrganization.JobLevelJobClass).AsInsert(new
                    {
                        JobLevelCode = request.JobLevelCode,
                        JobClassCode = request.JobClassCode,
                        IsDeleted = request.IsDeleted,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update relasi yang sudah ada
                    var updateQuery = new Query(TableOrganization.JobLevelJobClass)
                        .Where("JobLevelCode", request.JobLevelCode)
                        .Where("JobClassCode", request.JobClassCode)
                        .AsUpdate(new
                        {
                            IsDeleted = request.IsDeleted,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} JobLevel-JobClass relation successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} JobLevel-JobClass relation", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteJobLevelJobClass(DeleteJobLevelJobClassCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.JobClassCode))
                {
                    return new ApiResponse<JobLevelJobClassDto>(
                         HttpStatusCode.BadRequest,
                         "JobLevelJobClass is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.JobLevelJobClass)
                                .Where("JobLevelCode", request.JobLevelCode)
                                .Where("JobClassCode", request.JobClassCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete  successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete ", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<JobLevelJobClassDto>> GetSingleJobLevelJobClass(GetSingleJobLevelJobClassCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.JobLevelJobClass)
                    .Select("*")
                    .Where("JobLevelCode", request.JobLevelCode)
                    .Where("JobClassCode", request.JobClassCode);

                var data = await db.FirstOrDefaultAsync<JobLevelJobClassDto>(query);

                if (data == null)
                {
                    return new ApiResponse<JobLevelJobClassDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<JobLevelJobClassDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobLevelJobClassDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion
    }
}
