using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.NumericalSize.Commands
{
    public class SubmitNumericalSizeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("numerical_size_id")]
        public int? NumericalSizeId { get; set; }

        [JsonPropertyName("numerical_size_name")]
        public string NumericalSizeName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
