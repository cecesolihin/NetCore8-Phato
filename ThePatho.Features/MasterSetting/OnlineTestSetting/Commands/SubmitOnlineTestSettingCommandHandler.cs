using MediatR;
using ThePatho.Features.MasterSetting.OnlineTestSetting.Service;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class SubmitOnlineTestSettingCommandHandler : IRequestHandler<SubmitOnlineTestSettingCommand, string>
    {
        private readonly IOnlineTestSettingService onlineTestSettingService;

        public SubmitOnlineTestSettingCommandHandler(IOnlineTestSettingService _onlineTestSettingService)
        {
            onlineTestSettingService = _onlineTestSettingService;
        }

        public async Task<string> Handle(SubmitOnlineTestSettingCommand request, CancellationToken cancellationToken)
        {
            await onlineTestSettingService.SubmitOnlineTestSetting(request);
            if (request.Action == "ADD")
            {
                return "Online Test Setting successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Online Test Setting successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
