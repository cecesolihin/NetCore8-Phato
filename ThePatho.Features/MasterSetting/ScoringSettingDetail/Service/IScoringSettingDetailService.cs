
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Service
{
    public interface IScoringSettingDetailService
    {
        Task<List<ScoringSettingDetailDto>> GetScoringSettingDetail(GetScoringSettingDetailCommand request);
        Task<List<ScoringSettingDetailDto>> GetScoringSettingDetailByCriteria(GetScoringSettingDetailByCriteriaCommand request);
        Task<List<ScoringSettingDetailDto>> GetScoringSettingDetailDdl(GetScoringSettingDetailDdlCommand request);
    }
}
