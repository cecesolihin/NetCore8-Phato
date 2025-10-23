using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.RewardType.Commands
{
    public class SubmitRewardTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("reward_type_code")]
        public string RewardTypeCode { get; set; } = null!;

        [JsonPropertyName("reward_type_name")]
        public string RewardTypeName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
