using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class GetScoringSettingDetailDdlCommandHandler : IRequestHandler<GetScoringSettingDetailDdlCommand, NewApiResponse<ScoringSettingDetailItemDto>>
    {
        private readonly IScoringSettingDetailService scoringSettingDetailService;

        public GetScoringSettingDetailDdlCommandHandler(IScoringSettingDetailService _scoringSettingDetailService)
        {
            scoringSettingDetailService = _scoringSettingDetailService;
        }

        public async Task<NewApiResponse<ScoringSettingDetailItemDto>> Handle(GetScoringSettingDetailDdlCommand request, CancellationToken cancellationToken)
        {
            return await scoringSettingDetailService.GetScoringSettingDetailDdl(request);

        }
    }
}
