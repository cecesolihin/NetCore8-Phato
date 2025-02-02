using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantWorkExperience.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class DeleteApplicantWorkExperienceCommandHandler : IRequestHandler<DeleteApplicantWorkExperienceCommand, ApiResponse>
    {
        private readonly IApplicantWorkExperienceService applicantWorkExperienceService;

        public DeleteApplicantWorkExperienceCommandHandler(IApplicantWorkExperienceService _applicantWorkExperienceService)
        {
            applicantWorkExperienceService = _applicantWorkExperienceService;
        }

        public async Task<ApiResponse> Handle(DeleteApplicantWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            return await applicantWorkExperienceService.DeleteApplicantWorkExperience(request);
        }
    }
}
