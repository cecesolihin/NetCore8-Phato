using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.JobClass.Commands
{
    public class DeleteJobClassCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("job_class_code")]
        public string JobClassCode { get; set; } = null!;
    }
}
