using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.Recruitment.RecruitStep.Commands;
using ThePatho.Features.Recruitment.RecruitStep.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;
using ThePatho.Infrastructure.Persistance;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThePatho.Features.Recruitment.RecruitStep.Service
{
    public class RecruitStepService : IRecruitStepService
    {
        private readonly DapperContext dapperContext;
        public RecruitStepService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<ApiResponse<RecruitStepItemDto>> GetRecruitStep(GetRecruitStepCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.RecruitStep)
                    .Select("recruit_step_code as RecruitStepCode",
                            "recruit_step_name as RecruitStepName",
                            "use_failed_reason as UseFailedReason",
                            "min_score as MinScore",
                            "inserted_by as InsertedBy",
                            "inserted_date as InsertedDate",
                            "modified_by as ModifiedBy",
                            "modified_date as ModifiedDate")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterStepCode),
                        q => q.WhereIn("recruit_step_code", request.FilterStepCode)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterStepName),
                            q => q.WhereContains("recruit_step_name", request.FilterStepName)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<RecruitStepDto>(query);
                var result = new RecruitStepItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    RecruitStepList = data.ToList(),
                };
                return new ApiResponse<RecruitStepItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new ApiResponse<RecruitStepItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }

        public async Task<ApiResponse<RecruitStepDto>> GetRecruitStepByCriteria(GetRecruitStepByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.RecruitStep)
                    .Select("recruit_step_code as RecruitStepCode",
                            "recruit_step_name as RecruitStepName",
                            "use_failed_reason as UseFailedReason",
                            "min_score as MinScore",
                            "inserted_by as InsertedBy",
                            "inserted_date as InsertedDate",
                            "modified_by as ModifiedBy",
                            "modified_date as ModifiedDate")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterStepCode),
                        q => q.WhereIn("recruit_step_code", request.FilterStepCode)
                    );
                var data = await db.FirstOrDefaultAsync<RecruitStepDto>(query);
                return new ApiResponse<RecruitStepDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return new ApiResponse<RecruitStepDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }

        }
        public async Task<ApiResponse> SubmitRecruitStep(SubmitRecruitStepCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                // Cek apakah data sudah ada berdasarkan ApplicantNo dan IdentityCode
                var existingRecord = await db.Query(TableName.RecruitStep)
                    .Where("recruit_step_code", request.RecruitStepCode)
                    .FirstOrDefaultAsync();

                if (existingRecord == null)
                {
                    // Kondisi ADD (Insert)
                    var insertQuery = new Query(TableName.RecruitStep)
                        .AsInsert(new
                        {
                            recruit_step_code = request.RecruitStepCode,
                            recruit_step_name = request.RecruitStepName,
                            use_failed_reason = request.UseFailedReason,
                            min_score = request.MinScore,
                            inserted_by = "system",
                            inserted_date = DateTime.UtcNow,
                        });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                
                }
                else
                {
                    // Kondisi EDIT (Update)
                    var updateQuery = new Query(TableName.RecruitStep)
                        .Where("recruit_step_code", request.RecruitStepCode)
                        .AsUpdate(new
                        {
                            recruit_step_code = request.RecruitStepCode,
                            recruit_step_name = request.RecruitStepName,
                            use_failed_reason = request.UseFailedReason,
                            min_score = request.MinScore,
                            modified_by = "system",
                            modified_date = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                   
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.RecruitStepCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.RecruitStepCode}", ex.Message.ToString());
            }
        }
        public async Task<ApiResponse> DeleteRecruitStep(DeleteRecruitStepCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableName.RecruitStep)
                    .Where("recruit_step_code", request.RecruitStepCode)
                    .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);

                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.RecruitStepCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.RecruitStepCode}", ex.Message.ToString());
            }
        }
    }
}
