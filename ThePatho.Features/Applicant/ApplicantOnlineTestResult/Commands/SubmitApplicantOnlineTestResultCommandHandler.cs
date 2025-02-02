using MediatR;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands
{
    public class SubmitApplicantOnlineTestResultCommandHandler : IRequestHandler<SubmitApplicantOnlineTestResultCommand, ApiResponse>
    {
        private readonly IApplicantOnlineTestResultService applicantOnlineTestResultService;

        public SubmitApplicantOnlineTestResultCommandHandler(IApplicantOnlineTestResultService _applicantOnlineTestResultService)
        {
            applicantOnlineTestResultService = _applicantOnlineTestResultService;
        }

        public async Task<ApiResponse> Handle(SubmitApplicantOnlineTestResultCommand request, CancellationToken cancellationToken)
        {
            return await applicantOnlineTestResultService.SubmitApplicantOnlineTestResult(request);
        }
    }
}
