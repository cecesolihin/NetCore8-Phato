
using MediatR;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class SubmitApplicantRecruitStepCommand : IRequest<string>
    {
        public int RecApplicationId { get; set; }
        public string RecruitStepCode { get; set; }
        public string Score { get; set; }
        public string Notes { get; set; }
        public string Attachment { get; set; }
        public string Status { get; set; }
        public int? EmpScorer { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public string ReasonCode { get; set; }
        public string Action { get; set; }

    }

}
