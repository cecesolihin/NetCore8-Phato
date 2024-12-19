using MediatR;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;
using ThePatho.Features.MasterSetting.ScoringSetting.Service;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class GetScoringSettingDdlCommandHandler : IRequestHandler<GetScoringSettingDdlCommand, ScoringSettingItemDto>
    {
        private readonly IScoringSettingService scoringSettingService;

        public GetScoringSettingDdlCommandHandler(IScoringSettingService _ScoringSettingService)
        {
            scoringSettingService = _ScoringSettingService;
        }

        public async Task<ScoringSettingItemDto> Handle(GetScoringSettingDdlCommand request, CancellationToken cancellationToken)
        {
            var data = await scoringSettingService.GetScoringSettingDdl(request);

            return new ScoringSettingItemDto
            {
                DataOfRecords = data.Count,
                ScoringSettingList = data
            };
        }
    }
}
