
using ThePatho.Features.MasterSetting.QuestionSetting.Commands;
using ThePatho.Features.MasterSetting.QuestionSetting.DTO;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Service
{
    public interface IQuestionSettingService
    {
        Task<ApiResponse<QuestionSettingItemDto>> GetQuestionSetting(GetQuestionSettingCommand request);
        Task<ApiResponse<QuestionSettingDto>> GetQuestionSettingByCriteria(GetQuestionSettingByCriteriaCommand request);
        Task<ApiResponse<QuestionSettingItemDto>> GetQuestionSettingDdl(GetQuestionSettingDdlCommand request);
        Task<ApiResponse> SubmitQuestionSetting(SubmitQuestionSettingCommand request);
        Task<ApiResponse> DeleteQuestionSetting(DeleteQuestionSettingCommand request);
    }
}
