using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Organization.JobLevel.Commands;
using ThePatho.Features.Organization.JobLevel.DTO;
using ThePatho.Features.Organization.OrgLevel.DTO;
using ThePatho.Features.Organization.OrgStructure.DTO;
using ThePatho.Infrastructure.Persistance;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThePatho.Features.Organization.JobLevel.Service
{
    public class JobLevelService : IJobLevelService
    {
        private readonly DapperContext dapperContext; 

        public JobLevelService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<NewApiResponse<JobLevelItemDto>> GetJobLevel(GetJobLevelCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.JobLevel)
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
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterJobLevelName),
                            q => q.WhereContains("job_level_name", request.FilterJobLevelName)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<JobLevelDto>(query);
                var result = new JobLevelItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    JobLevelList = data.ToList(),
                };
                return new NewApiResponse<JobLevelItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new NewApiResponse<JobLevelItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }

        }

        public async Task<NewApiResponse<JobLevelDto>> GetJobLevelByCriteria(GetJobLevelByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.JobLevel)
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
                        !string.IsNullOrWhiteSpace(request.JobLevelCode),
                        q => q.WhereIn("job_level_code", request.JobLevelCode)
                    );

                var data = await db.FirstOrDefaultAsync<JobLevelDto>(query);
                return new NewApiResponse<JobLevelDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new NewApiResponse<JobLevelDto>(
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

                if (string.IsNullOrWhiteSpace(request.JobLevelCode))
                {
                    throw new ArgumentException("job level code is required.");
                }

                // Check if data exists
                var existsQuery = new Query(TableName.JobLevel)
                    .Where("job_level_code", request.JobLevelCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Kondisi Add (Insert)
                    var insertQuery = new Query(TableName.JobLevel).AsInsert(new
                    {
                        job_level_code = request.JobLevelCode,
                        job_level_name = request.JobLevelName,
                        jort = request.sort,
                        remarks = request.Remarks,
                        is_deleted = false,
                        inserted_by = "system",
                        inserted_date = DateTime.UtcNow,
                        is_active = request.IsActive
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Kondisi Edit (Update)
                    var updateQuery = new Query(TableName.JobLevel)
                     .Where("job_level_code", request.JobLevelCode)
                     .AsUpdate(new
                     {
                         job_level_name = request.JobLevelName,
                         jort = request.sort,
                         remarks = request.Remarks,
                         modified_by = "system",
                         modified_date = DateTime.UtcNow,
                         is_active = request.IsActive
                     });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.JobLevelCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.JobLevelCode}", ex.Message.ToString());
            }
        }
        public async Task<ApiResponse> DeleteJobLevel(DeleteJobLevelCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.JobLevelCode))
                    throw new ArgumentException("Job Level is required.");

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableName.JobLevel)
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

    }
}
