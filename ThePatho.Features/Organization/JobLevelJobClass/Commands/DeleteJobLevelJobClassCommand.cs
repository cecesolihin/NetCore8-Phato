using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.JobLevelJobClass.Commands
{
    public class DeleteJobLevelJobClassCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("jobLevelCode")]
        public string JobLevelCode { get; set; } = null!;

        [JsonPropertyName("jobClassCode")]
        public string JobClassCode { get; set; } = null!;
    }
}
