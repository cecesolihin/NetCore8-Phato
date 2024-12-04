using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Service
{
    public interface IQuestionSettingDetailService
    {
        Task<List<QuestionSettingDetailDto>> GetAllQuestionSettingDetailAsync();
        Task<QuestionSettingDetailDto?> GetQuestionSettingDetailByCodeAsync(string code);
        Task<QuestionSettingDetailDto> AddQuestionSettingDetailAsync(QuestionSettingDetailDto detail);
        Task<QuestionSettingDetailDto?> UpdateQuestionSettingDetailAsync(QuestionSettingDetailDto detail);
        Task<bool> DeleteQuestionSettingDetailAsync(string code);
    }
}
