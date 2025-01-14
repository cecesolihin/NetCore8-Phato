using MediatR;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class SubmitScoringSettingCommand : IRequest<string>
    {
        [JsonProperty("scoring_code")]
        public string ScoringCode { get; set; }

        [JsonProperty("max_value")]
        public decimal? MaxValue { get; set; }

        [JsonProperty("min_value")]
        public decimal MinValue { get; set; }

        [JsonProperty("numerical_type")]
        public bool? NumericalType { get; set; }

        [JsonProperty("scoring_name")]
        public string ScoringName { get; set; }

        [JsonProperty("scoring_type")]
        public int ScoringType { get; set; }

        [JsonProperty("remark")]
        public string Remark { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }
}
