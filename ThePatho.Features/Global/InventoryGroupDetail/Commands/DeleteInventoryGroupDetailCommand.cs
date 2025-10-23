using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.InventoryGroupDetail.Commands
{
    public class DeleteInventoryGroupDetailCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("inventory_group_detail_id")]
        public int InventoryGroupDetailId { get; set; }
    }
}

