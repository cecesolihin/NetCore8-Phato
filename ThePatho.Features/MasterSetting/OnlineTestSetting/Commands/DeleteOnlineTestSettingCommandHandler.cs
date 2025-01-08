
using MediatR;
using ThePatho.Features.MasterSetting.OnlineTestSetting.Service;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class DeleteOnlineTestSettingCommandHandler : IRequestHandler<DeleteOnlineTestSettingCommand, bool>
    {
        private readonly IOnlineTestSettingService onlineTestSettingService;

        public DeleteOnlineTestSettingCommandHandler(IOnlineTestSettingService _onlineTestSettingService)
        {
            onlineTestSettingService = _onlineTestSettingService;
        }

        public async Task<bool> Handle(DeleteOnlineTestSettingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await onlineTestSettingService.DeleteOnlineTestSetting(request);
                return true;
            }
            catch
            {
                // Log the error here if needed
                return false;
            }
        }
    }

}
