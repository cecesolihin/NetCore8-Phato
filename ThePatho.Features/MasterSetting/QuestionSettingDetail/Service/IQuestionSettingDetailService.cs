


using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Service
{
    public interface IQuestionSettingDetailService
    {
        Task<ApiResponse<QuestionSettingDetailItemDto>> GetQuestionSettingDetail(GetQuestionSettingDetailCommand request);
        Task<ApiResponse<QuestionSettingDetailItemDto>> GetQuestionSettingDetailByCriteria(GetQuestionSettingDetailByCriteriaCommand request);
        Task<ApiResponse<QuestionSettingDetailItemDto>> GetQuestionSettingDetailDdl(GetQuestionSettingDetailDdlCommand request);
        Task<ApiResponse> SubmitQuestionSettingDetail(SubmitQuestionSettingDetailCommand request);
        Task<ApiResponse> DeleteQuestionSettingDetail(DeleteQuestionSettingDetailCommand request);
    }
}
