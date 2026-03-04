using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeDocument.Commands;
using ThePatho.Features.PersonalInformation.EmployeeDocument.DTO;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeDocument.Service
{
    public interface IEmployeeDocumentService
    {
        Task<ApiResponse<EmployeeDocumentItemDto>> GetEmployeeDocument(GetEmployeeDocumentCommand request);
        Task<ApiResponse<EmployeeDocumentItemDto>> GetEmployeeDocumentByCriteria(GetEmployeeDocumentByCriteriaCommand request);
        Task<ApiResponse> SubmitEmployeeDocument(SubmitEmployeeDocumentCommand request);
        Task<ApiResponse> DeleteEmployeeDocument(DeleteEmployeeDocumentCommand request);
        Task<ApiResponse<EmployeeDocumentDto>> GetSingleEmployeeDocument(GetSingleEmployeeDocumentCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportEmployeeDocumentAsync(string type);
    }
}
