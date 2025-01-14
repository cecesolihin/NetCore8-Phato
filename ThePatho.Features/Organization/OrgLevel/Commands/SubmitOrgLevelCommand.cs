using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class SubmitOrgLevelCommand : IRequest<string>
    {
        [JsonPropertyName("org_level_code")]
        public string OrgLevelCode { get; set; }

        [JsonPropertyName("org_level_name")]
        public string OrgLevelName { get; set; }

        [JsonPropertyName("sort")]
        public byte? Sort { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
