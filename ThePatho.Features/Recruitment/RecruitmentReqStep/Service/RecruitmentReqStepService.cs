using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Recruitment.RecruitmentReqStep.Service
{
    public class RecruitmentReqStepService : IRecruitmentReqStepService
    {
        private readonly ApplicationDbContext _context;

        public RecruitmentReqStepService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<RecruitmentReqStepDto> AddRecruitmentReqStepAsync(RecruitmentReqStepDto reqStep)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRecruitmentReqStepAsync(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RecruitmentReqStepDto>> GetAllRecruitmentReqStepAsync()
        {
            return await _context.RecruitmentReqSteps.Select(x => new RecruitmentReqStepDto
            {
                RecruitReqStepId = x.RecruitReqStepId,

            }).ToListAsync();
        }

        public Task<RecruitmentReqStepDto?> GetRecruitmentReqStepByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<RecruitmentReqStepDto?> UpdateRecruitmentReqStepAsync(RecruitmentReqStepDto reqStep)
        {
            throw new NotImplementedException();
        }
    }
}
