using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class DeleteQuestionSettingDetailCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("quest_detail_id")]
        public int QuestDetailId { get; set; }

        public DeleteQuestionSettingDetailCommand(int questDetailId)
        {
            QuestDetailId = questDetailId;
        }
    }
}
