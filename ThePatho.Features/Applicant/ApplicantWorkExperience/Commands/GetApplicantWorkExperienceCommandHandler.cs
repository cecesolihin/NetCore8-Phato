using MediatR;
using ThePatho.Features.Applicant.ApplicantWorkExperience.DTO;
using ThePatho.Features.Applicant.ApplicantWorkExperience.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class GetApplicantWorkExperienceCommandHandler : IRequestHandler<GetApplicantWorkExperienceCommand, ApiResponse<ApplicantWorkExperienceItemDto>>
    {
        private readonly IApplicantWorkExperienceService applicantWorkExperienceService;
        public GetApplicantWorkExperienceCommandHandler(IApplicantWorkExperienceService _applicantWorkExperienceService)
        {
            applicantWorkExperienceService =_applicantWorkExperienceService;
        }
        public async Task<ApiResponse<ApplicantWorkExperienceItemDto>> Handle(GetApplicantWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            return await applicantWorkExperienceService.GetApplicantWorkExperience(request); 

        }
    }
}
