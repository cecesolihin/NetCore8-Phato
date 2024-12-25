
using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Applicant.ReasonStepFailed.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ReasonStepFailed.Service
{
    public class ReasonStepFailedService : IReasonStepFailedService
    {
        private readonly ApplicationDbContext _context;

        public ReasonStepFailedService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReasonStepFailedDto>> GetAllReasonStepFailedAsync()
        {
            return await _context.ReasonStepFaileds.Select(x => new ReasonStepFailedDto
            {
                ReasonCode = x.ReasonCode,

            }).ToListAsync();
        }

        public Task<ReasonStepFailedDto?> GetReasonStepFailedByCriteriaAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<ReasonStepFailedDto> AddReasonStepFailedAsync(ReasonStepFailedDto reason)
        {
            throw new NotImplementedException();
        }

        public Task<ReasonStepFailedDto?> UpdateReasonStepFailedAsync(ReasonStepFailedDto reason)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteReasonStepFailedAsync(string code)
        {
            throw new NotImplementedException();
        }
    }
}

