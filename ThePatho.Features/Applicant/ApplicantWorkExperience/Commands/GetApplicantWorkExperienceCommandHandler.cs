using MediatR;
using ThePatho.Features.Applicant.ApplicantWorkExperience.DTO;
using ThePatho.Features.Applicant.ApplicantWorkExperience.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class GetApplicantWorkExperienceCommandHandler : IRequestHandler<GetApplicantWorkExperienceCommand, NewApiResponse<ApplicantWorkExperienceItemDto>>
    {
        private readonly IApplicantWorkExperienceService applicantWorkExperienceService;
        public GetApplicantWorkExperienceCommandHandler(IApplicantWorkExperienceService _applicantWorkExperienceService)
        {
            applicantWorkExperienceService =_applicantWorkExperienceService;
        }
        public async Task<NewApiResponse<ApplicantWorkExperienceItemDto>> Handle(GetApplicantWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            return await applicantWorkExperienceService.GetApplicantWorkExperience(request); 

        }
    }
}
