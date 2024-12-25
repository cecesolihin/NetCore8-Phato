using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.ApplicantRecruitStep.Commands;
using ThePatho.Features.Applicant.ApplicantRecruitStep.DTO;
using ThePatho.Features.Applicant.ApplicantRecruitStep.Service;
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

        public async Task<List<ApplicantRecruitStepDto>> GetApplicantRecruitStep(GetApplicantRecruitStepCommand request)
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

            var results = await db.GetAsync<ApplicantRecruitStepDto>(query);
            return results.ToList();

        }

        public async Task<ApplicantRecruitStepDto> GetApplicantRecruitStepByCriteria(GetApplicantRecruitStepByCriteriaCommand request)
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
            return data;
        }
    }
}
