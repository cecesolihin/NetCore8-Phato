using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class DeleteQuestionSettingCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("questionnaire_code")]
        public string QuestionnaireCode { get; set; }

        public DeleteQuestionSettingCommand(string questionnaireCode)
        {
            QuestionnaireCode = questionnaireCode;
        }
    }
}
