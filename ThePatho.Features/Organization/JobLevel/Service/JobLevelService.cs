using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevel.Commands;
using ThePatho.Features.Organization.JobLevel.DTO;
using ThePatho.Features.Organization.OrgLevel.DTO;
using ThePatho.Features.Organization.OrgStructure.DTO;
using ThePatho.Infrastructure.Persistance;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ThePatho.Features.Organization.Grade.DTO;

namespace ThePatho.Features.Organization.JobLevel.Service
{
    public class JobLevelService : IJobLevelService
    {
        private readonly DapperContext dapperContext; 

        public JobLevelService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<ApiResponse<JobLevelItemDto>> GetJobLevel(GetJobLevelCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.JobLevel)
                    .Select("*"
                        )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterJobLevelCode),
                        q => q.WhereIn("JobLevelCode", request.FilterJobLevelCode)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterJobLevelName),
                            q => q.WhereContains("FilterJobLevelName", request.FilterJobLevelName)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<JobLevelDto>(query);
                var result = new JobLevelItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    JobLevelList = data.ToList(),
                };
                return new ApiResponse<JobLevelItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobLevelItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }

        }

        public async Task<ApiResponse<JobLevelDto>> GetSingleJobLevel(GetSingleJobLevelCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.JobLevel)
                    .Select(
                            "job_level_code AS JobLevelCode",
                            "job_level_name AS JobLevelName",
                            "jort AS Jort",
                            "remarks AS Remarks",
                            "is_deleted AS IsDeleted",
                            "inserted_by AS InsertedBy",
                            "inserted_date AS InsertedDate",
                            "modified_by AS ModifiedBy",
                            "modified_date AS ModifiedDate",
                            "is_active AS IsActive"
                        )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterJobLevelCode),
                        q => q.WhereIn("job_level_code", request.FilterJobLevelCode)
                    );

                var data = await db.FirstOrDefaultAsync<JobLevelDto>(query);
                if (data == null)
                {
                    return new ApiResponse<JobLevelDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<JobLevelDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobLevelDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }

        }
        public async Task<ApiResponse> SubmitJobLevel(SubmitJobLevelCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var ArgumentException = new List<string>();

                // Validasi field required
                if (string.IsNullOrWhiteSpace(request.JobLevelCode))
                    ArgumentException.Add("Job level code is required.");

                if (string.IsNullOrWhiteSpace(request.JobLevelName))
                    ArgumentException.Add("Job level name is required.");


                if (ArgumentException.Any())
                {
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.JobLevelCode}", string.Join(", ", ArgumentException.ToArray()));
                }

                // Check if data exists
                var existsQuery = new Query(TableOrganization.JobLevel)
                    .Where("job_level_code", request.JobLevelCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.JobLevel).AsInsert(new
                    {
                        JobLevelCode = request.JobLevelCode,
                        JobLevelName = request.JobLevelName,
                        Sort = request.Sort,
                        Remarks = request.Remarks,
                        IsDeleted = false,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow,
                        IsActive = request.IsActive
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.JobLevel)
                        .Where("JobLevelCode", request.JobLevelCode)
                        .AsUpdate(new
                        {
                            JobLevelName = request.JobLevelName,
                            Sort = request.Sort,
                            Remarks = request.Remarks,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow,
                            IsActive = request.IsActive
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.JobLevelCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.JobLevelCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteJobLevel(DeleteJobLevelCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.JobLevelCode))
                {
                    return new ApiResponse<GradeDto>(
                         HttpStatusCode.BadRequest,
                         "Job level is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.JobLevel)
                    .Where("job_level_code", request.JobLevelCode)
                    .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.JobLevelCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.JobLevelCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<JobLevelItemDto>> GetJobLevelByCriteria(GetJobLevelByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.JobLevel)
                    .Select("*"
                        )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterJobLevelCode),
                        q => q.WhereIn("JobLevelCode", request.FilterJobLevelCode)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterJobLevelName),
                            q => q.WhereContains("FilterJobLevelName", request.FilterJobLevelName)
                    );

                var data = await db.GetAsync<JobLevelDto>(query);
                var result = new JobLevelItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    JobLevelList = data.ToList(),
                };
                return new ApiResponse<JobLevelItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<JobLevelItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
    }
}
