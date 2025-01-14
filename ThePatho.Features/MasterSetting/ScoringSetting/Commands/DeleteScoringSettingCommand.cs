using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class DeleteScoringSettingCommand : IRequest<bool>
    {
        [JsonPropertyName("scoring_code")]
        public string ScoringCode { get; set; }

        public DeleteScoringSettingCommand(string scoringCode)
        {
            ScoringCode = scoringCode;
        }
    }
}
