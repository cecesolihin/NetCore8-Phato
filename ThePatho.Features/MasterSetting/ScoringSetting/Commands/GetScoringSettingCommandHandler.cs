using MediatR;

using ThePatho.Features.MasterSetting.ScoringSetting.DTO;
using ThePatho.Features.MasterSetting.ScoringSetting.Service;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class GetScoringSettingCommandHandler : IRequestHandler<GetScoringSettingCommand, ScoringSettingItemDto>
    {
        private readonly IScoringSettingService ScoringSettingService;

        public GetScoringSettingCommandHandler(IScoringSettingService _ScoringSettingService)
        {
            ScoringSettingService = _ScoringSettingService;
        }

        public async Task<ScoringSettingItemDto> Handle(GetScoringSettingCommand request, CancellationToken cancellationToken)
        {
            var ScoringSettings = await ScoringSettingService.GetScoringSetting(request);

            return new ScoringSettingItemDto
            {
                DataOfRecords = ScoringSettings.Count,
                ScoringSettingList = ScoringSettings
            };
        }
    }
}
