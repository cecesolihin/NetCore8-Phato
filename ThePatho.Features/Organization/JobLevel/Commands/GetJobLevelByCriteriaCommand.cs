using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevel.DTO;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class GetJobLevelByCriteriaCommand :IRequest<ApiResponse<JobLevelItemDto>>
    {
        [JsonPropertyName("jobLevelName")]
        public string? JobLevelName { get; set; }

        [JsonPropertyName("jobLevelCode")]
        public string? JobLevelCode { get; set; }
    }
}
