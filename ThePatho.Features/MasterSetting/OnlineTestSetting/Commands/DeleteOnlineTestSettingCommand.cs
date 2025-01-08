using MediatR;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class DeleteOnlineTestSettingCommand : IRequest<bool>
    {
        public string OnlineTestSettingCode { get; set; }

        public DeleteOnlineTestSettingCommand(string onlineTestSettingCode)
        {
            OnlineTestSettingCode = onlineTestSettingCode;
        }
    }
}
