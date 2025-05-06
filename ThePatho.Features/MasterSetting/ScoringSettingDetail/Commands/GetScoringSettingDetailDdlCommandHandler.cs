using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class GetScoringSettingDetailDdlCommandHandler : IRequestHandler<GetScoringSettingDetailDdlCommand, ApiResponse<ScoringSettingDetailItemDto>>
    {
        private readonly IScoringSettingDetailService scoringSettingDetailService;

        public GetScoringSettingDetailDdlCommandHandler(IScoringSettingDetailService _scoringSettingDetailService)
        {
            scoringSettingDetailService = _scoringSettingDetailService;
        }

        public async Task<ApiResponse<ScoringSettingDetailItemDto>> Handle(GetScoringSettingDetailDdlCommand request, CancellationToken cancellationToken)
        {
            return await scoringSettingDetailService.GetScoringSettingDetailDdl(request);

        }
    }
}
