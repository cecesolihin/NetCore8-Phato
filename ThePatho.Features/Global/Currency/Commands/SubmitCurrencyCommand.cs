using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Currency.Commands
{
    public class SubmitCurrencyCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; } = null!;

        [JsonPropertyName("currency_name")]
        public string CurrencyName { get; set; } = null!;

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = null!;

        [JsonPropertyName("decimal_digit")]
        public int DecimalDigit { get; set; }

        [JsonPropertyName("is_default")]
        public bool IsDefault { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}


