using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Recruitment.RecruitStep.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Recruitment.RecruitStep.Service
{
    public class RecruitStepService : IRecruitStepService
    {
        private readonly ApplicationDbContext _context;

        public RecruitStepService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<RecruitStepDto> AddRecruitStepAsync(RecruitStepDto recruitStep)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRecruitStepAsync(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RecruitStepDto>> GetAllRecruitStepAsync()
        {
            return await _context.RecruitSteps.Select(x => new RecruitStepDto
            {
                RecruitStepCode = x.RecruitStepCode,

            }).ToListAsync();
        }

        public Task<RecruitStepDto?> GetRecruitStepByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<RecruitStepDto?> UpdateRecruitStepAsync(RecruitStepDto recruitStep)
        {
            throw new NotImplementedException();
        }
    }
}
