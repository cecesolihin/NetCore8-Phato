using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.TerminationType.Commands
{
    public class DeleteTerminationTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("terminationTypeCode")]
        public string TerminationTypeCode { get; set; } = null!;
    }
}
