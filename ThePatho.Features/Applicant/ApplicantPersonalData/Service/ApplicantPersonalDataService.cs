using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;
using ThePatho.Features.Applicant.ApplicantPersonalData.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Service
{
    public class ApplicantPersonalDataService : IApplicantPersonalDataService
    {
        private readonly ApplicationDbContext _context;

        public ApplicantPersonalDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicantPersonalDataDto>> GetAllApplicantPersonalDataAsync()
        {
            return await _context.ApplicantPersonalDatas.Select(x => new ApplicantPersonalDataDto
            {
                ApplicantNo = x.ApplicantNo,
            }).ToListAsync();
        }

        public Task<ApplicantPersonalDataDto?> GetApplicantPersonalDataByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicantPersonalDataDto> AddApplicantPersonalDataAsync(ApplicantPersonalDataDto data)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicantPersonalDataDto?> UpdateApplicantPersonalDataAsync(ApplicantPersonalDataDto data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteApplicantPersonalDataAsync(string code)
        {
            throw new NotImplementedException();
        }
    }
}
