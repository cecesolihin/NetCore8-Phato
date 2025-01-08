using MediatR;
using ThePatho.Features.MasterSetting.ScoringSetting.Service;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class SubmitScoringSettingCommandHandler : IRequestHandler<SubmitScoringSettingCommand, string>
    {
        private readonly IScoringSettingService scoringSettingService;

        public SubmitScoringSettingCommandHandler(IScoringSettingService _scoringSettingService)
        {
            scoringSettingService = _scoringSettingService;
        }

        public async Task<string> Handle(SubmitScoringSettingCommand request, CancellationToken cancellationToken)
        {
            await scoringSettingService.SubmitScoringSetting(request);
            if (request.Action == "ADD")
            {
                return "Scoring Setting successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Scoring Setting successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
