using MediatR;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class SubmitApplicantOnlineTestAnswerCommandHandler : IRequestHandler<SubmitApplicantOnlineTestAnswerCommand, ApiResponse>
    {
        private readonly IApplicantOnlineTestAnswerService applicantOnlineTestAnswerService;

        public SubmitApplicantOnlineTestAnswerCommandHandler(IApplicantOnlineTestAnswerService _applicantOnlineTestAnswerService)
        {
            applicantOnlineTestAnswerService = _applicantOnlineTestAnswerService;
        }

        public async Task<ApiResponse> Handle(SubmitApplicantOnlineTestAnswerCommand request, CancellationToken cancellationToken)
        {
            return await applicantOnlineTestAnswerService.SubmitApplicantOnlineTestAnswer(request);
        }
    }
}
