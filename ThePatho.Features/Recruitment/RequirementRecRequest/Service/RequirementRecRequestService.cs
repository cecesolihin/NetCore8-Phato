using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.Recruitment.RequirementRecRequest.Commands;
using ThePatho.Features.Recruitment.RequirementRecRequest.DTO;
using ThePatho.Infrastructure.Persistance;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThePatho.Features.Recruitment.RequirementRecRequest.Service
{
    public class RequirementRecRequestService : IRequirementRecRequestService
    {
        private readonly DapperContext dapperContext;
        public RequirementRecRequestService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<NewApiResponse<RequirementRecRequestItemDto>> GetRequirementRecRequest(GetRequirementRecRequestCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.RequirementRecRequest)
                    .Select("request_no as RequestNo",
                            "question_code as QuestionCode",
                            "answer as Answer",
                            "inserted_by as InsertedBy",
                            "inserted_date as InsertedDate",
                            "modified_by as ModifiedBy",
                            "modified_date as ModifiedDate")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterRequestNo),
                        q => q.WhereIn("request_no", request.FilterRequestNo)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterQuestionCode),
                            q => q.WhereContains("question_code", request.FilterQuestionCode)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterAnswer),
                            q => q.WhereContains("answer", request.FilterAnswer)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<RequirementRecRequestDto>(query);
                var result = new RequirementRecRequestItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    RequirementRecRequestList = data.ToList(),
                };
                return new NewApiResponse<RequirementRecRequestItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<RequirementRecRequestItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }

        }

        public async Task<NewApiResponse<RequirementRecRequestItemDto>> GetRequirementRecRequestByCriteria(GetRequirementRecRequestByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.RequirementRecRequest)
                    .Select("request_no as RequestNo",
                            "question_code as QuestionCode",
                            "answer as Answer",
                            "inserted_by as InsertedBy",
                            "inserted_date as InsertedDate",
                            "modified_by as ModifiedBy",
                            "modified_date as ModifiedDate")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterRequestNo),
                        q => q.WhereIn("request_no", request.FilterRequestNo)
                    );
                var data = await db.GetAsync<RequirementRecRequestDto>(query);
                var result = new RequirementRecRequestItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    RequirementRecRequestList = data.ToList(),
                };
                return new NewApiResponse<RequirementRecRequestItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<RequirementRecRequestItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }
    }
}
