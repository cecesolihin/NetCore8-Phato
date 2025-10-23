using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Religion.Commands
{
    public class SubmitReligionCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("religion_id")]
        public int? ReligionId { get; set; }

        [JsonPropertyName("religion_name")]
        public string ReligionName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
