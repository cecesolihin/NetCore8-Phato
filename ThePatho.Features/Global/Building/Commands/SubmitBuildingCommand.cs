using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Building.Commands
{
    public class SubmitBuildingCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("building_code")]
        public string BuildingCode { get; set; } = null!;

        [JsonPropertyName("building_name")]
        public string BuildingName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
