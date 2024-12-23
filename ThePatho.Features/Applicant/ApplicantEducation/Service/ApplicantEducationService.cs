using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.ApplicantEducation.Commands;
using ThePatho.Features.Applicant.ApplicantEducation.DTO;
using ThePatho.Features.Applicant.ApplicantEducation.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantEducation.Service
{
    public class ApplicantEducationService : IApplicantEducationService
    {
        private readonly DapperContext dapperContext;

        public ApplicantEducationService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<ApplicantEducationDto>> GetApplicantEducation(GetApplicantEducationCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicantEducation)
                .Select("applicant_no AS ApplicantNo",
                        "edu_level_code AS EduLevelCode",
                        "major_code AS MajorCode",
                        "faculty AS Faculty",
                        "start_year AS StartYear",
                        "end_year AS EndYear",
                        "gpa AS GPA",
                        "max_gpa AS MaxGPA",
                        "institution AS Institution",
                        "address AS Address",
                        "city_code AS CityCode",
                        "grad_type_code AS GradTypeCode",
                        "certificate_no AS CertificateNo",
                        "certificate_date AS CertificateDate",
                        "remark AS Remark",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterEdulLevel),
                        q => q.WhereContains("edu_level_code", request.FilterEdulLevel)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterMajor),
                    q => q.WhereIn("major_code", request.FilterMajor)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterFaculty),
                        q => q.WhereContains("faculty", request.FilterFaculty)
                 ).When(
                    !string.IsNullOrWhiteSpace(request.FilterInstitution),
                        q => q.WhereContains("institution", request.FilterInstitution)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<ApplicantEducationDto>(query);
            return results.ToList();

        }

        public async Task<ApplicantEducationDto> GetApplicantEducationByCriteria(GetApplicantEducationByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicantEducation)
                .Select("applicant_no AS ApplicantNo",
                        "edu_level_code AS EduLevelCode",
                        "major_code AS MajorCode",
                        "faculty AS Faculty",
                        "start_year AS StartYear",
                        "end_year AS EndYear",
                        "gpa AS GPA",
                        "max_gpa AS MaxGPA",
                        "institution AS Institution",
                        "address AS Address",
                        "city_code AS CityCode",
                        "grad_type_code AS GradTypeCode",
                        "certificate_no AS CertificateNo",
                        "certificate_date AS CertificateDate",
                        "remark AS Remark",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                );
            var data = await db.FirstOrDefaultAsync<ApplicantEducationDto>(query);
            return data;
        }
    }
}
