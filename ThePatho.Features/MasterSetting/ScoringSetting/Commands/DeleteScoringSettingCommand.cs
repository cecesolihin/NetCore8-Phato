using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class DeleteScoringSettingCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("scoring_code")]
        public string ScoringCode { get; set; }

        public DeleteScoringSettingCommand(string scoringCode)
        {
            ScoringCode = scoringCode;
        }
    }
}
