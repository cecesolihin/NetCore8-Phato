using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RewardType.DTO;

namespace ThePatho.Features.Global.RewardType.Commands
{
    public class GetSingleRewardTypeCommand : IRequest<ApiResponse<RewardTypeDto>>
    {
        [JsonPropertyName("filter_RewardTypeCode")]
        public string FilterRewardTypeCode { get; set; } = null!;
    }
}
