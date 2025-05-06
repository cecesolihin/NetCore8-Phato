
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.OnlineTestSetting.Commands;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Service
{
    public interface IOnlineTestSettingService
    {
        Task<ApiResponse<OnlineTestSettingItemDto>> GetOnlineTestSetting(GetOnlineTestSettingCommand request);
        Task<ApiResponse<OnlineTestSettingDto>> GetOnlineTestSettingByCriteria(GetOnlineTestSettingByCriteriaCommand request);
        Task<ApiResponse<OnlineTestSettingItemDto>> GetOnlineTestSettingDdl(GetOnlineTestSettingDdlCommand request);
        Task<ApiResponse> SubmitOnlineTestSetting(SubmitOnlineTestSettingCommand request);
        Task<ApiResponse> DeleteOnlineTestSetting(DeleteOnlineTestSettingCommand request);
    }
}
