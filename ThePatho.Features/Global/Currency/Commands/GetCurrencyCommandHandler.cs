using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Currency.Service;
using ThePatho.Features.Global.Currency.DTO;

namespace ThePatho.Features.Global.Currency.Commands
{
    public class GetCurrencyCommandHandler : IRequestHandler<GetCurrencyCommand, ApiResponse<CurrencyItemDto>>
    {
        private readonly ICurrencyService currencyService;

        public GetCurrencyCommandHandler(ICurrencyService _currencyService)
        {
            currencyService = _currencyService;
        }

        public async Task<ApiResponse<CurrencyItemDto>> Handle(GetCurrencyCommand request, CancellationToken cancellationToken)
        {
            return await currencyService.GetCurrency(request);
        }
    }
}


