using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class GetScoringSettingDdlCommand : IRequest<ApiResponse<ScoringSettingItemDto>>
    {
        [JsonPropertyName("filter_ScoringCode")]
        public string? FilterScoringCode { get; set; }
    }
}
