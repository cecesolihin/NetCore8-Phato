using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Identity.DTO;

namespace ThePatho.Features.Global.Identity.Commands
{
    public class GetIdentityByCriteriaCommand : IRequest<ApiResponse<IdentityItemDto>>
    {
        [JsonPropertyName("identityCode")]
        public string? IdentityCode { get; set; }

        [JsonPropertyName("identityName")]
        public string? IdentityName { get; set; }

    }
}

