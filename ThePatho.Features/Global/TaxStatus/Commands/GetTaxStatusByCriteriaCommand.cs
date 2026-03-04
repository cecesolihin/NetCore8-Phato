using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TaxStatus.DTO;

namespace ThePatho.Features.Global.TaxStatus.Commands
{
    public class GetTaxStatusByCriteriaCommand : IRequest<ApiResponse<TaxStatusItemDto>>
    {
        [JsonPropertyName("taxStatusName")]
        public string? TaxStatusName { get; set; }

        [JsonPropertyName("taxStatusCode")]
        public string? TaxStatusCode { get; set; }
        [JsonPropertyName("married")]
        public string? Married { get; set; }
        [JsonPropertyName("totalDependents")]
        public int? TotalDependents { get; set; }

    }
}
