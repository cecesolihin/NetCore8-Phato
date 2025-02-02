using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class DeleteOnlineTestSettingCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("online_test_code")]
        public string OnlineTestSettingCode { get; set; }

        public DeleteOnlineTestSettingCommand(string onlineTestSettingCode)
        {
            OnlineTestSettingCode = onlineTestSettingCode;
        }
    }
}
