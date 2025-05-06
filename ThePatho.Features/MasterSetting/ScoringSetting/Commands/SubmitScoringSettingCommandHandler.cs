using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.ScoringSetting.Service;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class SubmitScoringSettingCommandHandler : IRequestHandler<SubmitScoringSettingCommand, ApiResponse>
    {
        private readonly IScoringSettingService scoringSettingService;

        public SubmitScoringSettingCommandHandler(IScoringSettingService _scoringSettingService)
        {
            scoringSettingService = _scoringSettingService;
        }

        public async Task<ApiResponse> Handle(SubmitScoringSettingCommand request, CancellationToken cancellationToken)
        {
            return await scoringSettingService.SubmitScoringSetting(request);
        }
    }
}
