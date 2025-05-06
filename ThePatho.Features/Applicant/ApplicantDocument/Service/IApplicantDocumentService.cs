using ThePatho.Features.Applicant.ApplicantDocument.Commands;
using ThePatho.Features.Applicant.ApplicantDocument.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantDocument.Service
{
    public interface IApplicantDocumentService
    {
        Task<ApiResponse<ApplicantDocumentItemDto>> GetApplicantDocument(GetApplicantDocumentCommand request);
        Task<ApiResponse<ApplicantDocumentDto>> GetApplicantDocumentByCriteria(GetApplicantDocumentByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantDocument(SubmitApplicantDocumentCommand request);
        Task<ApiResponse> DeleteApplicantDocument(DeleteApplicantDocumentCommand request);
    }
}
