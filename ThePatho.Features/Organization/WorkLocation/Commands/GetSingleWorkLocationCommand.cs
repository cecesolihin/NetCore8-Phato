using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocation.DTO;

namespace ThePatho.Features.Organization.WorkLocation.Commands
{
    public class GetSingleWorkLocationCommand : IRequest<ApiResponse<WorkLocationDto>>
    {
        [JsonPropertyName("workLocationCode")]
        public string WorkLocationCode { get; set; } = null!;
    }
}
