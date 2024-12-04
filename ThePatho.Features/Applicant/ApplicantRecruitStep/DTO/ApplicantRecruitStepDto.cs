
namespace ThePatho.Features.Applicant.ApplicantRecruitStep.DTO
{
    public class ApplicantRecruitStepDto
    {
        public int AppRecStepId { get; set; }
        public int RecApplicationId { get; set; }
        public string RecruitStepCode { get; set; }
        public string Score { get; set; }
        public string Notes { get; set; }
        public string Attachment { get; set; }
        public string Status { get; set; }
        public int? EmpScorer { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public string ReasonCode { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

}
