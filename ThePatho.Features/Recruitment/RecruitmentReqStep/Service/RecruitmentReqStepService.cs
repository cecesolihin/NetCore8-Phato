using Microsoft.EntityFrameworkCore;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;
using ThePatho.Features.Recruitment.RecruitmentReqStep.Commands;
using ThePatho.Infrastructure.Persistance;
using SqlKata;
using ThePatho.Provider.ApiResponse;
using System.Net;
using ThePatho.Features.Recruitment.RecruitStep.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThePatho.Features.Recruitment.RecruitmentReqStep.Service
{
    public class RecruitmentReqStepService : IRecruitmentReqStepService
    {
        private readonly DapperContext dapperContext; 

        public RecruitmentReqStepService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<ApiResponse<RecruitmentReqStepItemDto>> GetRecruitmentReqStep(GetRecruitmentReqStepCommand request)
        {
            try
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

                var data = await db.GetAsync<RecruitmentReqStepDto>(query);
                var result = new RecruitmentReqStepItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    RecruitmentReqStepList = data.ToList(),
                };
                return new ApiResponse<RecruitmentReqStepItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new ApiResponse<RecruitmentReqStepItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }


        }

        public async Task<ApiResponse<RecruitmentReqStepItemDto>> GetRecruitmentReqStepByCriteria(GetRecruitmentReqStepByCriteriaCommand request)
        {
            try
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
                var result = new RecruitmentReqStepItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    RecruitmentReqStepList = data.ToList(),
                };
                return new ApiResponse<RecruitmentReqStepItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new ApiResponse<RecruitmentReqStepItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }

        }
    }
}
