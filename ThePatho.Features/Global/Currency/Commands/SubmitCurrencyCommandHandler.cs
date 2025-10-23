using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Currency.Service;

namespace ThePatho.Features.Global.Currency.Commands
{
    public class SubmitCurrencyCommandHandler : IRequestHandler<SubmitCurrencyCommand, ApiResponse>
    {
        private readonly ICurrencyService currencyService;

        public SubmitCurrencyCommandHandler(ICurrencyService _currencyService)
        {
            currencyService = _currencyService;
        }

        public async Task<ApiResponse> Handle(SubmitCurrencyCommand request, CancellationToken cancellationToken)
        {
            return await currencyService.SubmitCurrency(request);
        }
    }
}


