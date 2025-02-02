using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class GetScoringSettingByCriteriaCommand : IRequest<NewApiResponse<ScoringSettingDto>>
    {
        [JsonPropertyName("filter_ScoringCode")] 
        public string? FilterScoringCode { get; set; }
    }
}
