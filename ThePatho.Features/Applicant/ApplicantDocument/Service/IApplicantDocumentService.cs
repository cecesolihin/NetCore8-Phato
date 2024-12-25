using ThePatho.Features.Applicant.ApplicantDocument.Commands;
using ThePatho.Features.Applicant.ApplicantDocument.DTO;

namespace ThePatho.Features.Applicant.ApplicantDocument.Service
{
    public interface IApplicantDocumentService
    {
        Task<List<ApplicantDocumentDto>> GetApplicantDocument(GetApplicantDocumentCommand request);
        Task<ApplicantDocumentDto> GetApplicantDocumentByCriteria(GetApplicantDocumentByCriteriaCommand request); 
    }
}
