using MediatR;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class SubmitScoringSettingDetailCommand : IRequest<ApiResponse>
    {
        [JsonProperty("scoring_code")]
        public string ScoringCode { get; set; } // Required

        [JsonProperty("value")]
        public decimal Value { get; set; }

        [JsonProperty("character")]
        public string Character { get; set; }

        [JsonProperty("attachment")]
        public string Attachment { get; set; }

        [JsonProperty("text_value")]
        public string TextValue { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }
}
