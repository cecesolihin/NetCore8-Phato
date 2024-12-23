using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.DTO;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service
{
    public class ApplicantOnlineTestResultService : IApplicantOnlineTestResultService
    {
        private readonly DapperContext dapperContext;

        public ApplicantOnlineTestResultService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<ApplicantOnlineTestResultDto>> GetApplicantOnlineTestResult(GetApplicantOnlineTestResultCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicantOnlineTestResult)
                .Select("app_result_id AS AppResultId",
                        "online_test_code AS OnlineTestCode",
                        "applicant_no AS ApplicantNo",
                        "questionnaire_code AS QuestionnaireCode",
                        "questionnaire_name AS QuestionnaireName",
                        "answer_method AS AnswerMethod",
                        "remarks AS Remarks",
                        "start_date AS StartDate",
                        "end_date AS EndDate",
                        "submit_date AS SubmitDate",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterQuestion),
                        q => q.WhereContains("questionnaire_code", request.FilterQuestion)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<ApplicantOnlineTestResultDto>(query);
            return results.ToList();

        }

        public async Task<ApplicantOnlineTestResultDto> GetApplicantOnlineTestResultByCriteria(GetApplicantOnlineTestResultByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicantOnlineTestResult)
               .Select("app_result_id AS AppResultId",
                        "online_test_code AS OnlineTestCode",
                        "applicant_no AS ApplicantNo",
                        "questionnaire_code AS QuestionnaireCode",
                        "questionnaire_name AS QuestionnaireName",
                        "answer_method AS AnswerMethod",
                        "remarks AS Remarks",
                        "start_date AS StartDate",
                        "end_date AS EndDate",
                        "submit_date AS SubmitDate",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                );
            var data = await db.FirstOrDefaultAsync<ApplicantOnlineTestResultDto>(query);
            return data;
        }
    }
}
