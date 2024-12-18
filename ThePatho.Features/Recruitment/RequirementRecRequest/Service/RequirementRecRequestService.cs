using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Recruitment.RequirementRecRequest.Commands;
using ThePatho.Features.Recruitment.RequirementRecRequest.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Recruitment.RequirementRecRequest.Service
{
    public class RequirementRecRequestService : IRequirementRecRequestService
    {
        private readonly DapperContext dapperContext;

        public RequirementRecRequestService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<RequirementRecRequestDto>> GetRequirementRecRequest(GetRequirementRecRequestCommand request)
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

            var results = await db.GetAsync<RequirementRecRequestDto>(query);
            return results.ToList();

        }

        public async Task<List<RequirementRecRequestDto>> GetRequirementRecRequestByCode(GetRequirementRecRequestByCodeCommand request)
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
            return data.ToList();
        }
    }
}
