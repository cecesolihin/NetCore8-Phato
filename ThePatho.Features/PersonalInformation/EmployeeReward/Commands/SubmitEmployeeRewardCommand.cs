using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeReward.Commands
{
    public class SubmitEmployeeRewardCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("em_reward_id")]
        public int? EmRewardId { get; set; }

        [JsonPropertyName("letter_no")]
        public string LetterNo { get; set; } = null!;

        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("letter_date")]
        public string LetterDate { get; set; } = null!;

        [JsonPropertyName("reward_type_code")]
        public string RewardTypeCode { get; set; } = null!;

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; } = null!;

        [JsonPropertyName("amount")]
        public decimal? Amount { get; set; }

        [JsonPropertyName("attachment")]
        public string? Attachment { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

