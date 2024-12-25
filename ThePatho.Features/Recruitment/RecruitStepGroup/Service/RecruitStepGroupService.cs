using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Recruitment.RecruitStep.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroup.Commands;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Service
{
    public class RecruitStepGroupService : IRecruitStepGroupService
    {
        private readonly DapperContext dapperContext;
         
        public RecruitStepGroupService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<RecruitStepGroupDto>> GetRecruitStepGroup(GetRecruitStepGroupCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.RecruitStepGroup)
                .Select("rec_step_group_code as RecruitStepGroupCode",
                        "rec_step_group_name as RecStepGroupName",
                        "inserted_by as InsertedBy",
                        "inserted_date as InsertedDate",
                        "modified_by as ModifiedBy",
                        "modified_date as ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterStepGroupCode),
                    q => q.WhereIn("rec_step_group_code", request.FilterStepGroupCode)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterStepGroupName),
                        q => q.WhereContains("rec_step_group_name", request.FilterStepGroupName)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<RecruitStepGroupDto>(query);
            return results.ToList();
        }

        public async Task<RecruitStepGroupDto> GetRecruitStepGroupByCriteria(GetRecruitStepGroupByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.RecruitStepGroup)
                .Select("rec_step_group_code as RecruitStepGroupCode",
                        "rec_step_group_name as RecStepGroupName",
                        "inserted_by as InsertedBy",
                        "inserted_date as InsertedDate",
                        "modified_by as ModifiedBy",
                        "modified_date as ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterStepGroupCode),
                    q => q.WhereIn("rec_step_group_code", request.FilterStepGroupCode)
                );
            var data = await db.FirstOrDefaultAsync<RecruitStepGroupDto>(query);
            return data;
        }
    }
}
