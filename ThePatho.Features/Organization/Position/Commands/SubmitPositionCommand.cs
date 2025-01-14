using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class SubmitPositionCommand : IRequest<string>
    {
        [JsonPropertyName("position_code")]
        public string PositionCode { get; set; }

        [JsonPropertyName("position_name")]
        public string PositionName { get; set; }

        [JsonPropertyName("job_level_code")]
        public string JobLevelCode { get; set; }

        [JsonPropertyName("org_structure_id")]
        public int OrgStructureId { get; set; }

        [JsonPropertyName("act_as_head")]
        public bool ActAsHead { get; set; }

        [JsonPropertyName("objective")]
        public string? Objective { get; set; }

        [JsonPropertyName("job_description")]
        public string? JobDescription { get; set; }

        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
