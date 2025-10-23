using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.ClothSize.Commands
{
    public class SubmitClothSizeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("cloth_size_code")]
        public string ClothSizeCode { get; set; } = null!;

        [JsonPropertyName("cloth_size_name")]
        public string ClothSizeName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
