using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;
using ThePatho.Features.MasterSetting.ScoringSetting.Service;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class GetScoringSettingByCriteriaCommandHandler : IRequestHandler<GetScoringSettingByCriteriaCommand, NewApiResponse<ScoringSettingDto>>
    {
        private readonly IScoringSettingService scoringSettingService;

        public GetScoringSettingByCriteriaCommandHandler(IScoringSettingService _scoringSettingService)
        {
            scoringSettingService = _scoringSettingService;
        }

        public async Task<NewApiResponse<ScoringSettingDto>> Handle(GetScoringSettingByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await scoringSettingService.GetScoringSettingByCriteria(request);

        }
    }
}
