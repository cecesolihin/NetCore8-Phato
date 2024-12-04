using Microsoft.EntityFrameworkCore;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Service
{
    public class OnlineTestSettingService : IOnlineTestSettingService
    {
        private readonly ApplicationDbContext _context;

        public OnlineTestSettingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OnlineTestSettingDto>> GetAllOnlineTestSettingAsync()
        {
            return await _context.OnlineTestSettings.Select(x => new OnlineTestSettingDto
            {
                OnlineTestCode = x.OnlineTestCode,
                
            }).ToListAsync();
        }

        public Task<OnlineTestSettingDto?> GetOnlineTestSettingByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<OnlineTestSettingDto> AddOnlineTestSettingAsync(OnlineTestSettingDto onlineTestSetting)
        {
            throw new NotImplementedException();
        }

        public Task<OnlineTestSettingDto?> UpdateOnlineTestSettingAsync(OnlineTestSettingDto onlineTestSetting)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOnlineTestSettingAsync(string code)
        {
            throw new NotImplementedException();
        }
    }
}
