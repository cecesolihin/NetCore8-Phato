using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Commands
{
    public class SubmitRecruitmentRequestCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("request_no")]
        public string RequestNo { get; set; }

        [JsonPropertyName("request_date")]
        public DateTime? RequestDate { get; set; }

        [JsonPropertyName("approval_status")]
        public int? ApprovalStatus { get; set; }

        [JsonPropertyName("request_status")]
        public int? RequestStatus { get; set; }

        [JsonPropertyName("approved_date")]
        public DateTime? ApprovedDate { get; set; }

        [JsonPropertyName("request_type")]
        public string RequestType { get; set; }

        [JsonPropertyName("mpp_period_code")]
        public string MppPeriodCode { get; set; }

        [JsonPropertyName("mpp_no")]
        public string MppNo { get; set; }

        [JsonPropertyName("organization_id")]
        public int? OrganizationId { get; set; }

        [JsonPropertyName("position_code")]
        public string PositionCode { get; set; }

        [JsonPropertyName("job_class_code")]
        public string JobClassCode { get; set; }

        [JsonPropertyName("jabatan_id")]
        public int? JabatanId { get; set; }

        [JsonPropertyName("job_level_code")]
        public string JobLevelCode { get; set; }

        [JsonPropertyName("employment_type_code")]
        public string EmploymentTypeCode { get; set; }

        [JsonPropertyName("user_emp_id")]
        public int? UserEmpId { get; set; }

        [JsonPropertyName("vacancy_name")]
        public string VacancyName { get; set; }

        [JsonPropertyName("num_vacancy_all")]
        public int? NumVacancyAll { get; set; }

        [JsonPropertyName("num_vacancy_male")]
        public int? NumVacancyMale { get; set; }

        [JsonPropertyName("num_vacancy_female")]
        public int? NumVacancyFemale { get; set; }

        [JsonPropertyName("expected_join_date")]
        public DateTime? ExpectedJoinDate { get; set; }

        [JsonPropertyName("job_category_id")]
        public int? JobCategoryId { get; set; }

        [JsonPropertyName("job_category_code")]
        public string JobCategoryCode { get; set; }

        [JsonPropertyName("min_salary")]
        public decimal? MinSalary { get; set; }

        [JsonPropertyName("max_salary")]
        public decimal? MaxSalary { get; set; }

        [JsonPropertyName("rec_step_group_code")]
        public string RecStepGroupCode { get; set; }

        [JsonPropertyName("ads_code")]
        public string AdsCode { get; set; }

        [JsonPropertyName("start_advert_date")]
        public DateTime? StartAdvertDate { get; set; }

        [JsonPropertyName("end_advert_date")]
        public DateTime? EndAdvertDate { get; set; }

        [JsonPropertyName("vacancy_type")]
        public string VacancyType { get; set; }

        [JsonPropertyName("close_remark")]
        public string CloseRemark { get; set; }

        [JsonPropertyName("notice_month")]
        public string NoticeMonth { get; set; }

        [JsonPropertyName("vacancy_link")]
        public string VacancyLink { get; set; }

        [JsonPropertyName("qr_link")]
        public string QrLink { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("recruitment_steps")]
        public List<RecruitmentStep> RecruitmentSteps { get; set; }

        [JsonPropertyName("requirements")]
        public List<Requirement> Requirements { get; set; }

    }

     public class RecruitmentStep
    {
        public string RecruitStepCode { get; set; }
        public DateTime ScheduleDate { get; set; }
    }

    public class Requirement
    {
        public string QuestionCode { get; set; }
        public string Answer { get; set; }
    }

}
