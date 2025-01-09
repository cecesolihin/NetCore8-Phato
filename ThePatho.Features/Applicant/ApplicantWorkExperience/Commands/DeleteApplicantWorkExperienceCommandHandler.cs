using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantWorkExperience.Service;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class DeleteApplicantWorkExperienceCommandHandler : IRequestHandler<DeleteApplicantWorkExperienceCommand, bool>
    {
        private readonly IApplicantWorkExperienceService applicantWorkExperienceService;

        public DeleteApplicantWorkExperienceCommandHandler(IApplicantWorkExperienceService _applicantWorkExperienceService)
        {
            applicantWorkExperienceService = _applicantWorkExperienceService;
        }

        public async Task<bool> Handle(DeleteApplicantWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await applicantWorkExperienceService.DeleteApplicantWorkExperience(request);
                return true;
            }
            catch
            {
                // Log the error here if needed
                return false;
            }
        }
    }
}
