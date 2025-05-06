using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class GetScoringSettingByCriteriaCommand : IRequest<ApiResponse<ScoringSettingDto>>
    {
        [JsonPropertyName("filter_ScoringCode")] 
        public string? FilterScoringCode { get; set; }
    }
}
