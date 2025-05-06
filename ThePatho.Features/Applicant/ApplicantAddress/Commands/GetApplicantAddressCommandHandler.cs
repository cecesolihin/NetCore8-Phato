using MediatR;
using ThePatho.Features.Applicant.ApplicantAddress.DTO;
using ThePatho.Features.Applicant.ApplicantAddress.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantAddress.Commands
{
    public class GetApplicantAddressCommandHandler : IRequestHandler<GetApplicantAddressCommand, ApiResponse<ApplicantAddressItemDto>>
    {
        private readonly IApplicantAddressService applicantAddressService;
        public GetApplicantAddressCommandHandler(IApplicantAddressService _applicantAddressService)
        {
            applicantAddressService =_applicantAddressService;
        }
        public async Task<ApiResponse<ApplicantAddressItemDto>> Handle(GetApplicantAddressCommand request, CancellationToken cancellationToken)
        {
            return await applicantAddressService.GetApplicantAddress(request);

        }
    }
}
