using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Bank.DTO;
using ThePatho.Features.Global.Bank.Service;

namespace ThePatho.Features.Global.Bank.Commands
{
    public class GetSingleBankCommandHandler : IRequestHandler<GetSingleBankCommand, ApiResponse<BankDto>>
    {
        private readonly IBankService BankService;
        public GetSingleBankCommandHandler(IBankService _BankService)
        {
            BankService = _BankService;
        }
        public async Task<ApiResponse<BankDto>> Handle(GetSingleBankCommand request, CancellationToken cancellationToken)
        {
            return await BankService.GetSingleBank(request);
        }
    }
}
