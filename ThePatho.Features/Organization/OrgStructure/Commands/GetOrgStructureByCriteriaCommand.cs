using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgStructure.DTO;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class GetOrgStructureByCriteriaCommand :IRequest<ApiResponse<OrgStructureItemDto>>
    {
        [JsonPropertyName("orgStructureId")]
        public int? OrgStructureId { get; set; }

        [JsonPropertyName("orgStructureCode")]
        public string? OrgStructureCode { get; set; }

        [JsonPropertyName("orgStructureName")]
        public string? OrgStructureName { get; set; }

        [JsonPropertyName("orgLevelCode")]
        public string? OrgLevelCode { get; set; }
        [JsonPropertyName("costCenterCode")]
        public string? CostCenterCode { get; set; }
    }
}
