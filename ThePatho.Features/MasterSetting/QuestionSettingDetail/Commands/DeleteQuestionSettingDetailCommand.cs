using MediatR;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class DeleteQuestionSettingDetailCommand : IRequest<bool>
    {
        public int QuestDetailId { get; set; }

        public DeleteQuestionSettingDetailCommand(int questDetailId)
        {
            QuestDetailId = questDetailId;
        }
    }
}
