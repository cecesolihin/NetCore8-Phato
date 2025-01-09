using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands
{
    public class DeleteApplicantOnlineTestResultCommandHandler : IRequestHandler<DeleteApplicantOnlineTestResultCommand, bool>
    {
        private readonly IApplicantOnlineTestResultService ApplicantOnlineTestResultService;

        public DeleteApplicantOnlineTestResultCommandHandler(IApplicantOnlineTestResultService _ApplicantOnlineTestResultService)
        {
            ApplicantOnlineTestResultService = _ApplicantOnlineTestResultService;
        }

        public async Task<bool> Handle(DeleteApplicantOnlineTestResultCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await ApplicantOnlineTestResultService.DeleteApplicantOnlineTestResult(request);
                return true;
            }
            catch
            {
                // Log the error here if needed
                return false;
            }
        }
    }
}
