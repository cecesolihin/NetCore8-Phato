using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.JobLevelJobClass.Commands
{
    public class SubmitJobLevelJobClassCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("jobLevelCode")]
        public string JobLevelCode { get; set; } = null!;

        [JsonPropertyName("jobClassCode")]
        public string JobClassCode { get; set; } = null!;

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }
        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
