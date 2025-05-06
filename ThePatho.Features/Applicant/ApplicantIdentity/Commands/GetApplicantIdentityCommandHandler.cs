using MediatR;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;
using ThePatho.Features.Applicant.ApplicantIdentity.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class GetApplicantIdentityCommandHandler : IRequestHandler<GetApplicantIdentityCommand, ApiResponse<ApplicantIdentityItemDto>>
    {
        private readonly IApplicantIdentityService applicantIdentityService; 
        public GetApplicantIdentityCommandHandler(IApplicantIdentityService _applicantIdentityService)
        {
            applicantIdentityService =_applicantIdentityService;
        }
        public async Task<ApiResponse<ApplicantIdentityItemDto>> Handle(GetApplicantIdentityCommand request, CancellationToken cancellationToken)
        {
            return await applicantIdentityService.GetApplicantIdentity(request);

        }
    }
}
