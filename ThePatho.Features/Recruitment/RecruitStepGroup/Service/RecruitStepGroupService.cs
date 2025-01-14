using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
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

        public async Task<bool> SubmitRecruitStepGroup(SubmitRecruitStepGroupCommand request)
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
                        return false;
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
                        return false;
                    }

                    // Hapus existing RecruitStepGroupDetail sebelum meng-insert ulang
                    var deleteDetailsQuery = new Query(TableName.RecruitStepGroupDetail)
                        .Where("rec_step_group_code", request.RecStepGroupCode)
                        .AsDelete();

                    var deleteDetailsResult = await db.ExecuteAsync(deleteDetailsQuery, transaction);
                    if (deleteDetailsResult < 0)
                    {
                        transaction.Rollback();
                        return false;
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
                        return false;
                    }
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task<bool> DeleteRecruitStepGroup(DeleteRecruitStepGroupCommand request)
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
                    return false;
                }

                // Delete RecruitStepGroup
                var deleteGroupQuery = new Query(TableName.RecruitStepGroup)
                    .Where("rec_step_group_code", request.RecStepGroupCode)
                    .AsDelete();

                var deleteGroupResult = await db.ExecuteAsync(deleteGroupQuery, transaction);
                if (deleteGroupResult <= 0)
                {
                    transaction.Rollback();
                    return false;
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

    }
}
