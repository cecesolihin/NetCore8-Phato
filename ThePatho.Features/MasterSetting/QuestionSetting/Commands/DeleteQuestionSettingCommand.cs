using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class DeleteQuestionSettingCommand : IRequest<bool>
    {
        [JsonPropertyName("questionnaire_code")]
        public string QuestionnaireCode { get; set; }

        public DeleteQuestionSettingCommand(string questionnaireCode)
        {
            QuestionnaireCode = questionnaireCode;
        }
    }
}
