using MediatR;
using ThePatho.Features.Applicant.ApplicantWorkExperience.DTO;
using ThePatho.Features.Applicant.ApplicantWorkExperience.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class GetApplicantWorkExperienceByCriteriaCommandHandler : IRequestHandler<GetApplicantWorkExperienceByCriteriaCommand, NewApiResponse<ApplicantWorkExperienceDto>>
    {
        private readonly IApplicantWorkExperienceService applicantWorkExperienceService;
        public GetApplicantWorkExperienceByCriteriaCommandHandler(IApplicantWorkExperienceService _applicantWorkExperienceService)
        {
            applicantWorkExperienceService = _applicantWorkExperienceService;
        }
        public async Task<NewApiResponse<ApplicantWorkExperienceDto>> Handle(GetApplicantWorkExperienceByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantWorkExperienceService.GetApplicantWorkExperienceByCriteria(request); 

        }
    }
}
