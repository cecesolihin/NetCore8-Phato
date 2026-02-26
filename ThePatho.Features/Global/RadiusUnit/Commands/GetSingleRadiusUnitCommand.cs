using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RadiusUnit.DTO;

namespace ThePatho.Features.Global.RadiusUnit.Commands
{
    public class GetSingleRadiusUnitCommand : IRequest<ApiResponse<RadiusUnitDto>>
    {
        [JsonPropertyName("radiusUnitCode")]
        public string RadiusUnitCode { get; set; }
    }
}
