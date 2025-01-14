using MediatR;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Commands
{
    public class SubmitRecruitmentRequestCommand : IRequest<string>
    {
        public string RequestNo { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? ApprovalStatus { get; set; }
        public int? RequestStatus { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string RequestType { get; set; }
        public string MppPeriodCode { get; set; }
        public string MppNo { get; set; }
        public int? OrganizationId { get; set; }
        public string PositionCode { get; set; }
        public string JobClassCode { get; set; }
        public int? JabatanId { get; set; }
        public string JobLevelCode { get; set; }
        public string EmploymentTypeCode { get; set; }
        public int? UserEmpId { get; set; }
        public string VacancyName { get; set; }
        public int? NumVacancyAll { get; set; }
        public int? NumVacancyMale { get; set; }
        public int? NumVacancyFemale { get; set; }
        public DateTime? ExpectedJoinDate { get; set; }
        public int? JobCategoryId { get; set; }
        public string JobCategoryCode { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
        public string RecStepGroupCode { get; set; }
        public string AdsCode { get; set; }
        public DateTime? StartAdvertDate { get; set; }
        public DateTime? EndAdvertDate { get; set; }
        public string VacancyType { get; set; }
        public string CloseRemark { get; set; }
        public string NoticeMonth { get; set; }
        public string VacancyLink { get; set; }
        public string QrLink { get; set; }
        public string Action { get; set; }
        public List<RecruitmentStep> RecruitmentSteps { get; set; }
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
