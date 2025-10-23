using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.InventoryGroupDetail.Commands
{
    public class SubmitInventoryGroupDetailCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("inventory_group_detail_id")]
        public int? InventoryGroupDetailId { get; set; }

        [JsonPropertyName("inventory_group_code")]
        public string? InventoryGroupCode { get; set; }

        [JsonPropertyName("inventory_type_code")]
        public string? InventoryTypeCode { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

