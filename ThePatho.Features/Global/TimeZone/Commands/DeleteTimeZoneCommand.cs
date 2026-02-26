using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.TimeZone.Commands
{
    public class DeleteTimeZoneCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("timeZoneCode")]
        public string TimeZoneCode { get; set; } = null!;
    }
}
