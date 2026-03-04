using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryCondition.DTO;

namespace ThePatho.Features.Global.InventoryCondition.Commands
{
    public class GetInventoryConditionByCriteriaCommand : IRequest<ApiResponse<InventoryConditionItemDto>>
    {
        [JsonPropertyName("inventoryConditionName")]
        public string? InventoryConditionName { get; set; }

        [JsonPropertyName("inventoryConditionCode")]
        public string? InventoryConditionCode { get; set; }

    }
}





