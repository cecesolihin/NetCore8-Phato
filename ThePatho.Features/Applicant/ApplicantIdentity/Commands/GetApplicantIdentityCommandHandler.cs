using MediatR;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;
using ThePatho.Features.Applicant.ApplicantIdentity.Service;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class GetApplicantIdentityCommandHandler : IRequestHandler<GetApplicantIdentityCommand, ApplicantIdentityItemDto>
    {
        private readonly IApplicantIdentityService applicantIdentityService;
        public GetApplicantIdentityCommandHandler(IApplicantIdentityService _applicantIdentityService)
        {
            applicantIdentityService =_applicantIdentityService;
        }
        public async Task<ApplicantIdentityItemDto> Handle(GetApplicantIdentityCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantIdentityService.GetApplicantIdentity(request);

            return new ApplicantIdentityItemDto
            {
                DataOfRecords = data.Count,
                ApplicantIdentityList = data,
            };
        }
    }
}
