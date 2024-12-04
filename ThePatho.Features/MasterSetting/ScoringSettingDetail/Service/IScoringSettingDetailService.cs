using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Service
{
    public interface IScoringSettingDetailService
    {
        Task<List<ScoringSettingDetailDto>> GetAllScoringSettingDetailAsync();
        Task<ScoringSettingDetailDto?> GetScoringSettingDetailByCodeAsync(string code);
        Task<ScoringSettingDetailDto> AddScoringSettingDetailAsync(ScoringSettingDetailDto detail);
        Task<ScoringSettingDetailDto?> UpdateScoringSettingDetailAsync(ScoringSettingDetailDto detail);
        Task<bool> DeleteScoringSettingDetailAsync(string code);
    }
}
