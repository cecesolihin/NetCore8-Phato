using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.RomanianSize.Commands
{
    public class SubmitRomanianSizeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("romanian_size_id")]
        public int? RomanianSizeId { get; set; }

        [JsonPropertyName("romanian_size_name")]
        public string RomanianSizeName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
