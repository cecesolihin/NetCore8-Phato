using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class SubmitQuestionSettingDetailCommand : IRequest<string>
    {
        public int? QuestDetailId { get; set; }
        public string QuestionnaireCode { get; set; }
        public bool IsCategory { get; set; }
        public string Question { get; set; }
        public int? QuestParent { get; set; }
        public string ScoringCode { get; set; }
        public int Order { get; set; }
        public string Attachment { get; set; }
        public string MultiChoiceOption { get; set; }
        public string CorrectAnswer { get; set; }
        public int? WeightPoint { get; set; }
        public string Action { get; set; }
    }
}
