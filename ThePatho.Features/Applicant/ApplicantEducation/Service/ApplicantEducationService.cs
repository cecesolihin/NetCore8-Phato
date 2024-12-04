using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Applicant.ApplicantEducation.DTO;
using ThePatho.Features.Applicant.ApplicantEducation.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantEducation.Service
{
    public class ApplicantEducationService : IApplicantEducationService
    {
        private readonly ApplicationDbContext _context;

        public ApplicantEducationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ApplicantEducationDto> AddApplicantEducationAsync(ApplicantEducationDto education)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteApplicantEducationAsync(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApplicantEducationDto>> GetAllApplicantEducationsAsync()
        {
            return await _context.ApplicantEducations.Select(x => new ApplicantEducationDto
            {
                ApplicantNo = x.ApplicantNo
            }).ToListAsync();
        }

        public Task<ApplicantEducationDto?> GetApplicantEducationByCodeAsync(string applicantNo)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicantEducationDto?> UpdateApplicantEducationAsync(ApplicantEducationDto education)
        {
            throw new NotImplementedException();
        }
    }
}
