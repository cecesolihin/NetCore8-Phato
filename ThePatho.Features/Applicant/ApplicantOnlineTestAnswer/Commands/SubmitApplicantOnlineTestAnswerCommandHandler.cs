using MediatR;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class SubmitApplicantOnlineTestAnswerCommandHandler : IRequestHandler<SubmitApplicantOnlineTestAnswerCommand, string>
    {
        private readonly IApplicantOnlineTestAnswerService applicantOnlineTestAnswerService;

        public SubmitApplicantOnlineTestAnswerCommandHandler(IApplicantOnlineTestAnswerService _applicantOnlineTestAnswerService)
        {
            applicantOnlineTestAnswerService = _applicantOnlineTestAnswerService;
        }

        public async Task<string> Handle(SubmitApplicantOnlineTestAnswerCommand request, CancellationToken cancellationToken)
        {
            await applicantOnlineTestAnswerService.SubmitApplicantOnlineTestAnswer(request);
            if (request.Action == "ADD")
            {
                return "Applicant Online Test Answer successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Applicant Online Test Answer successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
