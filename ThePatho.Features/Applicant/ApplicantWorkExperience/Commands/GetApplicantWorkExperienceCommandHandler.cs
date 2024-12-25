using MediatR;
using ThePatho.Features.Applicant.ApplicantWorkExperience.DTO;
using ThePatho.Features.Applicant.ApplicantWorkExperience.Service;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class GetApplicantWorkExperienceCommandHandler : IRequestHandler<GetApplicantWorkExperienceCommand, ApplicantWorkExperienceItemDto>
    {
        private readonly IApplicantWorkExperienceService applicantWorkExperienceService;
        public GetApplicantWorkExperienceCommandHandler(IApplicantWorkExperienceService _applicantWorkExperienceService)
        {
            applicantWorkExperienceService =_applicantWorkExperienceService;
        }
        public async Task<ApplicantWorkExperienceItemDto> Handle(GetApplicantWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantWorkExperienceService.GetApplicantWorkExperience(request); 

            return new ApplicantWorkExperienceItemDto
            {
                DataOfRecords = data.Count,
                ApplicantWorkExperienceList = data,
            };
        }
    }
}
