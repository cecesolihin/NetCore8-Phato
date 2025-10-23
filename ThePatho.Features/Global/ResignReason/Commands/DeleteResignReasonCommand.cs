using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.ResignReason.Commands
{
    public class DeleteResignReasonCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("resign_reason_code")]
        public string ResignReasonCode { get; set; } = null!;
    }
}
