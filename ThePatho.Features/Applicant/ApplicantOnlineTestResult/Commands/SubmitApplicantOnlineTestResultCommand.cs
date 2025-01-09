using MediatR;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands
{
    public class SubmitApplicantOnlineTestResultCommand : IRequest<string>
    {
        public int AppResultId { get; set; } // 0 for ADD, non-zero for EDIT
        public string OnlineTestCode { get; set; }
        public string ApplicantNo { get; set; }
        public string QuestionnaireCode { get; set; }
        public string QuestionnaireName { get; set; }
        public string AnswerMethod { get; set; }
        public string Remarks { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? SubmitDate { get; set; }
        public string Action { get; set; }

    }

}
