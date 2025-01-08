using MediatR;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class DeleteQuestionSettingCommand : IRequest<bool>
    {
        public string QuestionnaireCode { get; set; }

        public DeleteQuestionSettingCommand(string questionnaireCode)
        {
            QuestionnaireCode = questionnaireCode;
        }
    }
}
