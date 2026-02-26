using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class SubmitOrgStructureCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("orgStructureId")]
        public int OrgStructureId { get; set; }

        [JsonPropertyName("orgStructureCode")]
        public string OrgStructureCode { get; set; } = null!;

        [JsonPropertyName("orgStructureName")]
        public string OrgStructureName { get; set; } = null!;

        [JsonPropertyName("parentOrgId")]
        public int ParentOrgId { get; set; }

        [JsonPropertyName("orgLevelCode")]
        public string OrgLevelCode { get; set; } = null!;
        [JsonPropertyName("costCenter")]
        public string CostCenter { get; set; } = null!;
        [JsonPropertyName("location")]
        public string Location { get; set; } = null!;
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }
        [JsonPropertyName("sortOrder")]
        public int? SortOrder { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
