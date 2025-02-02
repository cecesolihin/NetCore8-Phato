using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitStep.Commands;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.DTO;
using ThePatho.Infrastructure.Persistance;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThePatho.Features.Recruitment.RecruitStepGroupDetail.Service
{
    public class RecruitStepGroupDetailService : IRecruitStepGroupDetailService
    {
        private readonly DapperContext dapperContext; 

        public RecruitStepGroupDetailService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<NewApiResponse<RecruitStepGroupDetailItemDto>> GetRecruitStepGroupDetail(GetRecruitStepGroupDetailCommand request)
        {
            try
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

                var data = await db.GetAsync<RecruitStepGroupDetailDto>(query);
                var result = new RecruitStepGroupDetailItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    RecruitStepGroupDetailList = data.ToList(),
                };
                return new NewApiResponse<RecruitStepGroupDetailItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<RecruitStepGroupDetailItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }

        public async Task<NewApiResponse<RecruitStepGroupDetailItemDto>> GetRecruitStepGroupDetailByCriteria(GetRecruitStepGroupDetailByCriteriaCommand request)
        {
            try
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

                var data = await db.GetAsync<RecruitStepGroupDetailDto>(query);
                var result = new RecruitStepGroupDetailItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    RecruitStepGroupDetailList = data.ToList(),
                };
                return new NewApiResponse<RecruitStepGroupDetailItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<RecruitStepGroupDetailItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }
    }
}
