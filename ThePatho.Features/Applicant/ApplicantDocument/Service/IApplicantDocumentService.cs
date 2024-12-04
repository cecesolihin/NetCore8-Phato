using ThePatho.Features.Applicant.ApplicantDocument.DTO;

namespace ThePatho.Features.Applicant.ApplicantDocument.Service
{
    public interface IApplicantDocumentService
    {
        Task<List<ApplicantDocumentDto>> GetAllApplicantDocumentAsync();
        Task<ApplicantDocumentDto?> GetApplicantDocumentByCodeAsync(string applicantNo);
        Task<ApplicantDocumentDto> AddApplicantDocumentAsync(ApplicantDocumentDto document);
        Task<ApplicantDocumentDto?> UpdateApplicantDocumentAsync(ApplicantDocumentDto document);
        Task<bool> DeleteApplicantDocumentAsync(string code);
    }
}
