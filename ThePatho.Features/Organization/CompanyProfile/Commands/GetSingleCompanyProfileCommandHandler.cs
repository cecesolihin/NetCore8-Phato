using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyProfile.Service;
using ThePatho.Features.Organization.CompanyProfile.DTO;

namespace ThePatho.Features.Organization.CompanyProfile.Commands
{
    public class GetSingleCompanyProfileCommandHandler : IRequestHandler<GetSingleCompanyProfileCommand, ApiResponse<CompanyProfileDto>>
    {
        private readonly ICompanyProfileService Service;

        public GetSingleCompanyProfileCommandHandler(ICompanyProfileService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<CompanyProfileDto>> Handle(GetSingleCompanyProfileCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleCompanyProfile(request);
        }
    }
}
