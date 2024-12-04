using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Recruitment.RequirementRecRequest.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Recruitment.RequirementRecRequest.Service
{
    public class RequirementRecRequestService : IRequirementRecRequestService
    {
        private readonly ApplicationDbContext _context;

        public RequirementRecRequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<RequirementRecRequestDto> AddRequirementRecRequestAsync(RequirementRecRequestDto requirement)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRequirementRecRequestAsync(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RequirementRecRequestDto>> GetAllRequirementRecRequestAsync()
        {
            return await _context.RequirementRecRequests.Select(x => new RequirementRecRequestDto
            {

                RequestNo = x.RequestNo
            }).ToListAsync();
        }

        public Task<RequirementRecRequestDto?> GetRequirementRecRequestByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<RequirementRecRequestDto?> UpdateRequirementRecRequestAsync(RequirementRecRequestDto requirement)
        {
            throw new NotImplementedException();
        }
    }
}
