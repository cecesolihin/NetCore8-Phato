
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.OnlineTestSetting.Commands;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Service
{
    public interface IOnlineTestSettingService
    {
        Task<NewApiResponse<OnlineTestSettingItemDto>> GetOnlineTestSetting(GetOnlineTestSettingCommand request);
        Task<NewApiResponse<OnlineTestSettingDto>> GetOnlineTestSettingByCriteria(GetOnlineTestSettingByCriteriaCommand request);
        Task<NewApiResponse<OnlineTestSettingItemDto>> GetOnlineTestSettingDdl(GetOnlineTestSettingDdlCommand request);
        Task<ApiResponse> SubmitOnlineTestSetting(SubmitOnlineTestSettingCommand request);
        Task<ApiResponse> DeleteOnlineTestSetting(DeleteOnlineTestSettingCommand request);
    }
}
