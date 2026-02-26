using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class SubmitPositionCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("positionCode")]
        public string PositionCode { get; set; }

        [JsonPropertyName("positionName")]
        public string PositionName { get; set; }

        [JsonPropertyName("jobLevelCode")]
        public string JobLevelCode { get; set; }

        [JsonPropertyName("orgStructureId")]
        public int OrgStructureId { get; set; }

        [JsonPropertyName("actAsHead")]
        public bool ActAsHead { get; set; }

        [JsonPropertyName("objective")]
        public string? Objective { get; set; }

        [JsonPropertyName("jobDescription")]
        public string? JobDescription { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
