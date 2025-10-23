using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.NumericalSize.Commands
{
    public class DeleteNumericalSizeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("numerical_size_id")]
        public int NumericalSizeId { get; set; }
    }
}
