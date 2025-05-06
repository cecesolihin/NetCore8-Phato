
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Position.Commands;
using ThePatho.Features.Organization.Position.DTO;

namespace ThePatho.Features.Organization.Position.Service
{
    public interface IPositionService
    {
        Task<ApiResponse<PositionItemDto>> GetPosition(GetPositionCommand request);
        Task<ApiResponse<PositionDto>> GetPositionByCriteria(GetPositionByCriteriaCommand request);
        Task<ApiResponse> SubmitPosition(SubmitPositionCommand request);
        Task<ApiResponse> DeletePosition(DeletePositionCommand request);
    }
}
