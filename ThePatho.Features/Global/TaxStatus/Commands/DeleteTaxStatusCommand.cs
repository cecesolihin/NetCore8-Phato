using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.TaxStatus.Commands
{
    public class DeleteTaxStatusCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("tax_status_code")]
        public string TaxStatusCode { get; set; } = null!;
    }
}
