using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.InventoryGroupOrg.Commands
{
    public class DeleteInventoryGroupOrgCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("inventory_group_org_id")]
        public int InventoryGroupOrgId { get; set; }
    }
}

