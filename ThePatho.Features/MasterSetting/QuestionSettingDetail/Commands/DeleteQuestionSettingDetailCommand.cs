using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class DeleteQuestionSettingDetailCommand : IRequest<bool>
    {
        [JsonPropertyName("quest_detail_id")]
        public int QuestDetailId { get; set; }

        public DeleteQuestionSettingDetailCommand(int questDetailId)
        {
            QuestDetailId = questDetailId;
        }
    }
}
