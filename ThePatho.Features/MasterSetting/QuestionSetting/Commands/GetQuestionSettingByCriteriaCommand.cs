using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.QuestionSetting.DTO;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class GetQuestionSettingByCriteriaCommand : IRequest<NewApiResponse<QuestionSettingDto>>
    {
        [JsonPropertyName("filter_QuestionCode")]
        public string? FilterQuestionCode { get; set; }
    }
}
