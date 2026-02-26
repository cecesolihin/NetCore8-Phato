using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.RadiusUnit.Commands
{
    public class DeleteRadiusUnitCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("radiusUnitCode")]
        public string RadiusUnitCode { get; set; } = null!;
    }
}
