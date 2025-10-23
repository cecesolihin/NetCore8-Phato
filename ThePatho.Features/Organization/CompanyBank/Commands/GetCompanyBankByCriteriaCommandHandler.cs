using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyBank.Service;
using ThePatho.Features.Organization.CompanyBank.DTO;

namespace ThePatho.Features.Organization.CompanyBank.Commands
{
    public class GetCompanyBankByCriteriaCommandHandler : IRequestHandler<GetCompanyBankByCriteriaCommand, ApiResponse<CompanyBankItemDto>>
    {
        private readonly ICompanyBankService companyBankService;

        public GetCompanyBankByCriteriaCommandHandler(ICompanyBankService _companyBankService)
        {
            companyBankService = _companyBankService;
        }

        public async Task<ApiResponse<CompanyBankItemDto>> Handle(GetCompanyBankByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await companyBankService.GetCompanyBankByCriteria(request);
        }
    }
}
