using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeReward.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeReward.Commands
{
    public class GetEmployeeRewardByCriteriaCommand : IRequest<ApiResponse<EmployeeRewardItemDto>>
    {
        [JsonPropertyName("employeeId")]
        public int? EmployeeId { get; set; }
        [JsonPropertyName("letterNo")]
        public string? LetterNo { get; set; }

        [JsonPropertyName("rewardTypeCode")]
        public string? RewardTypeCode { get; set; }
    }
}

