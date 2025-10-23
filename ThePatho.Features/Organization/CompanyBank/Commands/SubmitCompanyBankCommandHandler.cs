using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyBank.Service;

namespace ThePatho.Features.Organization.CompanyBank.Commands
{
    public class SubmitCompanyBankCommandHandler : IRequestHandler<SubmitCompanyBankCommand, ApiResponse>
    {
        private readonly ICompanyBankService companyBankService;

        public SubmitCompanyBankCommandHandler(ICompanyBankService _companyBankService)
        {
            companyBankService = _companyBankService;
        }

        public async Task<ApiResponse> Handle(SubmitCompanyBankCommand request, CancellationToken cancellationToken)
        {
            return await companyBankService.SubmitCompanyBank(request);
        }
    }
}
