using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Building.Commands
{
    public class DeleteBuildingCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("building_code")]
        public string BuildingCode { get; set; } = null!;
    }
}
