using MediatR;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class GetScoringSettingDetailDdlCommandHandler : IRequestHandler<GetScoringSettingDetailDdlCommand, ScoringSettingDetailItemDto>
    {
        private readonly IScoringSettingDetailService scoringSettingDetailService;

        public GetScoringSettingDetailDdlCommandHandler(IScoringSettingDetailService _scoringSettingDetailService)
        {
            scoringSettingDetailService = _scoringSettingDetailService;
        }

        public async Task<ScoringSettingDetailItemDto> Handle(GetScoringSettingDetailDdlCommand request, CancellationToken cancellationToken)
        {
            var data = await scoringSettingDetailService.GetScoringSettingDetailDdl(request);

            return new ScoringSettingDetailItemDto
            {
                DataOfRecords = data.Count,
                ScoringSettingDetailList = data
            };
        }
    }
}
