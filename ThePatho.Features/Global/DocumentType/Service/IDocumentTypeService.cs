using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.DocumentType.Commands;
using ThePatho.Features.Global.DocumentType.DTO;

namespace ThePatho.Features.Global.DocumentType.Service
{
    public interface IDocumentTypeService
    {
        Task<ApiResponse<DocumentTypeItemDto>> GetDocumentType(GetDocumentTypeCommand request);
        Task<ApiResponse<DocumentTypeDto>> GetSingleDocumentType(GetSingleDocumentTypeCommand request);
        Task<ApiResponse<DocumentTypeItemDto>> GetDocumentTypeByCriteria(GetDocumentTypeByCriteriaCommand request);
        Task<ApiResponse> SubmitDocumentType(SubmitDocumentTypeCommand request);
        Task<ApiResponse> DeleteDocumentType(DeleteDocumentTypeCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportDocumentTypeCommand request);
    }
}

