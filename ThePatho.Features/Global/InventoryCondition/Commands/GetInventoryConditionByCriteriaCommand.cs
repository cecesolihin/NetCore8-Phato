using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryCondition.DTO;

namespace ThePatho.Features.Global.InventoryCondition.Commands
{
    public class GetInventoryConditionByCriteriaCommand : IRequest<ApiResponse<InventoryConditionItemDto>>
    {
        [JsonPropertyName("filter_InventoryConditionName")]
        public string? FilterInventoryConditionName { get; set; }

        [JsonPropertyName("filter_InventoryConditionCode")]
        public string? FilterInventoryConditionCode { get; set; }

    }
}




