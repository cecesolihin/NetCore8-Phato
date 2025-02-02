
using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.ScoringSetting.Service;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class DeleteScoringSettingCommandHandler : IRequestHandler<DeleteScoringSettingCommand, ApiResponse>
    {
        private readonly IScoringSettingService scoringSettingService;

        public DeleteScoringSettingCommandHandler(IScoringSettingService _scoringSettingService)
        {
            scoringSettingService = _scoringSettingService;
        }

        public async Task<ApiResponse> Handle(DeleteScoringSettingCommand request, CancellationToken cancellationToken)
        {
             return await scoringSettingService.DeleteScoringSetting(request);
        }
    }

}
