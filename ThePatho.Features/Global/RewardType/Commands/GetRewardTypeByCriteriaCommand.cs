using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RewardType.DTO;

namespace ThePatho.Features.Global.RewardType.Commands
{
    public class GetRewardTypeByCriteriaCommand : IRequest<ApiResponse<RewardTypeItemDto>>
    {
        [JsonPropertyName("rewardTypeName")]
        public string? RewardTypeName { get; set; }

        [JsonPropertyName("rewardTypeCode")]
        public string? RewardTypeCode { get; set; }

    }
}
