using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class DeleteJobLevelCommand : IRequest<bool>
    {
        [JsonPropertyName("job_level_code")]
        public string JobLevelCode { get; set; }
    }
}
