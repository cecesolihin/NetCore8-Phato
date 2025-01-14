using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class SubmitOrgStructureCommand : IRequest<string>
    {
        [JsonPropertyName("org_structure_code")]
        public string OrgStructureCode { get; set; }

        [JsonPropertyName("org_structure_name")]
        public string OrgStructureName { get; set; }

        [JsonPropertyName("parent_org_id")]
        public int? ParentOrgId { get; set; }

        [JsonPropertyName("org_level_code")]
        public string OrgLevelCode { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
