
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.QuestionSetting.Commands;
using ThePatho.Features.MasterSetting.QuestionSetting.DTO;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Service
{
    public interface IQuestionSettingService
    {
        Task<NewApiResponse<QuestionSettingItemDto>> GetQuestionSetting(GetQuestionSettingCommand request);
        Task<NewApiResponse<QuestionSettingDto>> GetQuestionSettingByCriteria(GetQuestionSettingByCriteriaCommand request);
        Task<NewApiResponse<QuestionSettingItemDto>> GetQuestionSettingDdl(GetQuestionSettingDdlCommand request);
        Task<ApiResponse> SubmitQuestionSetting(SubmitQuestionSettingCommand request);
        Task<ApiResponse> DeleteQuestionSetting(DeleteQuestionSettingCommand request);
    }
}
