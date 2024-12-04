using Microsoft.EntityFrameworkCore;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Service
{
    public class ScoringSettingDetailService : IScoringSettingDetailService
    {
        private readonly ApplicationDbContext _context;

        public ScoringSettingDetailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ScoringSettingDetailDto> AddScoringSettingDetailAsync(ScoringSettingDetailDto detail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteScoringSettingDetailAsync(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ScoringSettingDetailDto>> GetAllScoringSettingDetailAsync()
        {
            return await _context.ScoringSettingDetails.Select(x => new ScoringSettingDetailDto
            {
                ScoringCode = x.ScoringCode,
            }).ToListAsync();
        }

        public Task<ScoringSettingDetailDto?> GetScoringSettingDetailByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<ScoringSettingDetailDto?> UpdateScoringSettingDetailAsync(ScoringSettingDetailDto detail)
        {
            throw new NotImplementedException();
        }
    }
}
