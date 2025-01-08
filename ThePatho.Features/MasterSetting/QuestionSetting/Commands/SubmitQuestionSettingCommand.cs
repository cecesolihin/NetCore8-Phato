using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class SubmitQuestionSettingCommand : IRequest<string>
    {
        public string QuestionnaireCode { get; set; }
        public string QuestionnaireName { get; set; }
        public string QuestionnaireType { get; set; }
        public string Remarks { get; set; }
        public bool Active { get; set; }
        public string AnswerMethod { get; set; }
        public bool RandomQuestion { get; set; }
        public string Action { get; set; }
    }
}
