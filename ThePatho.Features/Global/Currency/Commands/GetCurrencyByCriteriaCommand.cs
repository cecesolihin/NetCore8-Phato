using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Currency.DTO;

namespace ThePatho.Features.Global.Currency.Commands
{
    public class GetCurrencyByCriteriaCommand : IRequest<ApiResponse<CurrencyItemDto>>
    {
        [JsonPropertyName("currencyName")]
        public string? CurrencyName { get; set; }

        [JsonPropertyName("currencyCode")]
        public string? CurrencyCode { get; set; }


    }
}


