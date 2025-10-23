using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.ShoeSize.Commands
{
    public class SubmitShoeSizeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("shoe_size_code")]
        public string ShoeSizeCode { get; set; } = null!;

        [JsonPropertyName("shoe_size_name")]
        public string ShoeSizeName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
