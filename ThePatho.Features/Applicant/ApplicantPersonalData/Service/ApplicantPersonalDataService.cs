using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.ApplicantPersonalData.Commands;
using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;
using ThePatho.Features.Applicant.ApplicantPersonalData.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Service
{
    public class ApplicantPersonalDataService : IApplicantPersonalDataService
    {
        private readonly DapperContext dapperContext;

        public ApplicantPersonalDataService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<ApplicantPersonalDataDto>> GetApplicantPersonalData(GetApplicantPersonalDataCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicantPersonalData)
                .Select("applicant_no AS ApplicantNo",
                        "nationality_id AS NationalityId",
                        "religion_id AS ReligionId",
                        "marital_status AS MaritalStatus",
                        "married_date AS MarriedDate",
                        "nick_name AS NickName",
                        "phone AS Phone",
                        "mobile_phone AS MobilePhone",
                        "email AS Email",
                        "blood_type AS BloodType",
                        "height AS Height",
                        "weight AS Weight",
                        "photo AS Photo",
                        "reference AS Reference",
                        "emergency_contact_name AS EmergencyContactName",
                        "emergency_contact AS EmergencyContact",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterNationalId),
                        q => q.WhereContains("nationality_id", request.FilterNationalId)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterReligionId),
                    q => q.WhereIn("religion_id", request.FilterReligionId)
                 ).When(
                    !string.IsNullOrWhiteSpace(request.FilterMaritalStatus),
                        q => q.WhereContains("marital_status", request.FilterMaritalStatus)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<ApplicantPersonalDataDto>(query);
            return results.ToList();

        }

        public async Task<ApplicantPersonalDataDto> GetApplicantPersonalDataByCriteria(GetApplicantPersonalDataByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicantPersonalData)
                .Select("applicant_no AS ApplicantNo",
                        "nationality_id AS NationalityId",
                        "religion_id AS ReligionId",
                        "marital_status AS MaritalStatus",
                        "married_date AS MarriedDate",
                        "nick_name AS NickName",
                        "phone AS Phone",
                        "mobile_phone AS MobilePhone",
                        "email AS Email",
                        "blood_type AS BloodType",
                        "height AS Height",
                        "weight AS Weight",
                        "photo AS Photo",
                        "reference AS Reference",
                        "emergency_contact_name AS EmergencyContactName",
                        "emergency_contact AS EmergencyContact",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                );
            var data = await db.FirstOrDefaultAsync<ApplicantPersonalDataDto>(query);
            return data;
        }
    }
}
