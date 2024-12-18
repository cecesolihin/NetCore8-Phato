using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Recruitment.RecruitStep.Commands;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Recruitment.RecruitStepGroupDetail.Service
{
    public class RecruitStepGroupDetailService : IRecruitStepGroupDetailService
    {
        private readonly DapperContext dapperContext;

        public RecruitStepGroupDetailService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<RecruitStepGroupDetailDto>> GetRecruitStepGroupDetail(GetRecruitStepGroupDetailCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.RecruitStepGroupDetail)
                .Select("rec_step_group_detail_id as RecStepGroupDetailId",
                        "rec_step_group_code as RecruitStepGroupCode",
                        "recruit_step_code as RecruitStepCode",
                        "order as Order",
                        "duration as Duration",
                        "process_pass as ProcessPass",
                        "inserted_by as InsertedBy",
                        "inserted_date as InsertedDate",
                        "modified_by as ModifiedBy",
                        "modified_date as ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterStepGroupCode),
                    q => q.WhereIn("rec_step_group_code", request.FilterStepGroupCode)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterStepCode),
                        q => q.WhereContains("recruit_step_code", request.FilterStepCode)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<RecruitStepGroupDetailDto>(query);
            return results.ToList();
        }

        public async Task<List<RecruitStepGroupDetailDto>> GetRecruitStepGroupDetailByCode(GetRecruitStepGroupDetailByCodeCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.RecruitStepGroupDetail)
                .Select("rec_step_group_detail_id as RecStepGroupDetailId",
                        "rec_step_group_code as RecruitStepGroupCode",
                        "recruit_step_code as RecruitStepCode",
                        "order as Order",
                        "duration as Duration",
                        "process_pass as ProcessPass",
                        "inserted_by as InsertedBy",
                        "inserted_date as InsertedDate",
                        "modified_by as ModifiedBy",
                        "modified_date as ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterStepGroupCode),
                    q => q.WhereIn("rec_step_group_code", request.FilterStepGroupCode)
                );

            var results = await db.GetAsync<RecruitStepGroupDetailDto>(query);
            return results.ToList();
        }
    }
}
