using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Bank.DTO;
using ThePatho.Features.Global.Bank.Service;

namespace ThePatho.Features.Global.Bank.Commands
{
    public class GetBankCommandHandler : IRequestHandler<GetBankCommand, ApiResponse<BankItemDto>>
    {
        private readonly IBankService BankService;
        public GetBankCommandHandler(IBankService _BankService)
        {
            BankService = _BankService;
        }
        public async Task<ApiResponse<BankItemDto>> Handle(GetBankCommand request, CancellationToken cancellationToken)
        {
            return await BankService.GetBank(request);
        }
    }
}
