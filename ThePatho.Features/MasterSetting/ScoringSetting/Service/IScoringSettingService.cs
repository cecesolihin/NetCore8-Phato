

using ThePatho.Features.MasterSetting.ScoringSetting.Commands;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Service
{
    public interface IScoringSettingService
    {
        Task<List<ScoringSettingDto>> GetScoringSetting(GetScoringSettingCommand request);
        Task<ScoringSettingDto> GetScoringSettingByCriteria(GetScoringSettingByCriteriaCommand request);
        Task<List<ScoringSettingDto>> GetScoringSettingDdl(GetScoringSettingDdlCommand request);
        Task SubmitScoringSetting(SubmitScoringSettingCommand request);
        Task DeleteScoringSetting(DeleteScoringSettingCommand request);
    }
}
