using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyProfile.Service;
using ThePatho.Features.Organization.CompanyProfile.DTO;

namespace ThePatho.Features.Organization.CompanyProfile.Commands
{
    public class GetCompanyProfileByCriteriaCommandHandler : IRequestHandler<GetCompanyProfileByCriteriaCommand, ApiResponse<CompanyProfileItemDto>>
    {
        private readonly ICompanyProfileService Service;

        public GetCompanyProfileByCriteriaCommandHandler(ICompanyProfileService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<CompanyProfileItemDto>> Handle(GetCompanyProfileByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetCompanyProfileByCriteria(request);
        }
    }
}
