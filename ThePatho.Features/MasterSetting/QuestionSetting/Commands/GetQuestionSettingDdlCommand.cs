﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;
using ThePatho.Features.MasterSetting.QuestionSetting.DTO;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class GetQuestionSettingDdlCommand : IRequest<QuestionSettingItemDto>
    {
        [JsonPropertyName("filter_QuestionCode")]
        public string? FilterQuestionCode { get; set; }
    }
}
