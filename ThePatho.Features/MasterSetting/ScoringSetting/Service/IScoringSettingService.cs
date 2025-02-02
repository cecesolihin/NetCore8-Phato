

using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.ScoringSetting.Commands;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Service
{
    public interface IScoringSettingService
    {
        Task<NewApiResponse<ScoringSettingItemDto>> GetScoringSetting(GetScoringSettingCommand request);
        Task<NewApiResponse<ScoringSettingDto>> GetScoringSettingByCriteria(GetScoringSettingByCriteriaCommand request);
        Task<NewApiResponse<ScoringSettingItemDto>> GetScoringSettingDdl(GetScoringSettingDdlCommand request);
        Task<ApiResponse> SubmitScoringSetting(SubmitScoringSettingCommand request);
        Task<ApiResponse> DeleteScoringSetting(DeleteScoringSettingCommand request);
    }
}
