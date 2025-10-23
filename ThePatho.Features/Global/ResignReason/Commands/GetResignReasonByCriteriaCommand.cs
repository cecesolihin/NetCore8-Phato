using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ResignReason.DTO;

namespace ThePatho.Features.Global.ResignReason.Commands
{
    public class GetResignReasonByCriteriaCommand : IRequest<ApiResponse<ResignReasonItemDto>>
    {
        [JsonPropertyName("filter_ResignReasonName")]
        public string? FilterResignReasonName { get; set; }

        [JsonPropertyName("filter_ResignReasonCode")]
        public string? FilterResignReasonCode { get; set; }

    }
}
