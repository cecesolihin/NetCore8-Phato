
using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.OnlineTestSetting.Service;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class DeleteOnlineTestSettingCommandHandler : IRequestHandler<DeleteOnlineTestSettingCommand, ApiResponse>
    {
        private readonly IOnlineTestSettingService onlineTestSettingService;

        public DeleteOnlineTestSettingCommandHandler(IOnlineTestSettingService _onlineTestSettingService)
        {
            onlineTestSettingService = _onlineTestSettingService;
        }

        public async Task<ApiResponse> Handle(DeleteOnlineTestSettingCommand request, CancellationToken cancellationToken)
        {
            return await onlineTestSettingService.DeleteOnlineTestSetting(request);
        }
    }

}
