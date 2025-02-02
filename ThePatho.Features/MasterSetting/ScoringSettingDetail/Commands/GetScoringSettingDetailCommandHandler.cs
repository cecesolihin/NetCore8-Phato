using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class GetScoringSettingDetailCommandHandler : IRequestHandler<GetScoringSettingDetailCommand, NewApiResponse<ScoringSettingDetailItemDto>>
    {
        private readonly IScoringSettingDetailService scoringSettingDetailService;

        public GetScoringSettingDetailCommandHandler(IScoringSettingDetailService _scoringSettingDetailService)
        {
            scoringSettingDetailService = _scoringSettingDetailService;
        }

        public async Task<NewApiResponse<ScoringSettingDetailItemDto>> Handle(GetScoringSettingDetailCommand request, CancellationToken cancellationToken)
        {
            return await scoringSettingDetailService.GetScoringSettingDetail(request);
        }
    }
}
