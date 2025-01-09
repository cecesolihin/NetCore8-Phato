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

        public async Task<bool> SubmitApplicantOnlineTestResult(SubmitApplicantOnlineTestResultCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            if (request.AppResultId == 0)
            {
                // Kondisi ADD (Insert)
                var insertQuery = new Query("TRApplicantOnlineTestResult")
                    .AsInsert(new
                    {
                        online_test_code = request.OnlineTestCode,
                        applicant_no = request.ApplicantNo,
                        questionnaire_code = request.QuestionnaireCode,
                        questionnaire_name = request.QuestionnaireName,
                        answer_method = request.AnswerMethod,
                        remarks = request.Remarks,
                        start_date = request.StartDate,
                        end_date = request.EndDate,
                        submit_date = request.SubmitDate,
                        inserted_by = "system",
                        inserted_date = DateTime.UtcNow
                    });

                var insertResult = await db.ExecuteAsync(insertQuery);
                return insertResult > 0;
            }
            else
            {
                // Kondisi EDIT (Update)
                var updateQuery = new Query("TRApplicantOnlineTestResult")
                    .Where("app_result_id", request.AppResultId)
                    .AsUpdate(new
                    {
                        online_test_code = request.OnlineTestCode,
                        applicant_no = request.ApplicantNo,
                        questionnaire_code = request.QuestionnaireCode,
                        questionnaire_name = request.QuestionnaireName,
                        answer_method = request.AnswerMethod,
                        remarks = request.Remarks,
                        start_date = request.StartDate,
                        end_date = request.EndDate,
                        submit_date = request.SubmitDate,
                        modified_by = "system",
                        modified_date = DateTime.UtcNow
                    });

                var updateResult = await db.ExecuteAsync(updateQuery);
                return updateResult > 0;
            }
        }
        public async Task<bool> DeleteApplicantOnlineTestResult(DeleteApplicantOnlineTestResultCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            var deleteQuery = new Query("TRApplicantOnlineTestResult")
                .Where("app_result_id", request.AppResultId)
                .AsDelete();

            var deleteResult = await db.ExecuteAsync(deleteQuery);
            return deleteResult > 0;
        }
    }
}
