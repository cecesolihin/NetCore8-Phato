using MediatR;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class GetScoringSettingDetailByCriteriaCommandHandler : IRequestHandler<GetScoringSettingDetailByCriteriaCommand, ScoringSettingDetailItemDto>
    {
        private readonly IScoringSettingDetailService scoringSettingDetailService;

        public GetScoringSettingDetailByCriteriaCommandHandler(IScoringSettingDetailService _scoringSettingDetailService)
        {
            scoringSettingDetailService = _scoringSettingDetailService;
        }

        public async Task<ScoringSettingDetailItemDto> Handle(GetScoringSettingDetailByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await scoringSettingDetailService.GetScoringSettingDetailByCode(request);

            return new ScoringSettingDetailItemDto
            {
                DataOfRecords = data.Count,
                ScoringSettingDetailList = data
            };
        }
    }
}
