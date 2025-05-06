using MediatR;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class GetScoringSettingDetailByCriteriaCommandHandler : IRequestHandler<GetScoringSettingDetailByCriteriaCommand, ApiResponse<ScoringSettingDetailItemDto>>
    {
        private readonly IScoringSettingDetailService scoringSettingDetailService;

        public GetScoringSettingDetailByCriteriaCommandHandler(IScoringSettingDetailService _scoringSettingDetailService)
        {
            scoringSettingDetailService = _scoringSettingDetailService;
        }

        public async Task<ApiResponse<ScoringSettingDetailItemDto>> Handle(GetScoringSettingDetailByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await scoringSettingDetailService.GetScoringSettingDetailByCriteria(request);

        }
    }
}
