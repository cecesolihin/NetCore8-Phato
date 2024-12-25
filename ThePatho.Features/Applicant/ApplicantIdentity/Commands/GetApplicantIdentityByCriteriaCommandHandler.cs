using MediatR;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;
using ThePatho.Features.Applicant.ApplicantIdentity.Service;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class GetApplicantIdentityByCriteriaCommandHandler : IRequestHandler<GetApplicantIdentityByCriteriaCommand, ApplicantIdentityDto>
    {
        private readonly IApplicantIdentityService applicantIdentityService;
        public GetApplicantIdentityByCriteriaCommandHandler(IApplicantIdentityService _applicantIdentityService)
        {
            applicantIdentityService = _applicantIdentityService; 
        }
        public async Task<ApplicantIdentityDto> Handle(GetApplicantIdentityByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantIdentityService.GetApplicantIdentityByCriteria(request);

            return data;
        }
    }
}
