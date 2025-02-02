


using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Service
{
    public interface IScoringSettingDetailService
    {
        Task<NewApiResponse<ScoringSettingDetailItemDto>> GetScoringSettingDetail(GetScoringSettingDetailCommand request);
        Task<NewApiResponse<ScoringSettingDetailItemDto>> GetScoringSettingDetailByCriteria(GetScoringSettingDetailByCriteriaCommand request);
        Task<NewApiResponse<ScoringSettingDetailItemDto>> GetScoringSettingDetailDdl(GetScoringSettingDetailDdlCommand request);
        Task<ApiResponse> SubmitScoringSettingDetail(SubmitScoringSettingDetailCommand request);
        Task<ApiResponse> DeleteScoringSettingDetail(DeleteScoringSettingDetailCommand request);
    }
}
