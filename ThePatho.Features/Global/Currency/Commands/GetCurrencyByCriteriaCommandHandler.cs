using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Currency.Service;
using ThePatho.Features.Global.Currency.DTO;

namespace ThePatho.Features.Global.Currency.Commands
{
    public class GetCurrencyByCriteriaCommandHandler : IRequestHandler<GetCurrencyByCriteriaCommand, ApiResponse<CurrencyItemDto>>
    {
        private readonly ICurrencyService currencyService;

        public GetCurrencyByCriteriaCommandHandler(ICurrencyService _currencyService)
        {
            currencyService = _currencyService;
        }

        public async Task<ApiResponse<CurrencyItemDto>> Handle(GetCurrencyByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await currencyService.GetCurrencyByCriteria(request);
        }
    }
}


