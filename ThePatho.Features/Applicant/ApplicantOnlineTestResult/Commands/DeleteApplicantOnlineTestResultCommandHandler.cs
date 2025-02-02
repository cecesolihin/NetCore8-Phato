using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands
{
    public class DeleteApplicantOnlineTestResultCommandHandler : IRequestHandler<DeleteApplicantOnlineTestResultCommand, ApiResponse>
    {
        private readonly IApplicantOnlineTestResultService ApplicantOnlineTestResultService;

        public DeleteApplicantOnlineTestResultCommandHandler(IApplicantOnlineTestResultService _ApplicantOnlineTestResultService)
        {
            ApplicantOnlineTestResultService = _ApplicantOnlineTestResultService;
        }

        public async Task<ApiResponse> Handle(DeleteApplicantOnlineTestResultCommand request, CancellationToken cancellationToken)
        {
            return await ApplicantOnlineTestResultService.DeleteApplicantOnlineTestResult(request);
        }
    }
}
