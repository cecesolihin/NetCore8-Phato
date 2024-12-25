
using ThePatho.Features.MasterSetting.QuestionSetting.Commands;
using ThePatho.Features.MasterSetting.QuestionSetting.DTO;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Service
{
    public interface IQuestionSettingService
    {
        Task<List<QuestionSettingDto>> GetQuestionSetting(GetQuestionSettingCommand request);
        Task<QuestionSettingDto> GetQuestionSettingByCriteria(GetQuestionSettingByCriteriaCommand request);
        Task<List<QuestionSettingDto>> GetQuestionSettingDdl(GetQuestionSettingDdlCommand request);
    }
}
