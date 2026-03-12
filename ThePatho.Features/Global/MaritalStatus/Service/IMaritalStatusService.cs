using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.MaritalStatus.Commands;
using ThePatho.Features.Global.MaritalStatus.DTO;

namespace ThePatho.Features.Global.MaritalStatus.Service
{
    public interface IMaritalStatusService
    {
        Task<ApiResponse<MaritalStatusItemDto>> GetMaritalStatus(GetMaritalStatusCommand request);
        Task<ApiResponse<MaritalStatusDto>> GetSingleMaritalStatus(GetSingleMaritalStatusCommand request);
        Task<ApiResponse<MaritalStatusItemDto>> GetMaritalStatusByCriteria(GetMaritalStatusByCriteriaCommand request);
        Task<ApiResponse> SubmitMaritalStatus(SubmitMaritalStatusCommand request);
        Task<ApiResponse> DeleteMaritalStatus(DeleteMaritalStatusCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportMaritalStatusCommand request);
    }
}

