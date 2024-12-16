
using ThePatho.Features.MasterSetting.ScoringSetting.Commands;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Service
{
    public interface IScoringSettingService
    {
        Task<List<ScoringSettingDto>> GetScoringSetting(GetScoringSettingCommand request);
        Task<ScoringSettingDto> GetScoringSettingByCode(GetScoringSettingByCodeCommand request);
        Task<List<ScoringSettingDto>> GetScoringSettingDdl(GetScoringSettingDdlCommand request);
    }
}
