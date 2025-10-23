using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeReward.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeReward.Commands
{
    public class GetEmployeeRewardByCriteriaCommand : IRequest<ApiResponse<EmployeeRewardItemDto>>
    {
        [JsonPropertyName("filter_employee_id")]
        public int? FilterEmployeeId { get; set; }
        [JsonPropertyName("filter_letter_no")]
        public string? FilterLetterNo { get; set; }

        [JsonPropertyName("filter_reward_type_code")]
        public string? FilterRewardTypeCode { get; set; }
    }
}

