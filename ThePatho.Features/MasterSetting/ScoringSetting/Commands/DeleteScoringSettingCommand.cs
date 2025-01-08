using MediatR;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class DeleteScoringSettingCommand : IRequest<bool>
    {
        public string ScoringCode { get; set; }

        public DeleteScoringSettingCommand(string scoringCode)
        {
            ScoringCode = scoringCode;
        }
    }
}
