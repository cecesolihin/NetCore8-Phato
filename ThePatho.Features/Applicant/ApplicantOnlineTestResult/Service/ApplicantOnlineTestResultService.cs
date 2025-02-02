using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.ApplicantEducation.DTO;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.DTO;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Infrastructure.Persistance;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service
{
    public class ApplicantOnlineTestResultService : IApplicantOnlineTestResultService
    {
        private readonly DapperContext dapperContext; 

        public ApplicantOnlineTestResultService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }


        public async Task<NewApiResponse<ApplicantOnlineTestResultItemDto>> GetApplicantOnlineTestResult(GetApplicantOnlineTestResultCommand request)
        {
            try
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

                var data = await db.GetAsync<ApplicantOnlineTestResultDto>(query);
                var result = new ApplicantOnlineTestResultItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    ApplicantOnlineTestResultList = data.ToList(),
                };
                return new NewApiResponse<ApplicantOnlineTestResultItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<ApplicantOnlineTestResultItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }

        public async Task<NewApiResponse<ApplicantOnlineTestResultDto>> GetApplicantOnlineTestResultByCriteria(GetApplicantOnlineTestResultByCriteriaCommand request)
        {
            try
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
                return new NewApiResponse<ApplicantOnlineTestResultDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<ApplicantOnlineTestResultDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }


        }

        public async Task<ApiResponse> SubmitApplicantOnlineTestResult(SubmitApplicantOnlineTestResultCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                if (request.AppResultId == 0)
                {
                    // Kondisi ADD (Insert)
                    var insertQuery = new Query(TableName.ApplicantOnlineTestResult)
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
                 
                }
                else
                {
                    // Kondisi EDIT (Update)
                    var updateQuery = new Query(TableName.ApplicantOnlineTestResult)
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
                   
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.AppResultId.ToString()} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.AppResultId.ToString()}", ex.Message.ToString());
            }

        }
        public async Task<ApiResponse> DeleteApplicantOnlineTestResult(DeleteApplicantOnlineTestResultCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableName.ApplicantOnlineTestResult)
                    .Where("app_result_id", request.AppResultId)
                    .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.AppResultId.ToString()} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.AppResultId.ToString()}", ex.Message.ToString());
            }
        }
    }
}
