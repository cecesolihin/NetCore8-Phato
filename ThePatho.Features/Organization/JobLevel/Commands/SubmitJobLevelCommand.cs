using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class SubmitJobLevelCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("jobLevelCode")]
        public string JobLevelCode { get; set; }

        [JsonPropertyName("jobLevelName")]
        public string JobLevelName { get; set; }

        [JsonPropertyName("sortOrder")]
        public byte? SortOrder { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
        [JsonPropertyName("jobClassCodes")]
        public List<string> JobClassCodes { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
