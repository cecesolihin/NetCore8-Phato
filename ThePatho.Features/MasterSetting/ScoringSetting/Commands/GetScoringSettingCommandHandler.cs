using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;
using ThePatho.Features.MasterSetting.ScoringSetting.Service;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class GetScoringSettingCommandHandler : IRequestHandler<GetScoringSettingCommand, NewApiResponse<ScoringSettingItemDto>>
    {
        private readonly IScoringSettingService scoringSettingService;

        public GetScoringSettingCommandHandler(IScoringSettingService _scoringSettingService)
        {
            scoringSettingService = _scoringSettingService;
        }

        public async Task<NewApiResponse<ScoringSettingItemDto>> Handle(GetScoringSettingCommand request, CancellationToken cancellationToken)
        {
            return await scoringSettingService.GetScoringSetting(request);
        }
    }
}
