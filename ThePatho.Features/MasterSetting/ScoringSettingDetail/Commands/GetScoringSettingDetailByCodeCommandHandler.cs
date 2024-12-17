using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class GetScoringSettingDetailByCodeCommandHandler : IRequestHandler<GetScoringSettingDetailByCodeCommand, ScoringSettingDetailItemDto>
    {
        private readonly IScoringSettingDetailService scoringSettingDetailService;

        public GetScoringSettingDetailByCodeCommandHandler(IScoringSettingDetailService _scoringSettingDetailService)
        {
            scoringSettingDetailService = _scoringSettingDetailService;
        }

        public async Task<ScoringSettingDetailItemDto> Handle(GetScoringSettingDetailByCodeCommand request, CancellationToken cancellationToken)
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
