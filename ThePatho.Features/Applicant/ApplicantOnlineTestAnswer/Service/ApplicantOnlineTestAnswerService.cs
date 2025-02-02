using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.DTO;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Infrastructure.Persistance;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service
{
    public class ApplicantOnlineTestAnswerService : IApplicantOnlineTestAnswerService
    {
        private readonly DapperContext dapperContext; 

        public ApplicantOnlineTestAnswerService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<NewApiResponse<ApplicantOnlineTestAnswerItemDto>> GetApplicantOnlineTestAnswer(GetApplicantOnlineTestAnswerCommand request)
        {
            try
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

                var data = await db.GetAsync<ApplicantOnlineTestAnswerDto>(query);
                var result = new ApplicantOnlineTestAnswerItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    ApplicantOnlineTestAnswerList = data.ToList(),
                };
                return new NewApiResponse<ApplicantOnlineTestAnswerItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<ApplicantOnlineTestAnswerItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }

        public async Task<NewApiResponse<ApplicantOnlineTestAnswerDto>> GetApplicantOnlineTestAnswerByCriteria(GetApplicantOnlineTestAnswerByCriteriaCommand request)
        {
            try
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
                
                return new NewApiResponse<ApplicantOnlineTestAnswerDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<ApplicantOnlineTestAnswerDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }

        public async Task<ApiResponse> SubmitApplicantOnlineTestAnswer(SubmitApplicantOnlineTestAnswerCommand request)
        {
            try
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
                   
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.AppAnswerId.ToString()} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.AppAnswerId.ToString()}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse> DeleteApplicantOnlineTestAnswer(DeleteApplicantOnlineTestAnswerCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableName.ApplicantOnlineTestAnswer)
                    .Where("app_answer_id", request.AppAnswerId)
                    .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.AppAnswerId.ToString()} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.AppAnswerId.ToString()}", ex.Message.ToString());
            }
        }
    }
}
