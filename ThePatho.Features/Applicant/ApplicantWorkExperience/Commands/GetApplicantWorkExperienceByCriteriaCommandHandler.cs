using MediatR;
using ThePatho.Features.Applicant.ApplicantWorkExperience.DTO;
using ThePatho.Features.Applicant.ApplicantWorkExperience.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class GetApplicantWorkExperienceByCriteriaCommandHandler : IRequestHandler<GetApplicantWorkExperienceByCriteriaCommand, ApiResponse<ApplicantWorkExperienceDto>>
    {
        private readonly IApplicantWorkExperienceService applicantWorkExperienceService;
        public GetApplicantWorkExperienceByCriteriaCommandHandler(IApplicantWorkExperienceService _applicantWorkExperienceService)
        {
            applicantWorkExperienceService = _applicantWorkExperienceService;
        }
        public async Task<ApiResponse<ApplicantWorkExperienceDto>> Handle(GetApplicantWorkExperienceByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantWorkExperienceService.GetApplicantWorkExperienceByCriteria(request); 

        }
    }
}
