using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Recruitment.RecruitStepGroupDetail.Service
{
    public class RecruitStepGroupDetailService : IRecruitStepGroupDetailService
    {
        private readonly ApplicationDbContext _context;

        public RecruitStepGroupDetailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<RecruitStepGroupDetailDto> AddRecruitStepGroupDetailAsync(RecruitStepGroupDetailDto detail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRecruitStepGroupDetailAsync(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RecruitStepGroupDetailDto>> GetAllRecruitStepGroupDetailAsync()
        {
            return await _context.RecruitStepGroupDetails.Select(x => new RecruitStepGroupDetailDto
            {
                RecStepGroupDetailId = x.RecStepGroupDetailId,

            }).ToListAsync();
        }

        public Task<RecruitStepGroupDetailDto?> GetRecruitStepGroupDetailByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<RecruitStepGroupDetailDto?> UpdateRecruitStepGroupDetailAsync(RecruitStepGroupDetailDto detail)
        {
            throw new NotImplementedException();
        }
    }
}
