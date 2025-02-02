using MediatR;
using ThePatho.Features.Applicant.ApplicantAddress.DTO;
using ThePatho.Features.Applicant.ApplicantAddress.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantAddress.Commands
{
    public class GetApplicantAddressByCriteriaCommandHandler : IRequestHandler<GetApplicantAddressByCriteriaCommand, NewApiResponse<ApplicantAddressDto>>
    {
        private readonly IApplicantAddressService applicantAddressService; 
        public GetApplicantAddressByCriteriaCommandHandler(IApplicantAddressService _applicantAddressService)
        {
            applicantAddressService = _applicantAddressService;
        }
        public async Task<NewApiResponse<ApplicantAddressDto>> Handle(GetApplicantAddressByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantAddressService.GetApplicantAddressByCriteria(request);

        }
    }
}
