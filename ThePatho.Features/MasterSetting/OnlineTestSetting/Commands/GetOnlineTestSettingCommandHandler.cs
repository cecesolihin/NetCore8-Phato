using MediatR;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;
using ThePatho.Features.MasterSetting.OnlineTestSetting.Service;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class GetOnlineTestSettingCommandHandler : IRequestHandler<GetOnlineTestSettingCommand, OnlineTestSettingItemDto>
    {
        private readonly IOnlineTestSettingService onlineTestSettingService;

        public GetOnlineTestSettingCommandHandler(IOnlineTestSettingService _onlineTestSettingService)
        {
            onlineTestSettingService = _onlineTestSettingService;
        }

        public async Task<OnlineTestSettingItemDto> Handle(GetOnlineTestSettingCommand request, CancellationToken cancellationToken)
        {
            var data = await onlineTestSettingService.GetOnlineTestSetting(request);

            return new OnlineTestSettingItemDto
            {
                DataOfRecords = data.Count,
                OnlineTestSettingList = data
            };
        }
    }
}
