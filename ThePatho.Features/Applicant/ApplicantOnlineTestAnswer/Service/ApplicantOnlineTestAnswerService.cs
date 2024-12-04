using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service
{
    public class ApplicantOnlineTestAnswerService : IApplicantOnlineTestAnswerService
    {
        private readonly ApplicationDbContext _context;

        public ApplicantOnlineTestAnswerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicantOnlineTestAnswerDto>> GetAllApplicantOnlineTestAnswersAsync()
        {
            return await _context.ApplicantOnlineTestAnswers.Select(x => new ApplicantOnlineTestAnswerDto
            {
                AppAnswerId = x.AppAnswerId
            }).ToListAsync();
        }

        public Task<ApplicantOnlineTestAnswerDto?> GetApplicantOnlineTestAnswerByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicantOnlineTestAnswerDto> AddApplicantOnlineTestAnswerAsync(ApplicantOnlineTestAnswerDto answer)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicantOnlineTestAnswerDto?> UpdateApplicantOnlineTestAnswerAsync(ApplicantOnlineTestAnswerDto answer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteApplicantOnlineTestAnswerAsync(string code)
        {
            throw new NotImplementedException();
        }
    }
}
