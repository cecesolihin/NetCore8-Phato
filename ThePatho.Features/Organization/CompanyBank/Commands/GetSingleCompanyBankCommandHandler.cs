using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyBank.Service;
using ThePatho.Features.Organization.CompanyBank.DTO;

namespace ThePatho.Features.Organization.CompanyBank.Commands
{
    public class GetSingleCompanyBankCommandHandler : IRequestHandler<GetSingleCompanyBankCommand, ApiResponse<CompanyBankDto>>
    {
        private readonly ICompanyBankService companyBankService;

        public GetSingleCompanyBankCommandHandler(ICompanyBankService _companyBankService)
        {
            companyBankService = _companyBankService;
        }

        public async Task<ApiResponse<CompanyBankDto>> Handle(GetSingleCompanyBankCommand request, CancellationToken cancellationToken)
        {
            return await companyBankService.GetSingleCompanyBank(request);
        }
    }
}
