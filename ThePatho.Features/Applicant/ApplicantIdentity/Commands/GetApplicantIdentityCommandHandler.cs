using MediatR;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;
using ThePatho.Features.Applicant.ApplicantIdentity.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class GetApplicantIdentityCommandHandler : IRequestHandler<GetApplicantIdentityCommand, NewApiResponse<ApplicantIdentityItemDto>>
    {
        private readonly IApplicantIdentityService applicantIdentityService; 
        public GetApplicantIdentityCommandHandler(IApplicantIdentityService _applicantIdentityService)
        {
            applicantIdentityService =_applicantIdentityService;
        }
        public async Task<NewApiResponse<ApplicantIdentityItemDto>> Handle(GetApplicantIdentityCommand request, CancellationToken cancellationToken)
        {
            return await applicantIdentityService.GetApplicantIdentity(request);

        }
    }
}
