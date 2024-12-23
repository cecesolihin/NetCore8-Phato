using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.ApplicantSkill.Commands;
using ThePatho.Features.Applicant.ApplicantSkill.DTO;
using ThePatho.Features.Applicant.ApplicantSkill.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantSkill.Service
{
    public class ApplicantSkillService : IApplicantSkillService
    {
        private readonly DapperContext dapperContext;

        public ApplicantSkillService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<ApplicantSkillDto>> GetApplicantSkill(GetApplicantSkillCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicantSkill)
                .Select("applicant_no as ApplicantNo",
                        "skill_code as SkillCode",
                        "description as Description",
                        "proficiency_code as ProficiencyCode",
                        "taken_date as TakenDate",
                        "exp_date as Expdate",
                        "remarks as Remarks",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterSkill),
                        q => q.WhereContains("skill_code", request.FilterSkill)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<ApplicantSkillDto>(query);
            return results.ToList();

        }

        public async Task<ApplicantSkillDto> GetApplicantSkillByCriteria(GetApplicantSkillByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicantSkill)
                .Select("applicant_no as ApplicantNo",
                        "skill_code as SkillCode",
                        "description as Description",
                        "proficiency_code as ProficiencyCode",
                        "taken_date as TakenDate",
                        "exp_date as Expdate",
                        "remarks as Remarks",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                );
            var data = await db.FirstOrDefaultAsync<ApplicantSkillDto>(query);
            return data;
        }

    }
}
