using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class SubmitScoringSettingDetailCommandHandler : IRequestHandler<SubmitScoringSettingDetailCommand, ApiResponse>
    {
        private readonly IScoringSettingDetailService scoringSettingDetailService;

        public SubmitScoringSettingDetailCommandHandler(IScoringSettingDetailService _scoringSettingDetailService)
        {
            scoringSettingDetailService = _scoringSettingDetailService;
        }

        public async Task<ApiResponse> Handle(SubmitScoringSettingDetailCommand request, CancellationToken cancellationToken)
        {
            return await scoringSettingDetailService.SubmitScoringSettingDetail(request);
        }
    }
}
