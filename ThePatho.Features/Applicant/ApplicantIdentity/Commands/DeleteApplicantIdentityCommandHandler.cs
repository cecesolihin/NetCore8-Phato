using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantIdentity.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class DeleteApplicantIdentityCommandHandler : IRequestHandler<DeleteApplicantIdentityCommand, ApiResponse>
    {
        private readonly IApplicantIdentityService applicantIdentityService;

        public DeleteApplicantIdentityCommandHandler(IApplicantIdentityService _applicantIdentityService)
        {
            applicantIdentityService = _applicantIdentityService;
        }

        public async Task<ApiResponse> Handle(DeleteApplicantIdentityCommand request, CancellationToken cancellationToken)
        {
            return await applicantIdentityService.DeleteApplicantIdentity(request);
              
        }
    }
}
