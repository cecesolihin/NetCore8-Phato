using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.RadiusUnit.Commands
{
    public class SubmitRadiusUnitCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("radiusUnitCode")]
        public string RadiusUnitCode { get; set; } = null!;

        [JsonPropertyName("radiusUnitName")]
        public string RadiusUnitName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
