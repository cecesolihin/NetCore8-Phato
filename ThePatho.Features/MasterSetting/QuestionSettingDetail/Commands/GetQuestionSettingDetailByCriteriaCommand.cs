using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class GetQuestionSettingDetailByCriteriaCommand : IRequest<ApiResponse<QuestionSettingDetailItemDto>> 
    {
        [JsonPropertyName("filter_QuestionCode")]
        public string? FilterQuestionCode { get; set; }
    }
}
