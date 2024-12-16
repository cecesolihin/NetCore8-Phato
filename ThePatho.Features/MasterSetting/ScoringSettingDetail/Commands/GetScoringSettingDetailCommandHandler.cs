using MediatR;

using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class GetScoringSettingDetailCommandHandler : IRequestHandler<GetScoringSettingDetailCommand, ScoringSettingDetailItemDto>
    {
        private readonly IScoringSettingDetailService ScoringSettingDetailService;

        public GetScoringSettingDetailCommandHandler(IScoringSettingDetailService _ScoringSettingDetailService)
        {
            ScoringSettingDetailService = _ScoringSettingDetailService;
        }

        public async Task<ScoringSettingDetailItemDto> Handle(GetScoringSettingDetailCommand request, CancellationToken cancellationToken)
        {
            var ScoringSettingDetails = await ScoringSettingDetailService.GetScoringSettingDetail(request);

            return new ScoringSettingDetailItemDto
            {
                DataOfRecords = ScoringSettingDetails.Count,
                ScoringSettingDetailList = ScoringSettingDetails
            };
        }
    }
}
