
using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;
using ThePatho.Features.Applicant.ApplicantIdentity.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Service
{
    public class ApplicantIdentityService : IApplicantIdentityService
    {
        private readonly ApplicationDbContext _context;

        public ApplicantIdentityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ApplicantIdentityDto> AddApplicantIdentityAsync(ApplicantIdentityDto identity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteApplicantIdentityAsync(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApplicantIdentityDto>> GetAllApplicantIdentitiesAsync()
        {
            return await _context.ApplicantIdentities.Select(x => new ApplicantIdentityDto
            {
                ApplicantNo = x.ApplicantNo
            }).ToListAsync();
        }

        public Task<ApplicantIdentityDto?> GetApplicantIdentityByCodeAsync(string applicantNo)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicantIdentityDto?> UpdateApplicantIdentityAsync(ApplicantIdentityDto identity)
        {
            throw new NotImplementedException();
        }
    }
}
