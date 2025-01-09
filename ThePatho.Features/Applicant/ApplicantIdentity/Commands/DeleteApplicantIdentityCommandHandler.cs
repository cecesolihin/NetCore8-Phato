using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantIdentity.Service;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class DeleteApplicantIdentityCommandHandler : IRequestHandler<DeleteApplicantIdentityCommand, bool>
    {
        private readonly IApplicantIdentityService applicantIdentityService;

        public DeleteApplicantIdentityCommandHandler(IApplicantIdentityService _applicantIdentityService)
        {
            applicantIdentityService = _applicantIdentityService;
        }

        public async Task<bool> Handle(DeleteApplicantIdentityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await applicantIdentityService.DeleteApplicantIdentity(request);
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
