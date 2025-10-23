using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Identity.Commands
{
    public class DeleteIdentityCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("identity_code")]
        public string IdentityCode { get; set; }
    }
}

