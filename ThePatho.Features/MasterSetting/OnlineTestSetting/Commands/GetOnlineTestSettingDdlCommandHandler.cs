using MediatR;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;
using ThePatho.Features.MasterSetting.OnlineTestSetting.Service;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class GetOnlineTestSettingDdlCommandHandler : IRequestHandler<GetOnlineTestSettingDdlCommand, OnlineTestSettingItemDto>
    {
        private readonly IOnlineTestSettingService onlineTestSettingService;

        public GetOnlineTestSettingDdlCommandHandler(IOnlineTestSettingService _onlineTestSetting)
        {
            onlineTestSettingService = _onlineTestSetting;
        }

        public async Task<OnlineTestSettingItemDto> Handle(GetOnlineTestSettingDdlCommand request, CancellationToken cancellationToken)
        {
            var data = await onlineTestSettingService.GetOnlineTestSettingDdl(request);

            return new OnlineTestSettingItemDto
            {
                DataOfRecords = data.Count,
                OnlineTestSettingList = data
            };
        }
    }
}
