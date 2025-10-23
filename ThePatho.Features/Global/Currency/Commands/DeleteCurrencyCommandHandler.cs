using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Currency.Service;

namespace ThePatho.Features.Global.Currency.Commands
{
    public class DeleteCurrencyCommandHandler : IRequestHandler<DeleteCurrencyCommand, ApiResponse>
    {
        private readonly ICurrencyService currencyService;

        public DeleteCurrencyCommandHandler(ICurrencyService _currencyService)
        {
            currencyService = _currencyService;
        }

        public async Task<ApiResponse> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
        {
            return await currencyService.DeleteCurrency(request);
        }
    }
}


