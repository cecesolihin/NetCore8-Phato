
using MediatR;
using ThePatho.Features.MasterSetting.ScoringSetting.Service;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class DeleteScoringSettingCommandHandler : IRequestHandler<DeleteScoringSettingCommand, bool>
    {
        private readonly IScoringSettingService scoringSettingService;

        public DeleteScoringSettingCommandHandler(IScoringSettingService _scoringSettingService)
        {
            scoringSettingService = _scoringSettingService;
        }

        public async Task<bool> Handle(DeleteScoringSettingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await scoringSettingService.DeleteScoringSetting(request);
                return true;
            }
            catch
            {
                // Log the error here if needed
                return false;
            }
        }
    }

}
