using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroup.DTO;

namespace ThePatho.Features.Global.InventoryGroup.Commands
{
    public class GetInventoryGroupByCriteriaCommand : IRequest<ApiResponse<InventoryGroupItemDto>>
    {
        [JsonPropertyName("filter_InventoryGroupCode")]
        public string? FilterInventoryGroupCode { get; set; }

        [JsonPropertyName("filter_InventoryGroupName")]
        public string? FilterInventoryGroupName { get; set; }

        [JsonPropertyName("filter_GroupBy")]
        public string? FilterGroupBy { get; set; }

    }
}

