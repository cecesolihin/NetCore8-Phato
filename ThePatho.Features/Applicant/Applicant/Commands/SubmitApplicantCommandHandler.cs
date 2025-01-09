using MediatR;
using ThePatho.Features.Applicant.Applicant.Service;

namespace ThePatho.Features.Applicant.Applicant.Commands
{
    public class SubmitApplicantCommandHandler : IRequestHandler<SubmitApplicantCommand, string>
    {
        private readonly IApplicantService applicantService;

        public SubmitApplicantCommandHandler(IApplicantService _applicantService)
        {
            applicantService = _applicantService;
        }

        public async Task<string> Handle(SubmitApplicantCommand request, CancellationToken cancellationToken)
        {
            await applicantService.SubmitApplicant(request);
            if (request.Action == "ADD")
            {
                return "Applicant successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Applicant successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
