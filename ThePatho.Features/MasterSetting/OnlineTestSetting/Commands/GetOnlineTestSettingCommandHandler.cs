using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;
using ThePatho.Features.MasterSetting.OnlineTestSetting.Service;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class GetOnlineTestSettingCommandHandler : IRequestHandler<GetOnlineTestSettingCommand, NewApiResponse<OnlineTestSettingItemDto>>
    {
        private readonly IOnlineTestSettingService onlineTestSettingService;

        public GetOnlineTestSettingCommandHandler(IOnlineTestSettingService _onlineTestSettingService)
        {
            onlineTestSettingService = _onlineTestSettingService;
        }

        public async Task<NewApiResponse<OnlineTestSettingItemDto>> Handle(GetOnlineTestSettingCommand request, CancellationToken cancellationToken)
        {
            return await onlineTestSettingService.GetOnlineTestSetting(request);
        }
    }
}
