using MediatR;
using ThePatho.Features.Applicant.ApplicantEducation.Service;

namespace ThePatho.Features.Applicant.ApplicantEducation.Commands
{
    public class SubmitApplicantEducationCommandHandler : IRequestHandler<SubmitApplicantEducationCommand, string>
    {
        private readonly IApplicantEducationService applicantEducationService;

        public SubmitApplicantEducationCommandHandler(IApplicantEducationService _applicantEducationService)
        {
            applicantEducationService = _applicantEducationService;
        }

        public async Task<string> Handle(SubmitApplicantEducationCommand request, CancellationToken cancellationToken)
        {
            await applicantEducationService.SubmitApplicantEducation(request);
            if (request.Action == "ADD")
            {
                return "Applicant Education successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Applicant Education successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
