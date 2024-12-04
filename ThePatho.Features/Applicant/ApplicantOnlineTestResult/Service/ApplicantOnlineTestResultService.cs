using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.DTO;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service
{
    public class ApplicantOnlineTestResultService : IApplicantOnlineTestResultService
    {
        private readonly ApplicationDbContext _context;
        public ApplicantOnlineTestResultService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ApplicantOnlineTestResultDto> AddApplicantOnlineTestResultAsync(ApplicantOnlineTestResultDto result)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteApplicantOnlineTestResultAsync(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApplicantOnlineTestResultDto>> GetAllApplicantOnlineTestResultsAsync()
        {
            return await _context.ApplicantOnlineTestResults.Select(x => new ApplicantOnlineTestResultDto
            {
                AppResultId = x.AppResultId,
            }).ToListAsync();
        }

        public Task<ApplicantOnlineTestResultDto?> GetApplicantOnlineTestResultByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicantOnlineTestResultDto?> UpdateApplicantOnlineTestResultAsync(ApplicantOnlineTestResultDto result)
        {
            throw new NotImplementedException();
        }
    }
}
