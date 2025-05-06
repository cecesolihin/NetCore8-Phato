using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;
using ThePatho.Features.MasterSetting.ScoringSetting.Service;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class GetScoringSettingCommandHandler : IRequestHandler<GetScoringSettingCommand, ApiResponse<ScoringSettingItemDto>>
    {
        private readonly IScoringSettingService scoringSettingService;

        public GetScoringSettingCommandHandler(IScoringSettingService _scoringSettingService)
        {
            scoringSettingService = _scoringSettingService;
        }

        public async Task<ApiResponse<ScoringSettingItemDto>> Handle(GetScoringSettingCommand request, CancellationToken cancellationToken)
        {
            return await scoringSettingService.GetScoringSetting(request);
        }
    }
}
