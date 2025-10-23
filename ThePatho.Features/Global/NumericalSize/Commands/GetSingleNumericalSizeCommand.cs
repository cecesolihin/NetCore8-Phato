using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.NumericalSize.DTO;

namespace ThePatho.Features.Global.NumericalSize.Commands
{
    public class GetSingleNumericalSizeCommand : IRequest<ApiResponse<NumericalSizeDto>>
    {
        [JsonPropertyName("filter_NumericalSizeId")]
        public int FilterNumericalSizeId { get; set; }
    }
}
