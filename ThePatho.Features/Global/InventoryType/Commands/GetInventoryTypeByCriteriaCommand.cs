using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryType.DTO;

namespace ThePatho.Features.Global.InventoryType.Commands
{
    public class GetInventoryTypeByCriteriaCommand : IRequest<ApiResponse<InventoryTypeItemDto>>
    {
        [JsonPropertyName("inventoryName")]
        public string? InventoryName { get; set; }

        [JsonPropertyName("inventoryTypeCode")]
        public string? InventoryTypeCode { get; set; }
    }
}
