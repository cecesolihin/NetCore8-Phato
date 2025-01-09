using MediatR;
using ThePatho.Features.Applicant.ApplicantAddress.Service;

namespace ThePatho.Features.Applicant.ApplicantAddress.Commands
{
    public class SubmitApplicantAddressCommandHandler : IRequestHandler<SubmitApplicantAddressCommand, string>
    {
        private readonly IApplicantAddressService applicantAddressService;

        public SubmitApplicantAddressCommandHandler(IApplicantAddressService _applicantAddressService)
        {
            applicantAddressService = _applicantAddressService;
        }

        public async Task<string> Handle(SubmitApplicantAddressCommand request, CancellationToken cancellationToken)
        {
            await applicantAddressService.SubmitApplicantAddress(request);
            if (request.Action == "ADD")
            {
                return "Applicant Address successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Applicant Address successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
