using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeReward.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeReward.Commands
{
    public class GetSingleEmployeeRewardCommand : IRequest<ApiResponse<EmployeeRewardDto>>
    {
        [JsonPropertyName("filter_em_reward_id")]
        public int FilterEmRewardId { get; set; }

    }
}
