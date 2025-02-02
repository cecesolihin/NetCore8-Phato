using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class GetOnlineTestSettingDdlCommand : IRequest<NewApiResponse<OnlineTestSettingItemDto>>
    {
        [JsonPropertyName("filter_RecruitmentRequestNo")]
        public string? FilterRecruitmentRequestNo { get; set; }
    }
}
