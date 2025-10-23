using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Bank.DTO;
using ThePatho.Features.Global.Bank.Service;

namespace ThePatho.Features.Global.Bank.Commands
{
    public class GetBankByCriteriaCommandHandler : IRequestHandler<GetBankByCriteriaCommand, ApiResponse<BankItemDto>>
    {
        private readonly IBankService BankService;
        public GetBankByCriteriaCommandHandler(IBankService _BankService)
        {
            BankService = _BankService;
        }
        public async Task<ApiResponse<BankItemDto>> Handle(GetBankByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await BankService.GetBankByCriteria(request);
        }
    }
}
