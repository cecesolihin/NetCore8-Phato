using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Recruitment.RecruitStep.Commands;
using ThePatho.Features.Recruitment.RecruitStep.DTO;
using ThePatho.Infrastructure.Persistance;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ThePatho.Features.Recruitment.RecruitStep.Service
{
    public class RecruitStepService : IRecruitStepService
    {
        private readonly DapperContext dapperContext;

        public RecruitStepService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<RecruitStepDto>> GetRecruitStep(GetRecruitStepCommand request)
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

            var results = await db.GetAsync<RecruitStepDto>(query);
            return results.ToList();

        }

        public async Task<RecruitStepDto> GetRecruitStepByCode(GetRecruitStepByCodeCommand request)
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
            return data;
        }
    }
}
