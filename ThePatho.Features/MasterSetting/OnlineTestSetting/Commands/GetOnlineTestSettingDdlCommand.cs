using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class GetOnlineTestSettingDdlCommand : IRequest<ApiResponse<OnlineTestSettingItemDto>>
    {
        [JsonPropertyName("filter_RecruitmentRequestNo")]
        public string? FilterRecruitmentRequestNo { get; set; }
    }
}
