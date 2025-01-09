using MediatR;
using ThePatho.Features.Applicant.ApplicantIdentity.Service;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class SubmitApplicantIdentityCommandHandler : IRequestHandler<SubmitApplicantIdentityCommand, string>
    {
        private readonly IApplicantIdentityService applicantIdentityService;

        public SubmitApplicantIdentityCommandHandler(IApplicantIdentityService _applicantIdentityService)
        {
            applicantIdentityService = _applicantIdentityService;
        }

        public async Task<string> Handle(SubmitApplicantIdentityCommand request, CancellationToken cancellationToken)
        {
            await applicantIdentityService.SubmitApplicantIdentity(request);
            if (request.Action == "ADD")
            {
                return "Applicant Identity successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Applicant Identity successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
