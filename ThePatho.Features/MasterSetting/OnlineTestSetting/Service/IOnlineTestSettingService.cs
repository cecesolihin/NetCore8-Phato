using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Service
{
    public interface IOnlineTestSettingService
    {
        Task<List<OnlineTestSettingDto>> GetAllOnlineTestSettingAsync();
        Task<OnlineTestSettingDto?> GetOnlineTestSettingByCodeAsync(string code);
        Task<OnlineTestSettingDto> AddOnlineTestSettingAsync(OnlineTestSettingDto onlineTestSetting);
        Task<OnlineTestSettingDto?> UpdateOnlineTestSettingAsync(OnlineTestSettingDto onlineTestSetting);
        Task<bool> DeleteOnlineTestSettingAsync(string code);
    }
}
