using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroup.Commands;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.DTO;
using ThePatho.Infrastructure.Persistance;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Service
{
    public class RecruitStepGroupService : IRecruitStepGroupService
    {
        private readonly DapperContext dapperContext;
         
        public RecruitStepGroupService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<NewApiResponse<RecruitStepGroupItemDto>> GetRecruitStepGroup(GetRecruitStepGroupCommand request)
        {
            try
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

                var data = await db.GetAsync<RecruitStepGroupDto>(query);
                var result = new RecruitStepGroupItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    RecruitStepGroupList = data.ToList(),
                };
                return new NewApiResponse<RecruitStepGroupItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<RecruitStepGroupItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }

        }

        public async Task<NewApiResponse<RecruitStepGroupDto>> GetRecruitStepGroupByCriteria(GetRecruitStepGroupByCriteriaCommand request)
        {
            try
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
                return new NewApiResponse<RecruitStepGroupDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<RecruitStepGroupDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }

        public async Task<ApiResponse> SubmitRecruitStepGroup(SubmitRecruitStepGroupCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            using var transaction = connection.BeginTransaction();

            try
            {
                // Cek apakah data RecruitStepGroup sudah ada berdasarkan rec_step_group_code
                var existingRecord = await db.Query(TableName.RecruitStepGroup)
                    .Where("rec_step_group_code", request.RecStepGroupCode)
                    .FirstOrDefaultAsync();

                if (existingRecord == null)
                {
                    // Kondisi ADD (Insert ke RecruitStepGroup)
                    var insertGroupQuery = new Query(TableName.RecruitStepGroup)
                        .AsInsert(new
                        {
                            rec_step_group_code = request.RecStepGroupCode,
                            rec_step_group_name = request.RecStepGroupName,
                            inserted_by = "system",
                            inserted_date = DateTime.UtcNow,
                        });

                    var insertGroupResult = await db.ExecuteAsync(insertGroupQuery, transaction);
                    if (insertGroupResult <= 0)
                    {
                        transaction.Rollback();
                        return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.RecStepGroupCode}");
                    }
                }
                else
                {
                    // Kondisi EDIT (Update RecruitStepGroup)
                    var updateGroupQuery = new Query(TableName.RecruitStepGroup)
                        .Where("rec_step_group_code", request.RecStepGroupCode)
                        .AsUpdate(new
                        {
                            rec_step_group_name = request.RecStepGroupName,
                            modified_by = "system",
                            modified_date = DateTime.UtcNow,
                        });

                    var updateGroupResult = await db.ExecuteAsync(updateGroupQuery, transaction);
                    if (updateGroupResult <= 0)
                    {
                        transaction.Rollback();
                        return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.RecStepGroupCode}");
                    }

                    // Hapus existing RecruitStepGroupDetail sebelum meng-insert ulang
                    var deleteDetailsQuery = new Query(TableName.RecruitStepGroupDetail)
                        .Where("rec_step_group_code", request.RecStepGroupCode)
                        .AsDelete();

                    var deleteDetailsResult = await db.ExecuteAsync(deleteDetailsQuery, transaction);
                    if (deleteDetailsResult < 0)
                    {
                        transaction.Rollback();
                        return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.RecStepGroupCode}");
                    }
                }

                // Insert RecruitStepGroupDetail
                foreach (var detail in request.RecruitStepGroupDetails)
                {
                    var insertDetailQuery = new Query(TableName.RecruitStepGroupDetail)
                        .AsInsert(new
                        {
                            rec_step_group_code = request.RecStepGroupCode,
                            recruit_step_code = detail.RecruitStepCode,
                            order = detail.Order,
                            duration = detail.Duration,
                            process_pass = detail.ProcessPass,
                            inserted_by = "system",
                            inserted_date = DateTime.UtcNow,
                        });

                    var insertDetailResult = await db.ExecuteAsync(insertDetailQuery, transaction);
                    if (insertDetailResult <= 0)
                    {
                        transaction.Rollback();
                        return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.RecStepGroupCode}");
                    }
                }

                transaction.Commit();
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.RecStepGroupCode} successfully");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.RecStepGroupCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteRecruitStepGroup(DeleteRecruitStepGroupCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            using var transaction = connection.BeginTransaction();

            try
            {
                var deleteDetailsQuery = new Query(TableName.RecruitStepGroupDetail)
                    .Where("rec_step_group_code", request.RecStepGroupCode)
                    .AsDelete();

                var deleteDetailsResult = await db.ExecuteAsync(deleteDetailsQuery, transaction);
                if (deleteDetailsResult < 0)
                {
                    transaction.Rollback();
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.RecStepGroupCode}");
                }

                // Delete RecruitStepGroup
                var deleteGroupQuery = new Query(TableName.RecruitStepGroup)
                    .Where("rec_step_group_code", request.RecStepGroupCode)
                    .AsDelete();

                var deleteGroupResult = await db.ExecuteAsync(deleteGroupQuery, transaction);
                if (deleteGroupResult <= 0)
                {
                    transaction.Rollback();
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.RecStepGroupCode}");
                }

                transaction.Commit();
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.RecStepGroupCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.RecStepGroupCode}", ex.Message.ToString());
            }
        }

    }
}
