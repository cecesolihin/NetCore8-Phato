using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class GetOnlineTestSettingDdlCommand : IRequest<OnlineTestSettingItemDto>
    {
        [JsonPropertyName("filter_RecruitmentRequestNo")]
        public string? FilterRecruitmentRequestNo { get; set; }
    }
}
