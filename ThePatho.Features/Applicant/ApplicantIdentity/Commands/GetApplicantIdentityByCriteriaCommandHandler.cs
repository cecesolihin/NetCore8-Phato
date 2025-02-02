using MediatR;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;
using ThePatho.Features.Applicant.ApplicantIdentity.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class GetApplicantIdentityByCriteriaCommandHandler : IRequestHandler<GetApplicantIdentityByCriteriaCommand, NewApiResponse<ApplicantIdentityDto>>
    {
        private readonly IApplicantIdentityService applicantIdentityService;
        public GetApplicantIdentityByCriteriaCommandHandler(IApplicantIdentityService _applicantIdentityService)
        {
            applicantIdentityService = _applicantIdentityService; 
        }
        public async Task<NewApiResponse<ApplicantIdentityDto>> Handle(GetApplicantIdentityByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantIdentityService.GetApplicantIdentityByCriteria(request);

        }
    }
}
