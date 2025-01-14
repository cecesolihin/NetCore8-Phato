using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class DeleteOnlineTestSettingCommand : IRequest<bool>
    {
        [JsonPropertyName("online_test_code")]
        public string OnlineTestSettingCode { get; set; }

        public DeleteOnlineTestSettingCommand(string onlineTestSettingCode)
        {
            OnlineTestSettingCode = onlineTestSettingCode;
        }
    }
}
