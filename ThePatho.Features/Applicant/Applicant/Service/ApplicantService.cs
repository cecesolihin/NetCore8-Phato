using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.Applicant.DTO;
using ThePatho.Features.Applicant.Applicant.Commands;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.Applicant.Service
{
    public class ApplicantService : IApplicantService
    {
        private readonly DapperContext dapperContext;

        public ApplicantService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<ApplicantDto>> GetApplicant(GetApplicantCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.Applicant)
                .Select("applicant_no AS ApplicantNo",
                        "first_name AS FirstName",
                        "middle_name AS MiddleName",
                        "last_name AS LastName",
                        "full_name AS FullName",
                        "gender AS Gender",
                        "blacklisted AS Blacklisted",
                        "blacklist_remarks AS BlacklistRemarks",
                        "birth_place AS BirthPlace",
                        "birth_date AS BirthDate",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate",
                        "ormas_membership AS OrmasMembership",
                        "is_rehire AS IsRehire")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterFullname),
                        q => q.WhereContains("FullName", request.FilterFullname)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterGender),
                    q => q.WhereIn("gender", request.FilterGender)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<ApplicantDto>(query);
            return results.ToList();

        }

        public async Task<ApplicantDto> GetApplicantByCriteria(GetApplicantByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.Applicant)
                .Select("applicant_no AS ApplicantNo",
                        "first_name AS FirstName",
                        "middle_name AS MiddleName",
                        "last_name AS LastName",
                        "full_name AS FullName",
                        "gender AS Gender",
                        "blacklisted AS Blacklisted",
                        "blacklist_remarks AS BlacklistRemarks",
                        "birth_place AS BirthPlace",
                        "birth_date AS BirthDate",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate",
                        "ormas_membership AS OrmasMembership",
                        "is_rehire AS IsRehire")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                );
            var data = await db.FirstOrDefaultAsync<ApplicantDto>(query);
            return data;
        }
    }
}
