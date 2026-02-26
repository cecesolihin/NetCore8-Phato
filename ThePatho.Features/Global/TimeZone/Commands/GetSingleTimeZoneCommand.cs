using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TimeZone.DTO;

namespace ThePatho.Features.Global.TimeZone.Commands
{
    public class GetSingleTimeZoneCommand : IRequest<ApiResponse<TimeZoneDto>>
    {
        [JsonPropertyName("timeZoneCode")]
        public string FilterTimeZoneCode { get; set; }
    }
}
