using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ThePatho.Features.MasterSetting.ScoringSetting.DTO;
using ThePatho.Features.MasterSetting.ScoringSetting.Service;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class GetScoringSettingByCodeCommandHandler : IRequestHandler<GetScoringSettingByCodeCommand, ScoringSettingDto>
    {
        private readonly IScoringSettingService ScoringSettingService;

        public GetScoringSettingByCodeCommandHandler(IScoringSettingService _ScoringSettingService)
        {
            ScoringSettingService = _ScoringSettingService;
        }

        public async Task<ScoringSettingDto> Handle(GetScoringSettingByCodeCommand request, CancellationToken cancellationToken)
        {
            var ScoringSetting = await ScoringSettingService.GetScoringSettingByCode(request);

            return ScoringSetting;
        }
    }
}
