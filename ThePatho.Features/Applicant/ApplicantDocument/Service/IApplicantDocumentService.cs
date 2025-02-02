using ThePatho.Features.Applicant.ApplicantDocument.Commands;
using ThePatho.Features.Applicant.ApplicantDocument.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantDocument.Service
{
    public interface IApplicantDocumentService
    {
        Task<NewApiResponse<ApplicantDocumentItemDto>> GetApplicantDocument(GetApplicantDocumentCommand request);
        Task<NewApiResponse<ApplicantDocumentDto>> GetApplicantDocumentByCriteria(GetApplicantDocumentByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantDocument(SubmitApplicantDocumentCommand request);
        Task<ApiResponse> DeleteApplicantDocument(DeleteApplicantDocumentCommand request);
    }
}
