using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.TerminationType.Commands
{
    public class SubmitTerminationTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("termination_type_code")]
        public string TerminationTypeCode { get; set; } = null!;

        [JsonPropertyName("termination_type_name")]
        public string TerminationTypeName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
