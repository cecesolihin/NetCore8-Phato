using ThePatho.Features.MasterSetting.ScoringSetting.DTO;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Service
{
    public interface IScoringSettingService
    {
        Task<List<ScoringSettingDto>> GetAllScoringSettingAsync();
        Task<ScoringSettingDto?> GetScoringSettingByCodeAsync(string code);
        Task<ScoringSettingDto> AddScoringSettingAsync(ScoringSettingDto scoringSetting);
        Task<ScoringSettingDto?> UpdateScoringSettingAsync(ScoringSettingDto scoringSetting);
        Task<bool> DeleteScoringSettingAsync(string code);
    }
}
