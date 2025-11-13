using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.ResignType.Commands;
using ThePatho.Features.Organization.ResignType.DTO;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.ResignType.Service
{
    public interface IResignTypeService
    {
        Task<ApiResponse<ResignTypeItemDto>> GetResignType(GetResignTypeCommand request);
        Task<ApiResponse<ResignTypeDto>> GetSingleResignType(GetSingleResignTypeCommand request);
        Task<ApiResponse<ResignTypeItemDto>> GetResignTypeByCriteria(GetResignTypeByCriteriaCommand request);
        Task<ApiResponse> SubmitResignType(SubmitResignTypeCommand request);
        Task<ApiResponse> DeleteResignType(DeleteResignTypeCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportResignTypeAsync(string type);
    }
}
