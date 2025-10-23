using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.InventoryGroupOrg.Commands
{
    public class SubmitInventoryGroupOrgCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("inventory_group_org_id")]
        public int? InventoryGroupOrgId { get; set; }

        [JsonPropertyName("inventory_group_code")]
        public string InventoryGroupCode { get; set; } = null!;

        [JsonPropertyName("organization_code")]
        public string OrganizationCode { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

