

using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.ScoringSetting.Commands;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Service
{
    public interface IScoringSettingService
    {
        Task<ApiResponse<ScoringSettingItemDto>> GetScoringSetting(GetScoringSettingCommand request);
        Task<ApiResponse<ScoringSettingDto>> GetScoringSettingByCriteria(GetScoringSettingByCriteriaCommand request);
        Task<ApiResponse<ScoringSettingItemDto>> GetScoringSettingDdl(GetScoringSettingDdlCommand request);
        Task<ApiResponse> SubmitScoringSetting(SubmitScoringSettingCommand request);
        Task<ApiResponse> DeleteScoringSetting(DeleteScoringSettingCommand request);
    }
}
