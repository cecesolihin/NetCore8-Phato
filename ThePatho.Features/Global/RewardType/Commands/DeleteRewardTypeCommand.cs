using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.RewardType.Commands
{
    public class DeleteRewardTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("reward_type_code")]
        public string RewardTypeCode { get; set; } = null!;
    }
}
