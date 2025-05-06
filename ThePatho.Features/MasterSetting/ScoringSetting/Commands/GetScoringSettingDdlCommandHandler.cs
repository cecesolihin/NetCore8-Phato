using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;
using ThePatho.Features.MasterSetting.ScoringSetting.Service;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class GetScoringSettingDdlCommandHandler : IRequestHandler<GetScoringSettingDdlCommand, ApiResponse<ScoringSettingItemDto>>
    {
        private readonly IScoringSettingService scoringSettingService;

        public GetScoringSettingDdlCommandHandler(IScoringSettingService _ScoringSettingService)
        {
            scoringSettingService = _ScoringSettingService;
        }

        public async Task<ApiResponse<ScoringSettingItemDto>> Handle(GetScoringSettingDdlCommand request, CancellationToken cancellationToken)
        {
            return await scoringSettingService.GetScoringSettingDdl(request);

        }
    }
}
