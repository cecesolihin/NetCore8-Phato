using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Applicant.ApplicantSkill.DTO;
using ThePatho.Features.Applicant.ApplicantSkill.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantSkill.Service
{
    public class ApplicantSkillService : IApplicantSkillService
    {
        private readonly ApplicationDbContext _context;

        public ApplicantSkillService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicantSkillDto>> GetAllApplicantSkillAsync()
        {
            return await _context.ApplicantSkills.Select(x => new ApplicantSkillDto
            {
                ApplicantNo = x.ApplicantNo,
            }).ToListAsync();
        }

        public Task<ApplicantSkillDto?> GetApplicantSkillByCodeAsync(string code) => throw new NotImplementedException();
        public Task<ApplicantSkillDto> AddApplicantSkillAsync(ApplicantSkillDto skill) => throw new NotImplementedException();
        public Task<ApplicantSkillDto?> UpdateApplicantSkillAsync(ApplicantSkillDto skill) => throw new NotImplementedException();
        public Task<bool> DeleteApplicantSkillAsync(string code) => throw new NotImplementedException();

    }
}
