using MediatR;
using ThePatho.Features.Applicant.ApplicationApplicant.Service;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Commands
{
    public class SubmitApplicationApplicantCommandHandler : IRequestHandler<SubmitApplicationApplicantCommand, string>
    {
        private readonly IApplicationApplicantService ApplicationApplicantService;

        public SubmitApplicationApplicantCommandHandler(IApplicationApplicantService _ApplicationApplicantService)
        {
            ApplicationApplicantService = _ApplicationApplicantService;
        }

        public async Task<string> Handle(SubmitApplicationApplicantCommand request, CancellationToken cancellationToken)
        {
            await ApplicationApplicantService.SubmitApplicationApplicant(request);
            if (request.Action == "ADD")
            {
                return "Application Applicant successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Application Applicant successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
