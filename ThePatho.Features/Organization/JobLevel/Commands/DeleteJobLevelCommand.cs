using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class DeleteJobLevelCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("job_level_code")]
        public string JobLevelCode { get; set; }
    }
}
