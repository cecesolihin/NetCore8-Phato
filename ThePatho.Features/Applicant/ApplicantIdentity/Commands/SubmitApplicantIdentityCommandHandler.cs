using MediatR;
using ThePatho.Features.Applicant.ApplicantIdentity.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class SubmitApplicantIdentityCommandHandler : IRequestHandler<SubmitApplicantIdentityCommand, ApiResponse>
    {
        private readonly IApplicantIdentityService applicantIdentityService;

        public SubmitApplicantIdentityCommandHandler(IApplicantIdentityService _applicantIdentityService)
        {
            applicantIdentityService = _applicantIdentityService;
        }

        public async Task<ApiResponse> Handle(SubmitApplicantIdentityCommand request, CancellationToken cancellationToken)
        {
            return await applicantIdentityService.SubmitApplicantIdentity(request);
        }
    }
}
