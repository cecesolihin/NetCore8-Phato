using Microsoft.EntityFrameworkCore;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Service
{
    public class ScoringSettingService : IScoringSettingService
    {
        private readonly ApplicationDbContext _context;

        public ScoringSettingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ScoringSettingDto>> GetAllScoringSettingAsync()
        {
            return await _context.ScoringSettings.Select(x => new ScoringSettingDto
            {
                ScoringCode = x.ScoringCode,
            }).ToListAsync();
        }

        public Task<ScoringSettingDto?> GetScoringSettingByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<ScoringSettingDto> AddScoringSettingAsync(ScoringSettingDto scoringSetting)
        {
            throw new NotImplementedException();
        }

        public Task<ScoringSettingDto?> UpdateScoringSettingAsync(ScoringSettingDto scoringSetting)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteScoringSettingAsync(string code)
        {
            throw new NotImplementedException();
        }
    }
}
