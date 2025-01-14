using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.ApplicationApplicant.Commands;
using ThePatho.Features.Applicant.ApplicationApplicant.DTO;
using ThePatho.Features.Applicant.ApplicationApplicant.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Service
{
    public class ApplicationApplicantService : IApplicationApplicantService
    {
        private readonly DapperContext dapperContext;  

        public ApplicationApplicantService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<ApplicationApplicantDto>> GetApplicationApplicant(GetApplicationApplicantCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicationApplicant)
                .Select("rec_application_id AS RecApplicationId",
                        "applicant_no AS ApplicantNo",
                        "request_no AS RequestNo",
                        "applied_date AS AppliedDate",
                        "ads_code AS AdsCode",
                        "recruitment_fee AS RecruitmentFee",
                        "remarks AS Remarks",
                        "moved_from AS MovedFrom",
                        "date_moved AS DateMoved",
                        "status AS Status",
                        "employee_id AS EmployeeId",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate",
                        "internal_applicant AS InternalApplicant",
                        "email_confirm AS EmailConfirm")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterRequestNo),
                        q => q.WhereContains("request_no", request.FilterRequestNo)
                 ).When(
                    !string.IsNullOrWhiteSpace(request.FilterStatus),
                        q => q.WhereContains("status", request.FilterStatus)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<ApplicationApplicantDto>(query);
            return results.ToList();

        }

        public async Task<ApplicationApplicantDto> GetApplicationApplicantByCriteria(GetApplicationApplicantByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicationApplicant)
                .Select("rec_application_id AS RecApplicationId",
                        "applicant_no AS ApplicantNo",
                        "request_no AS RequestNo",
                        "applied_date AS AppliedDate",
                        "ads_code AS AdsCode",
                        "recruitment_fee AS RecruitmentFee",
                        "remarks AS Remarks",
                        "moved_from AS MovedFrom",
                        "date_moved AS DateMoved",
                        "status AS Status",
                        "employee_id AS EmployeeId",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate",
                        "internal_applicant AS InternalApplicant",
                        "email_confirm AS EmailConfirm")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                );
            var data = await db.FirstOrDefaultAsync<ApplicationApplicantDto>(query);
            return data;
        }
        public async Task<bool> SubmitApplicationApplicant(SubmitApplicationApplicantCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            if (string.IsNullOrWhiteSpace(request.ApplicantNo) || string.IsNullOrWhiteSpace(request.Status))
            {
                throw new ArgumentException("ApplicantNo and Status are required.");
            }

            // Check if data exists
            var existsQuery = new Query(TableName.ApplicationApplicant)
                .Where("rec_application_id", request.RecApplicationId)
                .SelectRaw("COUNT(1)");

            var exists = await db.ExecuteScalarAsync<int>(existsQuery);

            if (exists == 0)
            {
                // Kondisi Insert
                var insertQuery = new Query(TableName.ApplicationApplicant).AsInsert(new
                {
                    applicant_no = request.ApplicantNo,
                    request_no = request.RequestNo,
                    applied_date = request.AppliedDate,
                    ads_code = request.AdsCode,
                    recruitment_fee = request.RecruitmentFee,
                    remarks = request.Remarks,
                    moved_from = request.MovedFrom,
                    date_moved = request.DateMoved,
                    status = request.Status,
                    employee_id = request.EmployeeId,
                    internal_applicant = request.InternalApplicant,
                    email_confirm = request.EmailConfirm,
                    inserted_by =  "system",
                    inserted_date = DateTime.UtcNow,
                });

                var insertResult = await db.ExecuteAsync(insertQuery);
                return insertResult > 0;
            }
            else
            {
                // Kondisi Update
                var updateQuery = new Query(TableName.ApplicationApplicant)
                    .Where("rec_application_id", request.RecApplicationId)
                    .AsUpdate(new
                    {
                        applicant_no = request.ApplicantNo,
                        request_no = request.RequestNo,
                        applied_date = request.AppliedDate,
                        ads_code = request.AdsCode,
                        recruitment_fee = request.RecruitmentFee,
                        remarks = request.Remarks,
                        moved_from = request.MovedFrom,
                        date_moved = request.DateMoved,
                        status = request.Status,
                        employee_id = request.EmployeeId,
                        internal_applicant = request.InternalApplicant,
                        email_confirm = request.EmailConfirm,
                        modified_by = "system",
                        modified_date = DateTime.UtcNow
                    });

                var updateResult = await db.ExecuteAsync(updateQuery);
                return updateResult > 0;
            }
        }
        public async Task<bool> DeleteApplicationApplicant(DeleteApplicationApplicantCommand request)
        {
            if (request.RecApplicationId <= 0)
                throw new ArgumentException("Valid RecApplicationId is required.");

            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            var deleteQuery = new Query(TableName.ApplicationApplicant)
                .Where("rec_application_id", request.RecApplicationId)
                .AsDelete();

            var deleteResult = await db.ExecuteAsync(deleteQuery);
            return deleteResult > 0;
        }
    }
}
