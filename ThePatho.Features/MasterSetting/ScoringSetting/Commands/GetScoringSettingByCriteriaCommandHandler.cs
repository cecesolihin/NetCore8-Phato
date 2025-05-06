using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;
using ThePatho.Features.MasterSetting.ScoringSetting.Service;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class GetScoringSettingByCriteriaCommandHandler : IRequestHandler<GetScoringSettingByCriteriaCommand, ApiResponse<ScoringSettingDto>>
    {
        private readonly IScoringSettingService scoringSettingService;

        public GetScoringSettingByCriteriaCommandHandler(IScoringSettingService _scoringSettingService)
        {
            scoringSettingService = _scoringSettingService;
        }

        public async Task<ApiResponse<ScoringSettingDto>> Handle(GetScoringSettingByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await scoringSettingService.GetScoringSettingByCriteria(request);

        }
    }
}
