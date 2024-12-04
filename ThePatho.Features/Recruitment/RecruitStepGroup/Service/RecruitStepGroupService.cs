using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Service
{
    public class RecruitStepGroupService : IRecruitStepGroupService
    {
        private readonly ApplicationDbContext _context;

        public RecruitStepGroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<RecruitStepGroupDto> AddRecruitStepGroupAsync(RecruitStepGroupDto recruitStepGroup)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRecruitStepGroupAsync(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RecruitStepGroupDto>> GetAllRecruitStepGroupAsync()
        {
            return await _context.RecruitStepGroups.Select(x => new RecruitStepGroupDto
            {
                RecStepGroupCode = x.RecStepGroupCode,
            }).ToListAsync();
        }

        public Task<RecruitStepGroupDto?> GetRecruitStepGroupByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<RecruitStepGroupDto?> UpdateRecruitStepGroupAsync(RecruitStepGroupDto recruitStepGroup)
        {
            throw new NotImplementedException();
        }
    }
}
