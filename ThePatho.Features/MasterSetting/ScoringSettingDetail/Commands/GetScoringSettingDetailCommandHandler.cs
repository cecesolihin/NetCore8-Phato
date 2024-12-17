using MediatR;

using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class GetScoringSettingDetailCommandHandler : IRequestHandler<GetScoringSettingDetailCommand, ScoringSettingDetailItemDto>
    {
        private readonly IScoringSettingDetailService scoringSettingDetailService;

        public GetScoringSettingDetailCommandHandler(IScoringSettingDetailService _scoringSettingDetailService)
        {
            scoringSettingDetailService = _scoringSettingDetailService;
        }

        public async Task<ScoringSettingDetailItemDto> Handle(GetScoringSettingDetailCommand request, CancellationToken cancellationToken)
        {
            var data = await scoringSettingDetailService.GetScoringSettingDetail(request);

            return new ScoringSettingDetailItemDto
            {
                DataOfRecords = data.Count,
                ScoringSettingDetailList = data
            };
        }
    }
}
