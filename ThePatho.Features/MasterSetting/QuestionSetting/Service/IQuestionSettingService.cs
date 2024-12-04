using ThePatho.Features.MasterSetting.QuestionSetting.DTO;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Service
{
    public interface IQuestionSettingService
    {
        Task<List<QuestionSettingDto>> GetAllQuestionSettingAsync();
        Task<QuestionSettingDto?> GetQuestionSettingByCodeAsync(string code);
        Task<QuestionSettingDto> AddQuestionSettingAsync(QuestionSettingDto questionSetting);
        Task<QuestionSettingDto?> UpdateQuestionSettingAsync(QuestionSettingDto questionSetting);
        Task<bool> DeleteQuestionSettingAsync(string code);
    }
}
