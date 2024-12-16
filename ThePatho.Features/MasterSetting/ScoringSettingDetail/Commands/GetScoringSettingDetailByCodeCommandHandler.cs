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
    public class GetScoringSettingDetailByCodeCommandHandler : IRequestHandler<GetScoringSettingDetailByCodeCommand, ScoringSettingDetailDto>
    {
        private readonly IScoringSettingDetailService ScoringSettingDetailService;

        public GetScoringSettingDetailByCodeCommandHandler(IScoringSettingDetailService _ScoringSettingDetailService)
        {
            ScoringSettingDetailService = _ScoringSettingDetailService;
        }

        public async Task<ScoringSettingDetailDto> Handle(GetScoringSettingDetailByCodeCommand request, CancellationToken cancellationToken)
        {
            var ScoringSettingDetail = await ScoringSettingDetailService.GetScoringSettingDetailByCode(request);

            return ScoringSettingDetail;
        }
    }
}
