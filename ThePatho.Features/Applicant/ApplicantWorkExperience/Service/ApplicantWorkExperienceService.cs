using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.ApplicantWorkExperience.Commands;
using ThePatho.Features.Applicant.ApplicantWorkExperience.DTO;
using ThePatho.Features.Applicant.ApplicantWorkExperience.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Service
{
    public class ApplicantWorkExperienceService : IApplicantWorkExperienceService
    {
        private readonly DapperContext dapperContext; 

        public ApplicantWorkExperienceService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<ApplicantWorkExperienceDto>> GetApplicantWorkExperience(GetApplicantWorkExperienceCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicantWorkExperience)
                .Select("app_work_exp_id AS AppWorkExpId",
                        "applicant_no AS ApplicantNo",
                        "start_working AS StartWorking",
                        "end_working AS EndWorking",
                        "company AS Company",
                        "business_field AS BusinessField",
                        "address AS Address",
                        "city_code AS CityCode",
                        "phone AS Phone",
                        "website AS Website",
                        "resign_reason_code AS ResignReasonCode",
                        "emp_type_code AS EmpTypeCode",
                        "organization AS Organization",
                        "job_level AS JobLevel",
                        "job_desc AS JobDesc",
                        "reference_name AS ReferenceName",
                        "reference_phone AS ReferencePhone",
                        "reference_email AS ReferenceEmail",
                        "remark AS Remark",
                        "is_last_work_experience AS IsLastWorkExperience",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterCompany),
                        q => q.WhereContains("company", request.FilterCompany)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterOrganization),
                    q => q.WhereIn("organization", request.FilterOrganization)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterJobLevel),
                        q => q.WhereContains("job_level", request.FilterJobLevel)
                 ).When(
                    !string.IsNullOrWhiteSpace(request.FilterJobDesc),
                        q => q.WhereContains("job_desc", request.FilterJobDesc)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<ApplicantWorkExperienceDto>(query);
            return results.ToList();

        }

        public async Task<ApplicantWorkExperienceDto> GetApplicantWorkExperienceByCriteria(GetApplicantWorkExperienceByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicantWorkExperience)
                .Select("app_work_exp_id AS AppWorkExpId",
                        "applicant_no AS ApplicantNo",
                        "start_working AS StartWorking",
                        "end_working AS EndWorking",
                        "company AS Company",
                        "business_field AS BusinessField",
                        "address AS Address",
                        "city_code AS CityCode",
                        "phone AS Phone",
                        "website AS Website",
                        "resign_reason_code AS ResignReasonCode",
                        "emp_type_code AS EmpTypeCode",
                        "organization AS Organization",
                        "job_level AS JobLevel",
                        "job_desc AS JobDesc",
                        "reference_name AS ReferenceName",
                        "reference_phone AS ReferencePhone",
                        "reference_email AS ReferenceEmail",
                        "remark AS Remark",
                        "is_last_work_experience AS IsLastWorkExperience",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                );
            var data = await db.FirstOrDefaultAsync<ApplicantWorkExperienceDto>(query);
            return data;
        }
        public async Task<bool> SubmitApplicantWorkExperience(SubmitApplicantWorkExperienceCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            if (string.IsNullOrWhiteSpace(request.ApplicantNo) || request.StartWorking == default)
            {
                throw new ArgumentException("ApplicantNo and StartWorking are required.");
            }

            // Check if data exists
            var existsQuery = new Query(TableName.ApplicantWorkExperience)
                .Where("app_work_exp_id", request.AppWorkExpId)
                .SelectRaw("COUNT(1)");

            var exists = await db.ExecuteScalarAsync<int>(existsQuery);

            if (exists == 0)
            {
                // Kondisi Add (Insert)
                var insertQuery = new Query(TableName.ApplicantWorkExperience).AsInsert(new
                {
                    applicant_no = request.ApplicantNo,
                    start_working = request.StartWorking,
                    end_working = request.EndWorking,
                    company = request.Company,
                    business_field = request.BusinessField,
                    address = request.Address,
                    city_code = request.CityCode,
                    phone = request.Phone,
                    website = request.Website,
                    resign_reason_code = request.ResignReasonCode,
                    emp_type_code = request.EmpTypeCode,
                    organization = request.Organization,
                    job_level = request.JobLevel,
                    job_desc = request.JobDesc,
                    reference_name = request.ReferenceName,
                    reference_phone = request.ReferencePhone,
                    reference_email = request.ReferenceEmail,
                    remark = request.Remark,
                    is_last_work_experience = request.IsLastWorkExperience,
                    inserted_by =  "system",
                    inserted_date = DateTime.UtcNow
                });

                var insertResult = await db.ExecuteAsync(insertQuery);
                return insertResult > 0;
            }
            else
            {
                // Kondisi Edit (Update)
                var updateQuery = new Query(TableName.ApplicantWorkExperience)
                    .Where("app_work_exp_id", request.AppWorkExpId)
                    .AsUpdate(new
                    {
                        applicant_no = request.ApplicantNo,
                        start_working = request.StartWorking,
                        end_working = request.EndWorking,
                        company = request.Company,
                        business_field = request.BusinessField,
                        address = request.Address,
                        city_code = request.CityCode,
                        phone = request.Phone,
                        website = request.Website,
                        resign_reason_code = request.ResignReasonCode,
                        emp_type_code = request.EmpTypeCode,
                        organization = request.Organization,
                        job_level = request.JobLevel,
                        job_desc = request.JobDesc,
                        reference_name = request.ReferenceName,
                        reference_phone = request.ReferencePhone,
                        reference_email = request.ReferenceEmail,
                        remark = request.Remark,
                        is_last_work_experience = request.IsLastWorkExperience,
                        modified_by =  "system",
                        modified_date = DateTime.UtcNow
                    });

                var updateResult = await db.ExecuteAsync(updateQuery);
                return updateResult > 0;
            }
        }
        public async Task<bool> DeleteApplicantWorkExperience(DeleteApplicantWorkExperienceCommand request)
        {
            if (request.AppWorkExpId <= 0)
                throw new ArgumentException("Valid AppWorkExpId is required.");

            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            var deleteQuery = new Query(TableName.ApplicantWorkExperience)
                .Where("app_work_exp_id", request.AppWorkExpId)
                .AsDelete();

            var deleteResult = await db.ExecuteAsync(deleteQuery);
            return deleteResult > 0;
        }
    }
}
