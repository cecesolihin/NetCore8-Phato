using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevelJobClass.DTO;

namespace ThePatho.Features.Organization.JobLevelJobClass.Commands
{
    public class GetJobLevelJobClassByCriteriaCommand : IRequest<ApiResponse<JobLevelJobClassItemDto>>
    {
        [JsonPropertyName("jobLevelCode")]
        public string? JobLevelCode { get; set; }

        [JsonPropertyName("jobClassCode")]
        public string? JobClassCode { get; set; }

    }
}
