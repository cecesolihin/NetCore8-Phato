


using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Service
{
    public interface IScoringSettingDetailService
    {
        Task<ApiResponse<ScoringSettingDetailItemDto>> GetScoringSettingDetail(GetScoringSettingDetailCommand request);
        Task<ApiResponse<ScoringSettingDetailItemDto>> GetScoringSettingDetailByCriteria(GetScoringSettingDetailByCriteriaCommand request);
        Task<ApiResponse<ScoringSettingDetailItemDto>> GetScoringSettingDetailDdl(GetScoringSettingDetailDdlCommand request);
        Task<ApiResponse> SubmitScoringSettingDetail(SubmitScoringSettingDetailCommand request);
        Task<ApiResponse> DeleteScoringSettingDetail(DeleteScoringSettingDetailCommand request);
    }
}
