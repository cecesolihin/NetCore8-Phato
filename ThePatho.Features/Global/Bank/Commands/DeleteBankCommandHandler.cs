using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Bank.Service;

namespace ThePatho.Features.Global.Bank.Commands
{
    public class DeleteBankCommandHandler : IRequestHandler<DeleteBankCommand, ApiResponse>
    {
        private readonly IBankService BankService;

        public DeleteBankCommandHandler(IBankService _BankService)
        {
            BankService = _BankService;
        }

        public async Task<ApiResponse> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            return await BankService.DeleteBank(request);
        }
    }
}
