using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.TimeZone.Commands
{
    public class SubmitTimeZoneCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("timeZoneCode")]
        public string TimeZoneCode { get; set; } = null!;

        [JsonPropertyName("timeZoneName")]
        public string TimeZoneName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
