using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.TaxStatus.Commands
{
    public class SubmitTaxStatusCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("tax_status_code")]
        public string TaxStatusCode { get; set; } = null!;

        [JsonPropertyName("tax_status_name")]
        public string TaxStatusName { get; set; } = null!;

        [JsonPropertyName("married")]
        public string Married { get; set; } = null!;

        [JsonPropertyName("total_dependents")]
        public byte TotalDependents { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
