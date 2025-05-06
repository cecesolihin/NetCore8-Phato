using MediatR;
using ThePatho.Features.Applicant.ApplicantWorkExperience.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class SubmitApplicantWorkExperienceCommandHandler : IRequestHandler<SubmitApplicantWorkExperienceCommand, ApiResponse>
    {
        private readonly IApplicantWorkExperienceService applicantWorkExperienceService;

        public SubmitApplicantWorkExperienceCommandHandler(IApplicantWorkExperienceService _applicantWorkExperienceService)
        {
            applicantWorkExperienceService = _applicantWorkExperienceService;
        }

        public async Task<ApiResponse> Handle(SubmitApplicantWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            return await applicantWorkExperienceService.SubmitApplicantWorkExperience(request);
        }
    }
}
