using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Identity.DTO;

namespace ThePatho.Features.Global.Identity.Commands
{
    public class GetIdentityByCriteriaCommand : IRequest<ApiResponse<IdentityItemDto>>
    {
        [JsonPropertyName("filter_IdentityCode")]
        public string? FilterIdentityCode { get; set; }

        [JsonPropertyName("filter_IdentityName")]
        public string? FilterIdentityName { get; set; }

    }
}

