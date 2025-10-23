using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Currency.DTO;

namespace ThePatho.Features.Global.Currency.Commands
{
    public class GetCurrencyByCriteriaCommand : IRequest<ApiResponse<CurrencyItemDto>>
    {
        [JsonPropertyName("filter_CurrencyName")]
        public string? FilterCurrencyName { get; set; }

        [JsonPropertyName("filter_CurrencyCode")]
        public string? FilterCurrencyCode { get; set; }


    }
}


