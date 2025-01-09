using MediatR;
using ThePatho.Features.Applicant.ApplicantPersonalData.Service;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Commands
{
    public class SubmitApplicantPersonalDataCommandHandler : IRequestHandler<SubmitApplicantPersonalDataCommand, string>
    {
        private readonly IApplicantPersonalDataService applicantPersonalDataService;

        public SubmitApplicantPersonalDataCommandHandler(IApplicantPersonalDataService _applicantPersonalDataService)
        {
            applicantPersonalDataService = _applicantPersonalDataService;
        }

        public async Task<string> Handle(SubmitApplicantPersonalDataCommand request, CancellationToken cancellationToken)
        {
            await applicantPersonalDataService.SubmitApplicantPersonalData(request);
            if (request.Action == "ADD")
            {
                return "Applicant Personal Data successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Applicant Personal Data successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
