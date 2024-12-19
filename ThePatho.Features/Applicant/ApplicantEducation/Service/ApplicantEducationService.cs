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
                        "address AS Address",
                        "rt AS RT",
                        "rw AS RW",
                        "sub_district AS SubDistrict",
                        "district AS District",
                        "city AS City",
                        "province AS Province",
                        "country AS Country",
                        "zip_code AS ZipCode",
                        "ownership AS Ownership",
                        "curr_address AS CurrentAddress",
                        "curr_rt AS CurrentRT",
                        "curr_rw AS CurrentRW",
                        "curr_sub_district AS CurrentSubDistrict",
                        "curr_district AS CurrentDistrict",
                        "curr_city AS CurrentCity",
                        "curr_province AS CurrentProvince",
                        "curr_country AS CurrentCountry",
                        "curr_zip_code AS CurrentZipCode",
                        "curr_ownership AS CurrentOwnership",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("ApplicantNo", request.FilterApplicantNo)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterAddress),
                        q => q.WhereContains("Address", request.FilterAddress)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterCity),
                    q => q.WhereIn("city", request.FilterCity)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterProvince),
                        q => q.WhereContains("province", request.FilterProvince)
                 ).When(
                    !string.IsNullOrWhiteSpace(request.FilterCountry),
                        q => q.WhereContains("country", request.FilterCountry)
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
                        "address AS Address",
                        "rt AS RT",
                        "rw AS RW",
                        "sub_district AS SubDistrict",
                        "district AS District",
                        "city AS City",
                        "province AS Province",
                        "country AS Country",
                        "zip_code AS ZipCode",
                        "ownership AS Ownership",
                        "curr_address AS CurrentAddress",
                        "curr_rt AS CurrentRT",
                        "curr_rw AS CurrentRW",
                        "curr_sub_district AS CurrentSubDistrict",
                        "curr_district AS CurrentDistrict",
                        "curr_city AS CurrentCity",
                        "curr_province AS CurrentProvince",
                        "curr_country AS CurrentCountry",
                        "curr_zip_code AS CurrentZipCode",
                        "curr_ownership AS CurrentOwnership",
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
