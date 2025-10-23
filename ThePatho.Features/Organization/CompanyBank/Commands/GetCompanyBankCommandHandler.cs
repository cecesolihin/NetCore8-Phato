using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyBank.Service;
using ThePatho.Features.Organization.CompanyBank.DTO;

namespace ThePatho.Features.Organization.CompanyBank.Commands
{
    public class GetCompanyBankCommandHandler : IRequestHandler<GetCompanyBankCommand, ApiResponse<CompanyBankItemDto>>
    {
        private readonly ICompanyBankService companyBankService;

        public GetCompanyBankCommandHandler(ICompanyBankService _companyBankService)
        {
            companyBankService = _companyBankService;
        }

        public async Task<ApiResponse<CompanyBankItemDto>> Handle(GetCompanyBankCommand request, CancellationToken cancellationToken)
        {
            return await companyBankService.GetCompanyBank(request);
        }
    }
}
