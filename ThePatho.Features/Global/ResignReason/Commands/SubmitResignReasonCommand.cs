using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.ResignReason.Commands
{
    public class SubmitResignReasonCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("resign_reason_code")]
        public string ResignReasonCode { get; set; } = null!;

        [JsonPropertyName("resign_reason_name")]
        public string ResignReasonName { get; set; } = null!;

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
