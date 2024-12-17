using MediatR;

using ThePatho.Features.MasterSetting.ScoringSetting.DTO;
using ThePatho.Features.MasterSetting.ScoringSetting.Service;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class GetScoringSettingCommandHandler : IRequestHandler<GetScoringSettingCommand, ScoringSettingItemDto>
    {
        private readonly IScoringSettingService scoringSettingService;

        public GetScoringSettingCommandHandler(IScoringSettingService _scoringSettingService)
        {
            scoringSettingService = _scoringSettingService;
        }

        public async Task<ScoringSettingItemDto> Handle(GetScoringSettingCommand request, CancellationToken cancellationToken)
        {
            var data = await scoringSettingService.GetScoringSetting(request);

            return new ScoringSettingItemDto
            {
                DataOfRecords = data.Count,
                ScoringSettingList = data
            };
        }
    }
}
