using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Identity.Commands
{
    public class SubmitIdentityCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("identity_code")]
        public string? IdentityCode { get; set; }

        [JsonPropertyName("identity_name")]
        public string? IdentityName { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

