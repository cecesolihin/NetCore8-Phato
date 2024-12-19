using MediatR;
using ThePatho.Features.Applicant.ApplicantAddress.DTO;
using ThePatho.Features.Applicant.ApplicantAddress.Service;

namespace ThePatho.Features.Applicant.ApplicantAddress.Commands
{
    public class GetApplicantAddressCommandHandler : IRequestHandler<GetApplicantAddressCommand, ApplicantAddressItemDto>
    {
        private readonly IApplicantAddressService applicantAddressService;
        public GetApplicantAddressCommandHandler(IApplicantAddressService _applicantAddressService)
        {
            applicantAddressService =_applicantAddressService;
        }
        public async Task<ApplicantAddressItemDto> Handle(GetApplicantAddressCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantAddressService.GetApplicantAddress(request);

            return new ApplicantAddressItemDto
            {
                DataOfRecords = data.Count,
                ApplicantAddressList = data,
            };
        }
    }
}
