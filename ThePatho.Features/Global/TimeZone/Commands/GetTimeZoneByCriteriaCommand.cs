using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TimeZone.DTO;

namespace ThePatho.Features.Global.TimeZone.Commands
{
    public class GetTimeZoneByCriteriaCommand : IRequest<ApiResponse<TimeZoneItemDto>>
    {
        [JsonPropertyName("timeZoneName")]
        public string? TimeZoneName { get; set; }

        [JsonPropertyName("timeZoneCode")]
        public string? TimeZoneCode { get; set; }
    }
}
