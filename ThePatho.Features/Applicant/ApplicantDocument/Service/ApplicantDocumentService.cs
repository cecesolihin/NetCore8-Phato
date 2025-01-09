using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.ApplicantDocument.Commands;
using ThePatho.Features.Applicant.ApplicantDocument.DTO;
using ThePatho.Features.Applicant.ApplicantDocument.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantDocument.Service
{
    public class ApplicantDocumentService : IApplicantDocumentService
    {
        private readonly DapperContext dapperContext;  

        public ApplicantDocumentService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<ApplicantDocumentDto>> GetApplicantDocument(GetApplicantDocumentCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicantDocument)
                .Select("applicant_no AS ApplicantNo",
                        "document_type_code AS DocumentTypeCode",
                        "file_path AS FilePath",
                        "remark AS Remark",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                 ).When(
                    !string.IsNullOrWhiteSpace(request.FilterDocumetnType),
                        q => q.WhereContains("document_type_code", request.FilterDocumetnType)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<ApplicantDocumentDto>(query);
            return results.ToList();

        }

        public async Task<ApplicantDocumentDto> GetApplicantDocumentByCriteria(GetApplicantDocumentByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicantDocument)
                .Select("applicant_no AS ApplicantNo",
                        "document_type_code AS DocumentTypeCode",
                        "file_path AS FilePath",
                        "remark AS Remark",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                );
            var data = await db.FirstOrDefaultAsync<ApplicantDocumentDto>(query);
            return data;
        }

        public async Task<bool> SubmitApplicantDocument(SubmitApplicantDocumentCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            // Cek apakah data sudah ada berdasarkan ApplicantNo dan DocumentTypeCode
            var existingRecord = await db.Query(TableName.ApplicantDocument)
                .Where("applicant_no", request.ApplicantNo)
                .Where("document_type_code", request.DocumentTypeCode)
                .FirstOrDefaultAsync();

            if (existingRecord == null)
            {
                // Kondisi ADD (Insert)
                var insertQuery = new Query(TableName.ApplicantDocument)
                    .AsInsert(new
                    {
                        applicant_no = request.ApplicantNo,
                        document_type_code = request.DocumentTypeCode,
                        file_path = request.FilePath,
                        remark = request.Remark,
                        inserted_by = "system",
                        inserted_date = DateTime.UtcNow,
                    });

                var insertResult = await db.ExecuteAsync(insertQuery);
                return insertResult > 0;
            }
            else
            {
                // Kondisi EDIT (Update)
                var updateQuery = new Query(TableName.ApplicantDocument)
                    .Where("applicant_no", request.ApplicantNo)
                    .Where("document_type_code", request.DocumentTypeCode)
                    .AsUpdate(new
                    {
                        file_path = request.FilePath,
                        remark = request.Remark,
                        modified_by = "system",
                        modified_date = DateTime.UtcNow
                    });

                var updateResult = await db.ExecuteAsync(updateQuery);
                return updateResult > 0;
            }
        }
        public async Task<bool> DeleteApplicantDocument(DeleteApplicantDocumentCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            var deleteQuery = new Query(TableName.ApplicantDocument)
                .Where("applicant_no", request.ApplicantNo)
                .Where("document_type_code", request.DocumentTypeCode)
                .AsDelete();

            var deleteResult = await db.ExecuteAsync(deleteQuery);
            return deleteResult > 0;
        }
    }
}
