using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevel.DTO;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class GetSingleJobLevelCommand : IRequest<ApiResponse<JobLevelDto>>
    {
        [JsonPropertyName("jobLevelCode")]
        public string JobLevelCode { get; set; }
    }
}
