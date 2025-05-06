using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevel.DTO;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class GetJobLevelByCriteriaCommand :IRequest<ApiResponse<JobLevelDto>>
    {
        [JsonPropertyName("filter_JobLevelCode")]
        public string JobLevelCode { get; set; }
    }
}
