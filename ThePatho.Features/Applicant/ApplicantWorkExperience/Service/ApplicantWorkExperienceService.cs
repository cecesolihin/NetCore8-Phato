using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Applicant.ApplicantWorkExperience.DTO;
using ThePatho.Features.Applicant.ApplicantWorkExperience.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Service
{
    public class ApplicantWorkExperienceService : IApplicantWorkExperienceService
    {
        private readonly ApplicationDbContext _context;

        public ApplicantWorkExperienceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicantWorkExperienceDto>> GetAllApplicantWorkExperienceAsync()
        {
            return await _context.ApplicantWorkExperiences.Select(x => new ApplicantWorkExperienceDto
            {
                ApplicantNo = x.ApplicantNo,
            }).ToListAsync();
        }

        public Task<ApplicantWorkExperienceDto?> GetApplicantWorkExperienceByCodeAsync(string code) => throw new NotImplementedException();
        public Task<ApplicantWorkExperienceDto> AddApplicantWorkExperienceAsync(ApplicantWorkExperienceDto experience) => throw new NotImplementedException();
        public Task<ApplicantWorkExperienceDto?> UpdateApplicantWorkExperienceAsync(ApplicantWorkExperienceDto experience) => throw new NotImplementedException();
        public Task<bool> DeleteApplicantWorkExperienceAsync(string code) => throw new NotImplementedException();
    }
}
