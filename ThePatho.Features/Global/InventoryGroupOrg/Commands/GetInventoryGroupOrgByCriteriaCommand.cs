using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroupOrg.DTO;

namespace ThePatho.Features.Global.InventoryGroupOrg.Commands
{
    public class GetInventoryGroupOrgByCriteriaCommand : IRequest<ApiResponse<InventoryGroupOrgItemDto>>
    {
        [JsonPropertyName("filter_InventoryGroupCode")]
        public string? FilterInventoryGroupCode { get; set; }

        [JsonPropertyName("filter_OrganizationCode")]
        public string? FilterOrganizationCode { get; set; }

    }
}

