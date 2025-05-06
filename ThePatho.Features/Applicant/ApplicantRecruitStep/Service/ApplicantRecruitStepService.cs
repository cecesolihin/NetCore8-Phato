using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.ApplicantRecruitStep.Commands;
using ThePatho.Features.Applicant.ApplicantRecruitStep.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Service
{
    public class ApplicantRecruitStepService : IApplicantRecruitStepService
    {
        private readonly DapperContext dapperContext; 

        public ApplicantRecruitStepService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<ApiResponse<ApplicantRecruitStepItemDto>> GetApplicantRecruitStep(GetApplicantRecruitStepCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.ApplicantRecruitStep)
                    .Select("app_rec_step_id AS AppRecStepId",
                            "rec_application_id AS RecApplicationId",
                            "recruit_step_code AS RecruitStepCode",
                            "score AS Score",
                            "notes AS Notes",
                            "attachment AS Attachment",
                            "status AS Status",
                            "emp_scorer AS EmpScorer",
                            "schedule_date AS ScheduleDate",
                            "reason_code AS ReasonCode",
                            "inserted_by AS InsertedBy",
                            "inserted_date AS InsertedDate",
                            "modified_by AS ModifiedBy",
                            "modified_date AS ModifiedDate")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterRecaApplicationId),
                        q => q.WhereIn("rec_application_id", request.FilterRecaApplicationId)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterRecruitStepCode),
                            q => q.WhereContains("recruit_step_code", request.FilterRecruitStepCode)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterStatus),
                        q => q.WhereIn("status", request.FilterStatus)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<ApplicantRecruitStepDto>(query);
                var result = new ApplicantRecruitStepItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    ApplicantRecruitStepList = data.ToList(),
                };
                return new ApiResponse<ApplicantRecruitStepItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new ApiResponse<ApplicantRecruitStepItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }

        public async Task<ApiResponse<ApplicantRecruitStepDto>> GetApplicantRecruitStepByCriteria(GetApplicantRecruitStepByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.ApplicantRecruitStep)
                    .Select("app_rec_step_id AS AppRecStepId",
                            "rec_application_id AS RecApplicationId",
                            "recruit_step_code AS RecruitStepCode",
                            "score AS Score",
                            "notes AS Notes",
                            "attachment AS Attachment",
                            "status AS Status",
                            "emp_scorer AS EmpScorer",
                            "schedule_date AS ScheduleDate",
                            "reason_code AS ReasonCode",
                            "inserted_by AS InsertedBy",
                            "inserted_date AS InsertedDate",
                            "modified_by AS ModifiedBy",
                            "modified_date AS ModifiedDate")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                        q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                    );
                var data = await db.FirstOrDefaultAsync<ApplicantRecruitStepDto>(query);
               
                return new ApiResponse<ApplicantRecruitStepDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return new ApiResponse<ApplicantRecruitStepDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }

        public async Task<ApiResponse> SubmitApplicantRecruitStep(SubmitApplicantRecruitStepCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                if (request.RecApplicationId <= 0 || string.IsNullOrWhiteSpace(request.RecruitStepCode))
                {
                    throw new ArgumentException("RecApplicationId and RecruitStepCode are required.");
                }

                // Check if data exists
                var existsQuery = new Query(TableName.ApplicantRecruitStep)
                    .Where("rec_application_id", request.RecApplicationId)
                    .Where("recruit_step_code", request.RecruitStepCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Kondisi ADD (Insert)
                    var insertQuery = new Query(TableName.ApplicantRecruitStep).AsInsert(new
                    {
                        rec_application_id = request.RecApplicationId,
                        recruit_step_code = request.RecruitStepCode,
                        score = request.Score,
                        notes = request.Notes,
                        attachment = request.Attachment,
                        status = request.Status,
                        emp_scorer = request.EmpScorer,
                        schedule_date = request.ScheduleDate,
                        reason_code = request.ReasonCode,
                        inserted_by = "system",
                        inserted_date = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                  
                }
                else
                {
                    // Kondisi EDIT (Update)
                    var updateQuery = new Query(TableName.ApplicantRecruitStep)
                        .Where("rec_application_id", request.RecApplicationId)
                        .Where("recruit_step_code", request.RecruitStepCode)
                        .AsUpdate(new
                        {
                            score = request.Score,
                            notes = request.Notes,
                            attachment = request.Attachment,
                            status = request.Status,
                            emp_scorer = request.EmpScorer,
                            schedule_date = request.ScheduleDate,
                            reason_code = request.ReasonCode,
                            modified_by = "system",
                            modified_date = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                   
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.RecApplicationId.ToString()} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.RecApplicationId.ToString()}", ex.Message.ToString());
            }

        }
        public async Task<ApiResponse> DeleteApplicantRecruitStep(DeleteApplicantRecruitStepCommand request)
        {
            try
            {
                if (request.RecApplicationId <= 0 || string.IsNullOrWhiteSpace(request.RecruitStepCode))
                    throw new ArgumentException("RecApplicationId and RecruitStepCode are required.");

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableName.ApplicantRecruitStep)
                    .Where("rec_application_id", request.RecApplicationId)
                    .Where("recruit_step_code", request.RecruitStepCode)
                    .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.RecApplicationId.ToString()} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.RecApplicationId.ToString()}", ex.Message.ToString());
            }
        }
    }
}
