using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Identity.DTO;

namespace ThePatho.Features.Global.Identity.Commands
{
    public class GetSingleIdentityCommand : IRequest<ApiResponse<IdentityDto>>
    {
        [JsonPropertyName("filter_IdentityCode")]
        public string FilterIdentityCode { get; set; }

    }
}
