using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobClass.DTO;

namespace ThePatho.Features.Organization.JobClass.Commands
{
    public class GetSingleJobClassCommand : IRequest<ApiResponse<JobClassDto>>
    {
        [JsonPropertyName("jobClassCode")]
        public string JobClassCode { get; set; } = null!;
    }
}
