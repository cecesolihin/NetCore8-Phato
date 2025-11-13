
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Position.Commands;
using ThePatho.Features.Organization.Position.DTO;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.Position.Service
{
    public interface IPositionService
    {
        Task<ApiResponse<PositionItemDto>> GetPosition(GetPositionCommand request);
        Task<ApiResponse<PositionDto>> GetSinglePosition(GetSinglePositionCommand request);
        Task<ApiResponse<PositionItemDto>> GetPositionByCriteria(GetPositionByCriteriaCommand request);
        Task<ApiResponse> SubmitPosition(SubmitPositionCommand request);
        Task<ApiResponse> DeletePosition(DeletePositionCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportPositionAsync(string type);
    }
}
