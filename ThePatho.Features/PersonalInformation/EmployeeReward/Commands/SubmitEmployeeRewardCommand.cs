using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeReward.Commands
{
    public class SubmitEmployeeRewardCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("emRewardId")]
        public int? EmRewardId { get; set; }

        [JsonPropertyName("letterNo")]
        public string LetterNo { get; set; } = null!;

        [JsonPropertyName("employeeId")]
        public List<int> EmployeeId { get; set; }

        [JsonPropertyName("letterDate")]
        public string LetterDate { get; set; } = null!;

        [JsonPropertyName("rewardTypeCode")]
        public string RewardTypeCode { get; set; } = null!;

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("currencyCode")]
        public string CurrencyCode { get; set; } = null!;

        [JsonPropertyName("amount")]
        public decimal? Amount { get; set; }

        [JsonPropertyName("attachment")]
        public string? Attachment { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

