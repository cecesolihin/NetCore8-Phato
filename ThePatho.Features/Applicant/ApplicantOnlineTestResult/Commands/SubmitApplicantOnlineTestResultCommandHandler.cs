using MediatR;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands
{
    public class SubmitApplicantOnlineTestResultCommandHandler : IRequestHandler<SubmitApplicantOnlineTestResultCommand, string>
    {
        private readonly IApplicantOnlineTestResultService applicantOnlineTestResultService;

        public SubmitApplicantOnlineTestResultCommandHandler(IApplicantOnlineTestResultService _applicantOnlineTestResultService)
        {
            applicantOnlineTestResultService = _applicantOnlineTestResultService;
        }

        public async Task<string> Handle(SubmitApplicantOnlineTestResultCommand request, CancellationToken cancellationToken)
        {
            await applicantOnlineTestResultService.SubmitApplicantOnlineTestResult(request);
            if (request.Action == "ADD")
            {
                return "Applican Online Test Result successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Applican Online Test Result successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
