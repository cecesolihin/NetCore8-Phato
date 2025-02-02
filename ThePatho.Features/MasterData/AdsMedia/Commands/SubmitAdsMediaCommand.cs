using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.MasterData.AdsMedia.Commands
{
    public class SubmitAdsMediaCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("adsMediaCode")]
        public string AdsMediaCode { get; set; }

        [JsonPropertyName("adsMediaName")]
        public string AdsMediaName { get; set; }

        [JsonPropertyName("adsCategoryCode")]
        public string AdsCategoryCode { get; set; }

        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [JsonPropertyName("contactPerson")]
        public string? ContactPerson { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("useRecruitmentFee")]
        public bool UseRecruitmentFee { get; set; }

        [JsonPropertyName("recruitmentFee")]
        public string? RecruitmentFee { get; set; }

        [JsonPropertyName("recruitmentFee2")]
        public string? RecruitmentFee2 { get; set; }

        [JsonPropertyName("recruitmentFee3")]
        public string? RecruitmentFee3 { get; set; }

        [JsonPropertyName("action")]
        public string? Action { get; set; }
    }
}
