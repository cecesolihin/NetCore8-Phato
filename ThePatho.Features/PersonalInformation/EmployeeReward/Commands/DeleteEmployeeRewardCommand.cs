using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeReward.Commands
{
    public class DeleteEmployeeRewardCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("em_reward_id")]
        public int EmRewardId { get; set; }
    }
}

