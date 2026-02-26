using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.TaxLocation.Commands
{
    public class DeleteTaxLocationCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("taxLocationCode")]
        public string TaxLocationCode { get; set; } = null!;
    }
}
