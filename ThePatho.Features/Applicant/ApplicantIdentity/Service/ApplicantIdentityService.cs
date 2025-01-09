
using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.ApplicantIdentity.Commands;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;
using ThePatho.Features.Applicant.ApplicantIdentity.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Service
{
    public class ApplicantIdentityService : IApplicantIdentityService
    {
        private readonly DapperContext dapperContext; 

        public ApplicantIdentityService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<ApplicantIdentityDto>> GetApplicantIdentity(GetApplicantIdentityCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicantIdentity)
                .Select("applicant_no AS ApplicantNo",
                        "identity_code AS IdentityCode",
                        "identity_no AS IdentityNo",
                        "issued_date AS IssuedDate",
                        "expired_date AS ExpiredDate",
                        "file_upload AS FileUpload",
                        "remark AS Remark",
                        "file_full_path AS FileFullPath",
                        "file_name AS FileName",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterIdentityCode),
                        q => q.WhereContains("identity_code", request.FilterIdentityCode)
                 ).When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                        q => q.WhereContains("identity_no", request.FilterApplicantNo)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<ApplicantIdentityDto>(query);
            return results.ToList();

        }

        public async Task<ApplicantIdentityDto> GetApplicantIdentityByCriteria(GetApplicantIdentityByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicantIdentity)
                .Select("applicant_no AS ApplicantNo",
                        "identity_code AS IdentityCode",
                        "identity_no AS IdentityNo",
                        "issued_date AS IssuedDate",
                        "expired_date AS ExpiredDate",
                        "file_upload AS FileUpload",
                        "remark AS Remark",
                        "file_full_path AS FileFullPath",
                        "file_name AS FileName",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                );
            var data = await db.FirstOrDefaultAsync<ApplicantIdentityDto>(query);
            return data;
        }

        public async Task<bool> SubmitApplicantIdentity(SubmitApplicantIdentityCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            // Cek apakah data sudah ada berdasarkan ApplicantNo dan IdentityCode
            var existingRecord = await db.Query(TableName.ApplicantIdentity)
                .Where("applicant_no", request.ApplicantNo)
                .Where("identity_code", request.IdentityCode)
                .FirstOrDefaultAsync();

            if (existingRecord == null)
            {
                // Kondisi ADD (Insert)
                var insertQuery = new Query(TableName.ApplicantIdentity)
                    .AsInsert(new
                    {
                        applicant_no = request.ApplicantNo,
                        identity_code = request.IdentityCode,
                        identity_no = request.IdentityNo,
                        issued_date = request.IssuedDate,
                        expired_date = request.ExpiredDate,
                        //file_upload = request.FileUpload,
                        file_full_path = request.FileFullPath,
                        file_name = request.FileName,
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
                var updateQuery = new Query(TableName.ApplicantIdentity)
                    .Where("applicant_no", request.ApplicantNo)
                    .Where("identity_code", request.IdentityCode)
                    .AsUpdate(new
                    {
                        identity_no = request.IdentityNo,
                        issued_date = request.IssuedDate,
                        expired_date = request.ExpiredDate,
                        //file_upload = request.FileUpload,
                        file_full_path = request.FileFullPath,
                        file_name = request.FileName,
                        remark = request.Remark,
                        modified_by = "system",
                        modified_date = DateTime.UtcNow
                    });

                var updateResult = await db.ExecuteAsync(updateQuery);
                return updateResult > 0;
            }
        }
        public async Task<bool> DeleteApplicantIdentity(DeleteApplicantIdentityCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            var deleteQuery = new Query(TableName.ApplicantIdentity)
                .Where("applicant_no", request.ApplicantNo)
                .Where("identity_code", request.IdentityCode)
                .AsDelete();

            var deleteResult = await db.ExecuteAsync(deleteQuery);
            return deleteResult > 0;
        }
    }
}
