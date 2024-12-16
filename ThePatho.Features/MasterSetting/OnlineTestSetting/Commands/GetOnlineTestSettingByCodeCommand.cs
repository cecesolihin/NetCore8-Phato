using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class GetOnlineTestSettingByCodeCommand : IRequest<OnlineTestSettingDto>
    {
        [JsonPropertyName("filter_OnlineTestCode")]
        public string? FilterOnlineTestCode { get; set; }
    }
}
