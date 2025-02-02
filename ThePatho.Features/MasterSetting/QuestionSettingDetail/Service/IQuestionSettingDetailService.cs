


using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Service
{
    public interface IQuestionSettingDetailService
    {
        Task<NewApiResponse<QuestionSettingDetailItemDto>> GetQuestionSettingDetail(GetQuestionSettingDetailCommand request);
        Task<NewApiResponse<QuestionSettingDetailItemDto>> GetQuestionSettingDetailByCriteria(GetQuestionSettingDetailByCriteriaCommand request);
        Task<NewApiResponse<QuestionSettingDetailItemDto>> GetQuestionSettingDetailDdl(GetQuestionSettingDetailDdlCommand request);
        Task<ApiResponse> SubmitQuestionSettingDetail(SubmitQuestionSettingDetailCommand request);
        Task<ApiResponse> DeleteQuestionSettingDetail(DeleteQuestionSettingDetailCommand request);
    }
}
