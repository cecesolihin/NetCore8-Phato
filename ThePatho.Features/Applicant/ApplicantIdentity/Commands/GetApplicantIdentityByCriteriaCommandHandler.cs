using MediatR;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;
using ThePatho.Features.Applicant.ApplicantIdentity.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class GetApplicantIdentityByCriteriaCommandHandler : IRequestHandler<GetApplicantIdentityByCriteriaCommand, ApiResponse<ApplicantIdentityDto>>
    {
        private readonly IApplicantIdentityService applicantIdentityService;
        public GetApplicantIdentityByCriteriaCommandHandler(IApplicantIdentityService _applicantIdentityService)
        {
            applicantIdentityService = _applicantIdentityService; 
        }
        public async Task<ApiResponse<ApplicantIdentityDto>> Handle(GetApplicantIdentityByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantIdentityService.GetApplicantIdentityByCriteria(request);

        }
    }
}
