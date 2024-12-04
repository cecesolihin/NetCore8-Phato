using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Applicant.ApplicantRecruitStep.DTO;
using ThePatho.Features.Applicant.ApplicantRecruitStep.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Service
{
    public class ApplicantRecruitStepService : IApplicantRecruitStepService
    {
        private readonly ApplicationDbContext _context;

        public ApplicantRecruitStepService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicantRecruitStepDto>> GetAllApplicantRecruitStepAsync()
        {
            return await _context.ApplicantRecruitSteps.Select(x => new ApplicantRecruitStepDto
            {
                AppRecStepId = x.AppRecStepId,
            }).ToListAsync();
        }

        public Task<ApplicantRecruitStepDto?> GetApplicantRecruitStepByCodeAsync(string code) => throw new NotImplementedException();
        public Task<ApplicantRecruitStepDto> AddApplicantRecruitStepAsync(ApplicantRecruitStepDto step) => throw new NotImplementedException();
        public Task<ApplicantRecruitStepDto?> UpdateApplicantRecruitStepAsync(ApplicantRecruitStepDto step) => throw new NotImplementedException();
        public Task<bool> DeleteApplicantRecruitStepAsync(string code) => throw new NotImplementedException();
    }
}
