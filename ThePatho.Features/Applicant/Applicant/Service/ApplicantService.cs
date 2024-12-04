using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Applicant.Applicant.DTO;
using ThePatho.Features.Applicant.Applicant.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.Applicant.Service
{
    public class ApplicantService : IApplicantService
    {
        private readonly ApplicationDbContext _context;

        public ApplicantService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicantDto>> GetAllApplicantsAsync()
        {
            return await _context.Applicants.Select(x => new ApplicantDto
            {
                ApplicantNo = x.ApplicantNo,
      
            }).ToListAsync();
        }

        public Task<ApplicantDto?> GetApplicantByIdAsync(int id) => throw new NotImplementedException();
        public Task<ApplicantDto> AddApplicantAsync(ApplicantDto applicant) => throw new NotImplementedException();
        public Task<ApplicantDto?> UpdateApplicantAsync(ApplicantDto applicant) => throw new NotImplementedException();
        public Task<bool> DeleteApplicantAsync(int id) => throw new NotImplementedException();
    }
}
