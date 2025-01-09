using MediatR;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class SubmitApplicantOnlineTestAnswerCommand : IRequest<string>
    {
        public int AppAnswerId { get; set; } // 0 for ADD, non-zero for EDIT
        public int AppResultId { get; set; }
        public string AnswerValue { get; set; }
        public int? WeightPoint { get; set; }
        public string ScoringCode { get; set; }
        public bool? IsCorrect { get; set; }
        public string Action { get; set; }

    }

}
