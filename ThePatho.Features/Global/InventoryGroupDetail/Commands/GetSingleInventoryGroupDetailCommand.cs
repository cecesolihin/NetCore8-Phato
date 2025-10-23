using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroupDetail.DTO;

namespace ThePatho.Features.Global.InventoryGroupDetail.Commands
{
    public class GetSingleInventoryGroupDetailCommand : IRequest<ApiResponse<InventoryGroupDetailDto>>
    {
        [JsonPropertyName("_id")]
        public int InventoryGroupDetailId { get; set; }

    }
}
