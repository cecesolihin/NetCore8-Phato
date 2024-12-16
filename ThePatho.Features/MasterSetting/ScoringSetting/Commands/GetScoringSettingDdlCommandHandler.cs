using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Features.MasterData.AdsCategory.Commands;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.Service;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;
using ThePatho.Features.MasterSetting.ScoringSetting.Service;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class GetScoringSettingDdlCommandHandler : IRequestHandler<GetScoringSettingDdlCommand, ScoringSettingItemDto>
    {
        private readonly IScoringSettingService ScoringSettingService;

        public GetScoringSettingDdlCommandHandler(IScoringSettingService _ScoringSetting)
        {
            ScoringSettingService = _ScoringSetting;
        }

        public async Task<ScoringSettingItemDto> Handle(GetScoringSettingDdlCommand request, CancellationToken cancellationToken)
        {
            var ScoringSetting = await ScoringSettingService.GetScoringSettingDdl(request);

            return new ScoringSettingItemDto
            {
                DataOfRecords = ScoringSetting.Count,
                ScoringSettingList = ScoringSetting
            };
        }
    }
}
