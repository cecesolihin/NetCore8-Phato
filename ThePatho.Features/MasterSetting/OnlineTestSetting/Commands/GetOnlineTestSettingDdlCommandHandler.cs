using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;
using ThePatho.Features.MasterSetting.OnlineTestSetting.Service;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class GetOnlineTestSettingDdlCommandHandler : IRequestHandler<GetOnlineTestSettingDdlCommand, NewApiResponse<OnlineTestSettingItemDto>>
    {
        private readonly IOnlineTestSettingService onlineTestSettingService;

        public GetOnlineTestSettingDdlCommandHandler(IOnlineTestSettingService _onlineTestSetting)
        {
            onlineTestSettingService = _onlineTestSetting;
        }

        public async Task<NewApiResponse<OnlineTestSettingItemDto>> Handle(GetOnlineTestSettingDdlCommand request, CancellationToken cancellationToken)
        {
            return await onlineTestSettingService.GetOnlineTestSettingDdl(request);
        }
    }
}
