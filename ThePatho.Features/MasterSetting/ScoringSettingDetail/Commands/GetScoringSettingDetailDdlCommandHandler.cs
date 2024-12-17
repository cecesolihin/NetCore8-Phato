using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Features.MasterData.AdsCategory.Commands;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.Service;
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
