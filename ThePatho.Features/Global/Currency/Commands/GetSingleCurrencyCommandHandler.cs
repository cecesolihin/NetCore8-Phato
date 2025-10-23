using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Currency.Service;
using ThePatho.Features.Global.Currency.DTO;

namespace ThePatho.Features.Global.Currency.Commands
{
    public class GetSingleCurrencyCommandHandler : IRequestHandler<GetSingleCurrencyCommand, ApiResponse<CurrencyDto>>
    {
        private readonly ICurrencyService Service;

        public GetSingleCurrencyCommandHandler(ICurrencyService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<CurrencyDto>> Handle(GetSingleCurrencyCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleCurrency(request);
        }
    }
}
