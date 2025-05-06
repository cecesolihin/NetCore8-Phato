using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.OnlineTestSetting.Service;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class SubmitOnlineTestSettingCommandHandler : IRequestHandler<SubmitOnlineTestSettingCommand, ApiResponse>
    {
        private readonly IOnlineTestSettingService onlineTestSettingService;

        public SubmitOnlineTestSettingCommandHandler(IOnlineTestSettingService _onlineTestSettingService)
        {
            onlineTestSettingService = _onlineTestSettingService;
        }

        public async Task<ApiResponse> Handle(SubmitOnlineTestSettingCommand request, CancellationToken cancellationToken)
        {
           return await onlineTestSettingService.SubmitOnlineTestSetting(request);
        }
    }
}
