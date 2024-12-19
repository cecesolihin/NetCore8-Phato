using MediatR;
using ThePatho.Features.Applicant.ApplicantWorkExperience.DTO;
using ThePatho.Features.Applicant.ApplicantWorkExperience.Service;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class GetApplicantWorkExperienceByCriteriaCommandHandler : IRequestHandler<GetApplicantWorkExperienceByCriteriaCommand, ApplicantWorkExperienceDto>
    {
        private readonly IApplicantWorkExperienceService applicantWorkExperienceService;
        public GetApplicantWorkExperienceByCriteriaCommandHandler(IApplicantWorkExperienceService _applicantWorkExperienceService)
        {
            applicantWorkExperienceService = _applicantWorkExperienceService;
        }
        public async Task<ApplicantWorkExperienceDto> Handle(GetApplicantWorkExperienceByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantWorkExperienceService.GetApplicantWorkExperienceByCriteria(request);

            return data;
        }
    }
}
