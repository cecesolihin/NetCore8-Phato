using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroup.DTO;

namespace ThePatho.Features.Global.InventoryGroup.Commands
{
    public class GetSingleInventoryGroupCommand : IRequest<ApiResponse<InventoryGroupDto>>
    {
        [JsonPropertyName("filter_InventoryGroupCode")]
        public string FilterInventoryGroupCode { get; set; }

    }
}
