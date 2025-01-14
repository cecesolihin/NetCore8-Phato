


using ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Service
{
    public interface IQuestionSettingDetailService
    {
        Task<List<QuestionSettingDetailDto>> GetQuestionSettingDetail(GetQuestionSettingDetailCommand request);
        Task<List<QuestionSettingDetailDto>> GetQuestionSettingDetailByCriteria(GetQuestionSettingDetailByCriteriaCommand request);
        Task<List<QuestionSettingDetailDto>> GetQuestionSettingDetailDdl(GetQuestionSettingDetailDdlCommand request);
        Task SubmitQuestionSettingDetail(SubmitQuestionSettingDetailCommand request);
        Task DeleteQuestionSettingDetail(DeleteQuestionSettingDetailCommand request);
    }
}
