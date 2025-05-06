using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class DeleteScoringSettingDetailCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("scoring_code")]
        public string ScoringCode { get; set; }
        [JsonPropertyName("character")]
        public string Character { get; set; } 

        public DeleteScoringSettingDetailCommand(string scoringCode, string character)
        {
            ScoringCode = scoringCode;
            Character = character;
        }
    }
}
