using Microsoft.EntityFrameworkCore;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Recruitment.RequirementMaster.DTO;
using ThePatho.Features.Recruitment.RequirementMaster.Commands;
using ThePatho.Infrastructure.Persistance;
using SqlKata;

namespace ThePatho.Features.Recruitment.RequirementMaster.Service
{
    public class RequirementMasterService : IRequirementMasterService
    {
        private readonly DapperContext dapperContext; 

        public RequirementMasterService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<RequirementMasterDto>> GetRequirementMaster(GetRequirementMasterCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.RequirementMaster)
                .Select("question_code as QuestionCode",
                        "question_name as QuestionName",
                        "inserted_by as InsertedBy",
                        "inserted_date as InsertedDate",
                        "modified_by as ModifiedBy",
                        "modified_date as ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterQuestionCode),
                    q => q.WhereIn("question_code", request.FilterQuestionCode)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterQuestionName),
                        q => q.WhereContains("question_name", request.FilterQuestionName)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<RequirementMasterDto>(query);
            return results.ToList();

        }

        public async Task<List<RequirementMasterDto>> GetRequirementMasterByCriteria(GetRequirementMasterByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.RequirementMaster)
                 .Select("question_code as QuestionCode",
                        "question_name as QuestionName",
                        "inserted_by as InsertedBy",
                        "inserted_date as InsertedDate",
                        "modified_by as ModifiedBy",
                        "modified_date as ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterQuestionCode),
                    q => q.WhereIn("question_code", request.FilterQuestionCode)
                );
            var data = await db.GetAsync<RequirementMasterDto>(query);
            return data.ToList();
        }
        public async Task<bool> SubmitRequirementMaster(SubmitRequirementMasterCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            // Cek apakah data sudah ada berdasarkan ApplicantNo dan IdentityCode
            var existingRecord = await db.Query(TableName.RequirementMaster)
                .Where("question_code", request.QuestionCode)
                .FirstOrDefaultAsync();

            if (existingRecord == null)
            {
                // Kondisi ADD (Insert)
                var insertQuery = new Query(TableName.RequirementMaster)
                    .AsInsert(new
                    {
                        question_code = request.QuestionCode,
                        question_name = request.QuestionName,
                        inserted_by = "system",
                        inserted_date = DateTime.UtcNow,
                    });

                var insertResult = await db.ExecuteAsync(insertQuery);
                return insertResult > 0;
            }
            else
            {
                // Kondisi EDIT (Update)
                var updateQuery = new Query(TableName.RequirementMaster)
                    .Where("question_code", request.QuestionCode)
                    .AsUpdate(new
                    {
                        question_code = request.QuestionCode,
                        question_name = request.QuestionName,
                        modified_by = "system",
                        modified_date = DateTime.UtcNow
                    });

                var updateResult = await db.ExecuteAsync(updateQuery);
                return updateResult > 0;
            }
        }
        public async Task<bool> DeleteRequirementMaster(DeleteRequirementMasterCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            var deleteQuery = new Query(TableName.RequirementMaster)
                .Where("question_code", request.QuestionCode)
                .AsDelete();

            var deleteResult = await db.ExecuteAsync(deleteQuery);
            return deleteResult > 0;
        }
    }
}
