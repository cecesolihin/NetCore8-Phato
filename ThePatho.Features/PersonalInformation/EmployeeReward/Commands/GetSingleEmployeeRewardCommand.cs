using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeReward.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeReward.Commands
{
    public class GetSingleEmployeeRewardCommand : IRequest<ApiResponse<EmployeeRewardDto>>
    {
        [JsonPropertyName("EmRewardId")]
        public int EmRewardId { get; set; }

    }
}
