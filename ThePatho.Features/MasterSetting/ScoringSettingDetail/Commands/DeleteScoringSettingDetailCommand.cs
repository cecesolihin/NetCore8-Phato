using MediatR;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class DeleteScoringSettingDetailCommand : IRequest<bool>
    {
        public string ScoringCode { get; set; }
        public string Character { get; set; } 

        public DeleteScoringSettingDetailCommand(string scoringCode, string character)
        {
            ScoringCode = scoringCode;
            Character = character;
        }
    }
}
