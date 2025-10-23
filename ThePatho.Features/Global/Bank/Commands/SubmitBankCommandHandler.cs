using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Bank.Service;

namespace ThePatho.Features.Global.Bank.Commands
{
    public class SubmitBankCommandHandler : IRequestHandler<SubmitBankCommand, ApiResponse>
    {
        private readonly IBankService BankService;

        public SubmitBankCommandHandler(IBankService _BankService)
        {
            BankService = _BankService;
        }

        public async Task<ApiResponse> Handle(SubmitBankCommand request, CancellationToken cancellationToken)
        {
            return await BankService.SubmitBank(request);
        }
    }
}
