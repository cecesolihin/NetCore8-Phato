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

        public async Task<bool> SubmitApplicant(SubmitApplicantCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            // Check if the applicant already exists based on ApplicantNo
            var existingRecord = await db.Query(TableName.Applicant)
                .Where("applicant_no", request.ApplicantNo)
                .FirstOrDefaultAsync();

            if (existingRecord == null)
            {
                // Condition for INSERT (Add)
                var insertQuery = new Query(TableName.Applicant)
                    .AsInsert(new
                    {
                        applicant_no = request.ApplicantNo,
                        first_name = request.FirstName,
                        middle_name = request.MiddleName,
                        last_name = request.LastName,
                        full_name = request.FullName,
                        gender = request.Gender,
                        blacklisted = request.Blacklisted,
                        blacklist_remarks = request.BlacklistRemarks,
                        birth_place = request.BirthPlace,
                        birth_date = request.BirthDate,
                        ormas_membership = request.OrmasMembership,
                        is_rehire = request.IsRehire,
                        hired_as_emp = request.HiredAsEmp,
                        inserted_by = "system",
                        inserted_date = DateTime.UtcNow,
                    });

                var insertResult = await db.ExecuteAsync(insertQuery);
                return insertResult > 0;
            }
            else
            {
                // Condition for UPDATE (Edit)
                var updateQuery = new Query(TableName.Applicant)
                    .Where("applicant_no", request.ApplicantNo)
                    .AsUpdate(new
                    {
                        first_name = request.FirstName,
                        middle_name = request.MiddleName,
                        last_name = request.LastName,
                        full_name = request.FullName,
                        gender = request.Gender,
                        blacklisted = request.Blacklisted,
                        blacklist_remarks = request.BlacklistRemarks,
                        birth_place = request.BirthPlace,
                        birth_date = request.BirthDate,
                        ormas_membership = request.OrmasMembership,
                        is_rehire = request.IsRehire,
                        hired_as_emp = request.HiredAsEmp,
                        modified_by = "system",
                        modified_date = DateTime.UtcNow,
                    });

                var updateResult = await db.ExecuteAsync(updateQuery);
                return updateResult > 0;
            }
        }
        public async Task<bool> DeleteApplicant(DeleteApplicantCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            // Delete the applicant record based on ApplicantNo
            var query = new Query(TableName.Applicant)
                .Where("applicant_no", request.ApplicantNo)
                .AsDelete();

            var affectedRows = await db.ExecuteAsync(query);
            return affectedRows > 0;
        }
    }
}
