using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Building.DTO;

namespace ThePatho.Features.Global.Building.Commands
{
    public class GetBuildingByCriteriaCommand : IRequest<ApiResponse<BuildingItemDto>>
    {
        [JsonPropertyName("filter_BuildingName")]
        public string? FilterBuildingName { get; set; }

        [JsonPropertyName("filter_BuildingCode")]
        public string? FilterBuildingCode { get; set; }

        
    }
}
