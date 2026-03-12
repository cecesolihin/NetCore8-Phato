using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ResignReason.Commands;
using ThePatho.Features.Global.ResignReason.DTO;

namespace ThePatho.Features.Global.ResignReason.Service
{
    public interface IResignReasonService
    {
        Task<ApiResponse<ResignReasonItemDto>> GetResignReason(GetResignReasonCommand request);
        Task<ApiResponse<ResignReasonDto>> GetSingleResignReason(GetSingleResignReasonCommand request);
        Task<ApiResponse<ResignReasonItemDto>> GetResignReasonByCriteria(GetResignReasonByCriteriaCommand request);
        Task<ApiResponse> SubmitResignReason(SubmitResignReasonCommand request);
        Task<ApiResponse> DeleteResignReason(DeleteResignReasonCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportResignReasonCommand request);

    }
}