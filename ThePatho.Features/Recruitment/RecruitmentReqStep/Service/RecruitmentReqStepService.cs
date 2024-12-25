using Microsoft.EntityFrameworkCore;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;
using ThePatho.Features.Recruitment.RecruitmentReqStep.Commands;
using ThePatho.Infrastructure.Persistance;
using SqlKata;

namespace ThePatho.Features.Recruitment.RecruitmentReqStep.Service
{
    public class RecruitmentReqStepService : IRecruitmentReqStepService
    {
        private readonly DapperContext dapperContext; 

        public RecruitmentReqStepService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<RecruitmentReqStepDto>> GetRecruitmentReqStep(GetRecruitmentReqStepCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.RecruitmentReqStep)
                .Select("recruit_req_step_id as RecruitReqStepId",
                        "request_no as RequestNo",
                        "recruit_step_code as RecruitStepCode",
                        "schedule_date as ScheduleDate",
                        "inserted_by as InsertedBy",
                        "inserted_date as InsertedDate",
                        "modified_by as ModifiedBy",
                        "modified_date as ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterRequestNo),
                    q => q.WhereIn("request_no", request.FilterRequestNo)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterStepCode),
                        q => q.WhereContains("recruit_step_code", request.FilterStepCode)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<RecruitmentReqStepDto>(query);
            return results.ToList();

        }

        public async Task<List<RecruitmentReqStepDto>> GetRecruitmentReqStepByCriteria(GetRecruitmentReqStepByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.RecruitmentReqStep)
                .Select("recruit_req_step_id as RecruitReqStepId",
                        "request_no as RequestNo",
                        "recruit_step_code as RecruitStepCode",
                        "schedule_date as ScheduleDate",
                        "inserted_by as InsertedBy",
                        "inserted_date as InsertedDate",
                        "modified_by as ModifiedBy",
                        "modified_date as ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterRequestNo),
                    q => q.WhereIn("request_no", request.FilterRequestNo)
                );
            var data = await db.GetAsync<RecruitmentReqStepDto>(query);
            return data.ToList();
        }
    }
}
