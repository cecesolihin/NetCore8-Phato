using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.TaxLocation.Commands
{
    public class SubmitTaxLocationCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("taxLocationCode")]
        public string TaxLocationCode { get; set; } = null!;

        [JsonPropertyName("taxLocationName")]
        public string TaxLocationName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
