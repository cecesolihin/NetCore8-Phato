using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevel.DTO;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class GetJobLevelByCriteriaCommand :IRequest<ApiResponse<JobLevelItemDto>>
    {
        [JsonPropertyName("filter_JobLevelName")]
        public string? FilterJobLevelName { get; set; }

        [JsonPropertyName("filter_JobLevelCode")]
        public string? FilterJobLevelCode { get; set; }
    }
}
