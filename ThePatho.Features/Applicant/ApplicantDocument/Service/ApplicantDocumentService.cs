using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Applicant.ApplicantDocument.DTO;
using ThePatho.Features.Applicant.ApplicantDocument.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantDocument.Service
{
    public class ApplicantDocumentService : IApplicantDocumentService
    {
        private readonly ApplicationDbContext _context;

        public ApplicantDocumentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicantDocumentDto>> GetAllApplicantDocumentAsync()
        {
            return await _context.ApplicantDocuments.Select(x => new ApplicantDocumentDto
            {
                ApplicantNo = x.ApplicantNo
            }).ToListAsync();
        }

        public Task<ApplicantDocumentDto?> GetApplicantDocumentByCodeAsync(string applicantNo) => throw new NotImplementedException();
        public Task<ApplicantDocumentDto> AddApplicantDocumentAsync(ApplicantDocumentDto document) => throw new NotImplementedException();
        public Task<ApplicantDocumentDto?> UpdateApplicantDocumentAsync(ApplicantDocumentDto document) => throw new NotImplementedException();
        public Task<bool> DeleteApplicantDocumentAsync(string code) => throw new NotImplementedException();
    }
}
