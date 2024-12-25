
using ThePatho.Features.MasterSetting.OnlineTestSetting.Commands;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Service
{
    public interface IOnlineTestSettingService
    {
        Task<List<OnlineTestSettingDto>> GetOnlineTestSetting(GetOnlineTestSettingCommand request);
        Task<OnlineTestSettingDto> GetOnlineTestSettingByCriteria(GetOnlineTestSettingByCriteriaCommand request);
        Task<List<OnlineTestSettingDto>> GetOnlineTestSettingDdl(GetOnlineTestSettingDdlCommand request);
    }
}
