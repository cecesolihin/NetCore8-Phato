using Microsoft.EntityFrameworkCore;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;
using ThePatho.Features.Recruitment.RecruitmentRequest.Commands;
using ThePatho.Infrastructure.Persistance;
using SqlKata;
using System.Data.Entity.Infrastructure;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Service
{
    public class RecruitmentRequestService : IRecruitmentRequestService
    {
        private readonly DapperContext dapperContext; 

        public RecruitmentRequestService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<RecruitmentRequestDto>> GetRecruitmentRequest(GetRecruitmentRequestCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.RecruitmentRequest)
                .Select("request_no AS RequestNo",
                        "request_date AS RequestDate",
                        "approval_status AS ApprovalStatus",
                        "request_status AS RequestStatus",
                        "approved_date AS ApprovedDate",
                        "request_type AS RequestType",
                        "mpp_period_code AS MppPeriodCode",
                        "mpp_no AS MppNo",
                        "organization_id AS OrganizationId",
                        "position_code AS PositionCode",
                        "job_class_code AS JobClassCode",
                        "jabatan_id AS JabatanId",
                        "job_level_code AS JobLevelCode",
                        "employment_type_code AS EmploymentTypeCode",
                        "user_emp_id AS UserEmpId",
                        "vacancy_name AS VacancyName",
                        "num_vacancy_all AS TotalVacancies",
                        "num_vacancy_male AS MaleVacancies",
                        "num_vacancy_female AS FemaleVacancies",
                        "expected_join_date AS ExpectedJoinDate",
                        "job_category_id AS JobCategoryId",
                        "job_category_code AS JobCategoryCode",
                        "min_salary AS MinSalary",
                        "max_salary AS MaxSalary",
                        "rec_step_group_code AS RecStepGroupCode",
                        "ads_code AS AdsCode",
                        "start_advert_date AS StartAdvertDate",
                        "end_advert_date AS EndAdvertDate",
                        "vacancy_type AS VacancyType",
                        "close_remark AS CloseRemark",
                        "notice_month AS NoticeMonth",
                        "vacancy_link AS VacancyLink",
                        "qr_link AS QrLink",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterRequestNo),
                    q => q.WhereIn("request_no", request.FilterRequestNo)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterRequestDate),
                    q => q.WhereContains("request_date", request.FilterRequestDate)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterApprovalStatus),
                    q => q.Where("approval_status", request.FilterApprovalStatus)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterApprovedDate),
                    q => q.WhereContains("approved_date", request.FilterApprovedDate)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterRequestType),
                    q => q.Where("request_type", request.FilterRequestType)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterMppPeriodCode),
                    q => q.Where("mpp_period_code", request.FilterMppPeriodCode)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterMppNo),
                    q => q.Where("mpp_no", request.FilterMppNo)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterOrganizationId),
                    q => q.Where("organization_id", request.FilterOrganizationId)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterPositionCode),
                    q => q.Where("position_code", request.FilterPositionCode)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterJabatanId),
                    q => q.Where("jabatan_id", request.FilterJabatanId)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterJobClassCode),
                    q => q.Where("job_class_code", request.FilterJobClassCode)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterVacancyName),
                    q => q.WhereContains("vacancy_name", request.FilterVacancyName)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<RecruitmentRequestDto>(query);
            return results.ToList();

        }

        public async Task<RecruitmentRequestDto> GetRecruitmentRequestByCriteria(GetRecruitmentRequestByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.RecruitmentRequest)
                .Select("request_no AS RequestNo",
                        "request_date AS RequestDate",
                        "approval_status AS ApprovalStatus",
                        "request_status AS RequestStatus",
                        "approved_date AS ApprovedDate",
                        "request_type AS RequestType",
                        "mpp_period_code AS MppPeriodCode",
                        "mpp_no AS MppNo",
                        "organization_id AS OrganizationId",
                        "position_code AS PositionCode",
                        "job_class_code AS JobClassCode",
                        "jabatan_id AS JabatanId",
                        "job_level_code AS JobLevelCode",
                        "employment_type_code AS EmploymentTypeCode",
                        "user_emp_id AS UserEmpId",
                        "vacancy_name AS VacancyName",
                        "num_vacancy_all AS TotalVacancies",
                        "num_vacancy_male AS MaleVacancies",
                        "num_vacancy_female AS FemaleVacancies",
                        "expected_join_date AS ExpectedJoinDate",
                        "job_category_id AS JobCategoryId",
                        "job_category_code AS JobCategoryCode",
                        "min_salary AS MinSalary",
                        "max_salary AS MaxSalary",
                        "rec_step_group_code AS RecStepGroupCode",
                        "ads_code AS AdsCode",
                        "start_advert_date AS StartAdvertDate",
                        "end_advert_date AS EndAdvertDate",
                        "vacancy_type AS VacancyType",
                        "close_remark AS CloseRemark",
                        "notice_month AS NoticeMonth",
                        "vacancy_link AS VacancyLink",
                        "qr_link AS QrLink",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterRequestNo),
                    q => q.WhereIn("recruit_step_code", request.FilterRequestNo)
                );
            var data = await db.FirstOrDefaultAsync<RecruitmentRequestDto>(query);
            return data;
        }

        public async Task<bool> SubmitRecruitmentRequest(SubmitRecruitmentRequestCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            using var transaction = connection.BeginTransaction();
            try
            {
                // Check if the record exists
                var existingRecord = await db.Query(TableName.RecruitmentRequest)
                    .Where("request_no", request.RequestNo)
                    .FirstOrDefaultAsync();

                if (existingRecord == null)
                {
                    // ADD: Insert into TRRecruitmentRequest
                    var insertRequest = new Query(TableName.RecruitmentRequest).AsInsert(new
                    {
                        request_no = request.RequestNo,
                        request_date = request.RequestDate,
                        approval_status = request.ApprovalStatus,
                        request_status = request.RequestStatus,
                        approved_date = request.ApprovedDate,
                        request_type = request.RequestType,
                        mpp_period_code = request.MppPeriodCode,
                        mpp_no = request.MppNo,
                        organization_id = request.OrganizationId,
                        position_code = request.PositionCode,
                        job_class_code = request.JobClassCode,
                        jabatan_id = request.JabatanId,
                        job_level_code = request.JobLevelCode,
                        employment_type_code = request.EmploymentTypeCode,
                        user_emp_id = request.UserEmpId,
                        vacancy_name = request.VacancyName,
                        num_vacancy_all = request.NumVacancyAll,
                        num_vacancy_male = request.NumVacancyMale,
                        num_vacancy_female = request.NumVacancyFemale,
                        expected_join_date = request.ExpectedJoinDate,
                        job_category_id = request.JobCategoryId,
                        job_category_code = request.JobCategoryCode,
                        min_salary = request.MinSalary,
                        max_salary = request.MaxSalary,
                        rec_step_group_code = request.RecStepGroupCode,
                        ads_code = request.AdsCode,
                        start_advert_date = request.StartAdvertDate,
                        end_advert_date = request.EndAdvertDate,
                        vacancy_type = request.VacancyType,
                        close_remark = request.CloseRemark,
                        notice_month = request.NoticeMonth,
                        vacancy_link = request.VacancyLink,
                        qr_link = request.QrLink,
                        inserted_by = "system",
                        inserted_date = DateTime.UtcNow
                    });

                    await db.ExecuteAsync(insertRequest, transaction);
                }
                else
                {
                    // EDIT: Update TRRecruitmentRequest
                    var updateRequest = new Query(TableName.RecruitmentRequest).Where("request_no", request.RequestNo).AsUpdate(new
                    {
                        request_date = request.RequestDate,
                        approval_status = request.ApprovalStatus,
                        request_status = request.RequestStatus,
                        approved_date = request.ApprovedDate,
                        request_type = request.RequestType,
                        mpp_period_code = request.MppPeriodCode,
                        mpp_no = request.MppNo,
                        organization_id = request.OrganizationId,
                        position_code = request.PositionCode,
                        job_class_code = request.JobClassCode,
                        jabatan_id = request.JabatanId,
                        job_level_code = request.JobLevelCode,
                        employment_type_code = request.EmploymentTypeCode,
                        user_emp_id = request.UserEmpId,
                        vacancy_name = request.VacancyName,
                        num_vacancy_all = request.NumVacancyAll,
                        num_vacancy_male = request.NumVacancyMale,
                        num_vacancy_female = request.NumVacancyFemale,
                        expected_join_date = request.ExpectedJoinDate,
                        job_category_id = request.JobCategoryId,
                        job_category_code = request.JobCategoryCode,
                        min_salary = request.MinSalary,
                        max_salary = request.MaxSalary,
                        rec_step_group_code = request.RecStepGroupCode,
                        ads_code = request.AdsCode,
                        start_advert_date = request.StartAdvertDate,
                        end_advert_date = request.EndAdvertDate,
                        vacancy_type = request.VacancyType,
                        close_remark = request.CloseRemark,
                        notice_month = request.NoticeMonth,
                        vacancy_link = request.VacancyLink,
                        qr_link = request.QrLink,
                        modified_by = "system",
                        modified_date = DateTime.UtcNow
                    });

                    await db.ExecuteAsync(updateRequest, transaction);

                    // Delete existing RecruitmentSteps and Requirements
                    // Delete from TRRequirementRecRequest
                    var deleteQueryRecRequest = new Query(TableName.RequirementRecRequest)
                   .Where("request_no", request.RequestNo)
                   .AsDelete();

                    var deleteResultRecRequest = await db.ExecuteAsync(deleteQueryRecRequest, transaction);

                    // Delete from TRRecruitmentReqStep
                    var deleteQueryReqStep = new Query(TableName.RecruitmentReqStep)
                   .Where("request_no", request.RequestNo)
                   .AsDelete();

                    var deleteResultReqstep = await db.ExecuteAsync(deleteQueryReqStep, transaction);
                }

                // Insert RecruitmentSteps
                foreach (var step in request.RecruitmentSteps)
                {
                    var insertStep = new Query(TableName.RecruitmentReqStep).AsInsert(new
                    {
                        request_no = request.RequestNo,
                        recruit_step_code = step.RecruitStepCode,
                        schedule_date = step.ScheduleDate,
                        inserted_by = "system",
                        inserted_date = DateTime.UtcNow
                    });

                    await db.ExecuteAsync(insertStep, transaction);
                }

                // Insert Requirements
                foreach (var requirement in request.Requirements)
                {
                    var insertRequirement = new Query(TableName.RequirementRecRequest).AsInsert(new
                    {
                        request_no = request.RequestNo,
                        question_code = requirement.QuestionCode,
                        answer = requirement.Answer,
                        inserted_by = "system",
                        inserted_date = DateTime.UtcNow
                    });

                    await db.ExecuteAsync(insertRequirement, transaction);
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task<bool> DeleteRecruitmentRequest(DeleteRecruitmentRequestCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            using var transaction = connection.BeginTransaction();
            try
            {
                // Delete from TRRequirementRecRequest
                var deleteQueryRecRequest = new Query(TableName.RequirementRecRequest)
               .Where("request_no", request.RequestNo)
               .AsDelete();

                var deleteResultRecRequest = await db.ExecuteAsync(deleteQueryRecRequest);

                // Delete from TRRecruitmentReqStep
                var deleteQueryReqStep = new Query(TableName.RecruitmentReqStep)
               .Where("request_no", request.RequestNo)
               .AsDelete();

                var deleteResultReqstep = await db.ExecuteAsync(deleteQueryReqStep);

                // Delete from TRRecruitmentRequest
                var deleteQueryRequest = new Query(TableName.RecruitmentRequest)
              .Where("request_no", request.RequestNo)
              .AsDelete();

                var deleteResultRequest = await db.ExecuteAsync(deleteQueryRequest);

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
