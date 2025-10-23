using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TaxStatus.DTO;

namespace ThePatho.Features.Global.TaxStatus.Commands
{
    public class GetTaxStatusByCriteriaCommand : IRequest<ApiResponse<TaxStatusItemDto>>
    {
        [JsonPropertyName("filter_TaxStatusName")]
        public string? FilterTaxStatusName { get; set; }

        [JsonPropertyName("filter_TaxStatusCode")]
        public string? FilterTaxStatusCode { get; set; }
        [JsonPropertyName("filter_Married")]
        public string? FilterMarried { get; set; }
        [JsonPropertyName("filter_TotalDependents")]
        public int? FilterTotalDependents { get; set; }

    }
}
