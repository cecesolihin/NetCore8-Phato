using MediatR;
using ThePatho.Features.Applicant.ApplicantAddress.DTO;
using ThePatho.Features.Applicant.ApplicantAddress.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantAddress.Commands
{
    public class GetApplicantAddressByCriteriaCommandHandler : IRequestHandler<GetApplicantAddressByCriteriaCommand, ApiResponse<ApplicantAddressDto>>
    {
        private readonly IApplicantAddressService applicantAddressService; 
        public GetApplicantAddressByCriteriaCommandHandler(IApplicantAddressService _applicantAddressService)
        {
            applicantAddressService = _applicantAddressService;
        }
        public async Task<ApiResponse<ApplicantAddressDto>> Handle(GetApplicantAddressByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantAddressService.GetApplicantAddressByCriteria(request);

        }
    }
}
