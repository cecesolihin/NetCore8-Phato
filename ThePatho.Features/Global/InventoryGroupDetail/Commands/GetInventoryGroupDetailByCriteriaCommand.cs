using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroupDetail.DTO;

namespace ThePatho.Features.Global.InventoryGroupDetail.Commands
{
    public class GetInventoryGroupDetailByCriteriaCommand : IRequest<ApiResponse<InventoryGroupDetailItemDto>>
    {
        [JsonPropertyName("filter_InventoryGroupDetailId")]
        public int? FilterInventoryGroupDetailId { get; set; }

        [JsonPropertyName("filter_InventoryGroupCode")]
        public string? FilterInventoryGroupCode { get; set; }

        [JsonPropertyName("filter_InventoryTypeCode")]
        public string? FilterInventoryTypeCode { get; set; }

    }
}

