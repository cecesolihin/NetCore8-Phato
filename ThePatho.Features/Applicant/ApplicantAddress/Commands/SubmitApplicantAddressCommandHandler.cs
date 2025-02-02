using MediatR;
using ThePatho.Features.Applicant.ApplicantAddress.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantAddress.Commands
{
    public class SubmitApplicantAddressCommandHandler : IRequestHandler<SubmitApplicantAddressCommand, ApiResponse>
    {
        private readonly IApplicantAddressService applicantAddressService;

        public SubmitApplicantAddressCommandHandler(IApplicantAddressService _applicantAddressService)
        {
            applicantAddressService = _applicantAddressService;
        }

        public async Task<ApiResponse> Handle(SubmitApplicantAddressCommand request, CancellationToken cancellationToken)
        {
            return await applicantAddressService.SubmitApplicantAddress(request);
           
        }
    }
}
