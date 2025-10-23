using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.WorkLocation.Commands
{
    public class DeleteWorkLocationCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("work_location_code")]
        public string WorkLocationCode { get; set; } = null!;
    }
}
