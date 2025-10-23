using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TaxStatus.DTO;

namespace ThePatho.Features.Global.TaxStatus.Commands
{
    public class GetSingleTaxStatusCommand : IRequest<ApiResponse<TaxStatusDto>>
    {
        [JsonPropertyName("filter_TaxStatusCode")]
        public string FilterTaxStatusCode { get; set; } = null!;
    }
}
