using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service
{
    public class ApplicantOnlineTestAnswerService : IApplicantOnlineTestAnswerService
    {
        private readonly DapperContext dapperContext; 

        public ApplicantOnlineTestAnswerService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<ApplicantOnlineTestAnswerDto>> GetApplicantOnlineTestAnswer(GetApplicantOnlineTestAnswerCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicantOnlineTestAnswer)
                .Select("app_answer_id AS AppAnswerId",
                        "app_result_id AS AppResultId",
                        "answer_value AS AnswerValue",
                        "weight_point AS WeightPoint",
                        "scoring_code AS ScoringCode",
                        "is_correct AS IsCorrect",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterAppAnswerId),
                    q => q.WhereIn("app_answer_id", request.FilterAppAnswerId)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterAppResultId),
                        q => q.WhereContains("app_result_id", request.FilterAppResultId)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<ApplicantOnlineTestAnswerDto>(query);
            return results.ToList();

        }

        public async Task<ApplicantOnlineTestAnswerDto> GetApplicantOnlineTestAnswerByCriteria(GetApplicantOnlineTestAnswerByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicantOnlineTestAnswer)
                .Select("app_answer_id AS AppAnswerId",
                        "app_result_id AS AppResultId",
                        "answer_value AS AnswerValue",
                        "weight_point AS WeightPoint",
                        "scoring_code AS ScoringCode",
                        "is_correct AS IsCorrect",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterAppResultId),
                    q => q.WhereIn("app_result_id", request.FilterAppResultId)
                );
            var data = await db.FirstOrDefaultAsync<ApplicantOnlineTestAnswerDto>(query);
            return data;
        }

        public async Task<bool> SubmitApplicantOnlineTestAnswer(SubmitApplicantOnlineTestAnswerCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            if (request.AppAnswerId == 0)
            {
                // Kondisi ADD (Insert)
                var insertQuery = new Query(TableName.ApplicantOnlineTestAnswer)
                    .AsInsert(new
                    {
                        app_result_id = request.AppResultId,
                        answer_value = request.AnswerValue,
                        weight_point = request.WeightPoint,
                        scoring_code = request.ScoringCode,
                        is_correct = request.IsCorrect,
                        inserted_by = "system",
                        inserted_date = DateTime.UtcNow
                    });

                var insertResult = await db.ExecuteAsync(insertQuery);
                return insertResult > 0;
            }
            else
            {
                // Kondisi EDIT (Update)
                var updateQuery = new Query(TableName.ApplicantOnlineTestAnswer)
                    .Where("app_answer_id", request.AppAnswerId)
                    .AsUpdate(new
                    {
                        app_result_id = request.AppResultId,
                        answer_value = request.AnswerValue,
                        weight_point = request.WeightPoint,
                        scoring_code = request.ScoringCode,
                        is_correct = request.IsCorrect,
                        modified_by = "system",
                        modified_date = DateTime.UtcNow
                    });

                var updateResult = await db.ExecuteAsync(updateQuery);
                return updateResult > 0;
            }
        }

        public async Task<bool> DeleteApplicantOnlineTestAnswer(DeleteApplicantOnlineTestAnswerCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            var deleteQuery = new Query(TableName.ApplicantOnlineTestAnswer)
                .Where("app_answer_id", request.AppAnswerId)
                .AsDelete();

            var deleteResult = await db.ExecuteAsync(deleteQuery);
            return deleteResult > 0;
        }
    }
}
