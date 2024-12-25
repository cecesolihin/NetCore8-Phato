
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
    }
}
