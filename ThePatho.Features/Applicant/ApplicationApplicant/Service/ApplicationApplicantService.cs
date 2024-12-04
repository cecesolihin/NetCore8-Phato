using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Applicant.ApplicationApplicant.DTO;
using ThePatho.Features.Applicant.ApplicationApplicant.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Service
{
    public class ApplicationApplicantService : IApplicationApplicantService
    {
        private readonly ApplicationDbContext _context;

        public ApplicationApplicantService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationApplicantDto>> GetAllApplicationApplicantAsync()
        {
            return await _context.ApplicationApplicants.Select(x => new ApplicationApplicantDto
            {
                RecApplicationId = x.RecApplicationId,
            }).ToListAsync();
        }

        public Task<ApplicationApplicantDto?> GetApplicationApplicantByCodeAsync(string code) => throw new NotImplementedException();
        public Task<ApplicationApplicantDto> AddApplicationApplicantAsync(ApplicationApplicantDto applicant) => throw new NotImplementedException();
        public Task<ApplicationApplicantDto?> UpdateApplicationApplicantAsync(ApplicationApplicantDto applicant) => throw new NotImplementedException();
        public Task<bool> DeleteApplicationApplicantAsync(string code) => throw new NotImplementedException();
    }
}
