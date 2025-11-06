using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class SubmitOrgStructureCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("org_structure_id")]
        public int OrgStructureId { get; set; }

        [JsonPropertyName("org_structure_code")]
        public string OrgStructureCode { get; set; } = null!;

        [JsonPropertyName("org_structure_name")]
        public string OrgStructureName { get; set; } = null!;

        [JsonPropertyName("parent_org_id")]
        public int ParentOrgId { get; set; }

        [JsonPropertyName("org_level_code")]
        public string OrgLevelCode { get; set; } = null!;
        [JsonPropertyName("cost_center")]
        public string CostCenter { get; set; } = null!;
        [JsonPropertyName("location")]
        public string Location { get; set; } = null!;
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }
        [JsonPropertyName("sort")]
        public int? Sort { get; set; }

        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
