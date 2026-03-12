using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Identity.Commands;
using ThePatho.Features.Global.Identity.DTO;

namespace ThePatho.Features.Global.Identity.Service
{
    public interface IIdentityService
    {
        Task<ApiResponse<IdentityItemDto>> GetIdentity(GetIdentityCommand request);
        Task<ApiResponse<IdentityItemDto>> GetIdentityByCriteria(GetIdentityByCriteriaCommand request);
        Task<ApiResponse> SubmitIdentity(SubmitIdentityCommand request);
        Task<ApiResponse> DeleteIdentity(DeleteIdentityCommand request);

        Task<ApiResponse<IdentityDto>> GetSingleIdentity(GetSingleIdentityCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportIdentityCommand request);
    }
}

