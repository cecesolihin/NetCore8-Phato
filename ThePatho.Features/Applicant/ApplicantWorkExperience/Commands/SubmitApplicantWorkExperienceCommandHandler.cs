using MediatR;
using ThePatho.Features.Applicant.ApplicantWorkExperience.Service;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class SubmitApplicantWorkExperienceCommandHandler : IRequestHandler<SubmitApplicantWorkExperienceCommand, string>
    {
        private readonly IApplicantWorkExperienceService applicantWorkExperienceService;

        public SubmitApplicantWorkExperienceCommandHandler(IApplicantWorkExperienceService _applicantWorkExperienceService)
        {
            applicantWorkExperienceService = _applicantWorkExperienceService;
        }

        public async Task<string> Handle(SubmitApplicantWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            await applicantWorkExperienceService.SubmitApplicantWorkExperience(request);
            if (request.Action == "ADD")
            {
                return "Scoring Setting successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Scoring Setting successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
