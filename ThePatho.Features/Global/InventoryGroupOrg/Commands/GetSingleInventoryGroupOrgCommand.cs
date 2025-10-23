using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroupOrg.DTO;

namespace ThePatho.Features.Global.InventoryGroupOrg.Commands
{
    public class GetSingleInventoryGroupOrgCommand : IRequest<ApiResponse<InventoryGroupOrgDto>>
    {
        [JsonPropertyName("filter_InventoryGroupOrgId")]
        public int FilterInventoryGroupOrgId { get; set; }

    }
}
