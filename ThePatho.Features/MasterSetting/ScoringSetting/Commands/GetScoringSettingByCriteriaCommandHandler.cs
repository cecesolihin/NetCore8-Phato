using MediatR;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;
using ThePatho.Features.MasterSetting.ScoringSetting.Service;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class GetScoringSettingByCriteriaCommandHandler : IRequestHandler<GetScoringSettingByCriteriaCommand, ScoringSettingDto>
    {
        private readonly IScoringSettingService scoringSettingService;

        public GetScoringSettingByCriteriaCommandHandler(IScoringSettingService _scoringSettingService)
        {
            scoringSettingService = _scoringSettingService;
        }

        public async Task<ScoringSettingDto> Handle(GetScoringSettingByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await scoringSettingService.GetScoringSettingByCriteria(request);

            return data;
        }
    }
}
