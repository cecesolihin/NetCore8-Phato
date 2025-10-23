using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Currency.Commands
{
    public class DeleteCurrencyCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; } = null!;
    }
}


