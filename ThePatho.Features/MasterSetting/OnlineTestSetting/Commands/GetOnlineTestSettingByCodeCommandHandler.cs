using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Features.MasterData.AdsCategory.Commands;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.Service;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;
using ThePatho.Features.MasterSetting.OnlineTestSetting.Service;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class GetOnlineTestSettingByCodeCommandHandler : IRequestHandler<GetOnlineTestSettingByCodeCommand, OnlineTestSettingDto>
    {
        private readonly IOnlineTestSettingService onlineTestSettingService;

        public GetOnlineTestSettingByCodeCommandHandler(IOnlineTestSettingService _onlineTestSettingService)
        {
            onlineTestSettingService = _onlineTestSettingService;
        }

        public async Task<OnlineTestSettingDto> Handle(GetOnlineTestSettingByCodeCommand request, CancellationToken cancellationToken)
        {
            var onlineTestSetting = await onlineTestSettingService.GetOnlineTestSettingByCode(request);

            return onlineTestSetting;
        }
    }
}
