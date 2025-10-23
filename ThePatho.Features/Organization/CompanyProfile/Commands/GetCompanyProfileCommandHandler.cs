using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyProfile.Service;
using ThePatho.Features.Organization.CompanyProfile.DTO;

namespace ThePatho.Features.Organization.CompanyProfile.Commands
{
    public class GetCompanyProfileCommandHandler : IRequestHandler<GetCompanyProfileCommand, ApiResponse<CompanyProfileItemDto>>
    {
        private readonly ICompanyProfileService Service;

        public GetCompanyProfileCommandHandler(ICompanyProfileService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<CompanyProfileItemDto>> Handle(GetCompanyProfileCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetCompanyProfile(request);
        }
    }
}
