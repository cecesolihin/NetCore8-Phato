using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Currency.DTO;

namespace ThePatho.Features.Global.Currency.Commands
{
    public class GetSingleCurrencyCommand : IRequest<ApiResponse<CurrencyDto>>
    {
        [JsonPropertyName("filter_CurrencyCode")]
        public string FilterCurrencyCode { get; set; }
    }
}
