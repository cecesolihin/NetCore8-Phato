using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Service
{
    public class RecruitmentRequestService : IRecruitmentRequestService
    {
        private readonly ApplicationDbContext _context;

        public RecruitmentRequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<RecruitmentRequestDto> AddRecruitmentRequestAsync(RecruitmentRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRecruitmentRequestAsync(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RecruitmentRequestDto>> GetAllRecruitmentRequestAsync()
        {
            return await _context.RecruitmentRequests.Select(x => new RecruitmentRequestDto
            {
                RequestNo = x.RequestNo,
            }).ToListAsync();
        }

        public Task<RecruitmentRequestDto?> GetRecruitmentRequestByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<RecruitmentRequestDto?> UpdateRecruitmentRequestAsync(RecruitmentRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
