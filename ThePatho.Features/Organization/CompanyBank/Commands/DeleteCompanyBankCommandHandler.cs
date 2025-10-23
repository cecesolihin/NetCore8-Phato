using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyBank.Service;

namespace ThePatho.Features.Organization.CompanyBank.Commands
{
    public class DeleteCompanyBankCommandHandler : IRequestHandler<DeleteCompanyBankCommand, ApiResponse>
    {
        private readonly ICompanyBankService companyBankService;

        public DeleteCompanyBankCommandHandler(ICompanyBankService _companyBankService)
        {
            companyBankService = _companyBankService;
        }

        public async Task<ApiResponse> Handle(DeleteCompanyBankCommand request, CancellationToken cancellationToken)
        {
            return await companyBankService.DeleteCompanyBank(request);
        }
    }
}
