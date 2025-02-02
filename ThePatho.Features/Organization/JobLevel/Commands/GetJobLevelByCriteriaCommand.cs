using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Organization.JobLevel.DTO;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class GetJobLevelByCriteriaCommand :IRequest<NewApiResponse<JobLevelDto>>
    {
        [JsonPropertyName("filter_JobLevelCode")]
        public string JobLevelCode { get; set; }
    }
}
