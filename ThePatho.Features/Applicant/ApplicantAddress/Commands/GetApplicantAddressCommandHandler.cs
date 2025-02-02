using MediatR;
using ThePatho.Features.Applicant.ApplicantAddress.DTO;
using ThePatho.Features.Applicant.ApplicantAddress.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantAddress.Commands
{
    public class GetApplicantAddressCommandHandler : IRequestHandler<GetApplicantAddressCommand, NewApiResponse<ApplicantAddressItemDto>>
    {
        private readonly IApplicantAddressService applicantAddressService;
        public GetApplicantAddressCommandHandler(IApplicantAddressService _applicantAddressService)
        {
            applicantAddressService =_applicantAddressService;
        }
        public async Task<NewApiResponse<ApplicantAddressItemDto>> Handle(GetApplicantAddressCommand request, CancellationToken cancellationToken)
        {
            return await applicantAddressService.GetApplicantAddress(request);

        }
    }
}
