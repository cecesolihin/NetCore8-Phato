using MediatR;
using ThePatho.Features.Applicant.ApplicantAddress.DTO;
using ThePatho.Features.Applicant.ApplicantAddress.Service;

namespace ThePatho.Features.Applicant.ApplicantAddress.Commands
{
    public class GetApplicantAddressByCriteriaCommandHandler : IRequestHandler<GetApplicantAddressByCriteriaCommand, ApplicantAddressDto>
    {
        private readonly IApplicantAddressService applicantAddressService;
        public GetApplicantAddressByCriteriaCommandHandler(IApplicantAddressService _applicantAddressService)
        {
            applicantAddressService = _applicantAddressService;
        }
        public async Task<ApplicantAddressDto> Handle(GetApplicantAddressByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantAddressService.GetApplicantAddressByCriteria(request);

            return data;
        }
    }
}
