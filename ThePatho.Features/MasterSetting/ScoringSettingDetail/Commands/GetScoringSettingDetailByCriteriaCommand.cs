using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class GetScoringSettingDetailByCriteriaCommand : IRequest<ApiResponse<ScoringSettingDetailItemDto>> 
    {
        [JsonPropertyName("filter_ScoringCode")]
        public string? FilterScoringCode { get; set; }
    }
}
