using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TaxLocation.DTO;

namespace ThePatho.Features.Global.TaxLocation.Commands
{
    public class GetSingleTaxLocationCommand : IRequest<ApiResponse<TaxLocationDto>>
    {
        [JsonPropertyName("taxLocationCode")]
        public string TaxLocationCode { get; set; }
    }
}
