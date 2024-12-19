﻿using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class GetOnlineTestSettingByCriteriaCommand : IRequest<OnlineTestSettingDto>
    {
        [JsonPropertyName("filter_OnlineTestCode")]
        public string? FilterOnlineTestCode { get; set; }
    }
}