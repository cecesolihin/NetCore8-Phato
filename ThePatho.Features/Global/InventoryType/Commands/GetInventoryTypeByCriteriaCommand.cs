using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryType.DTO;

namespace ThePatho.Features.Global.InventoryType.Commands
{
    public class GetInventoryTypeByCriteriaCommand : IRequest<ApiResponse<InventoryTypeItemDto>>
    {
        [JsonPropertyName("filter_InventoryName")]
        public string? FilterInventoryName { get; set; }

        [JsonPropertyName("filter_InventoryTypeCode")]
        public string? FilterInventoryTypeCode { get; set; }
    }
}
