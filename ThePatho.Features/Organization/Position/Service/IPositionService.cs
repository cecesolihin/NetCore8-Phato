
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Organization.Position.Commands;
using ThePatho.Features.Organization.Position.DTO;

namespace ThePatho.Features.Organization.Position.Service
{
    public interface IPositionService
    {
        Task<NewApiResponse<PositionItemDto>> GetPosition(GetPositionCommand request);
        Task<NewApiResponse<PositionDto>> GetPositionByCriteria(GetPositionByCriteriaCommand request);
        Task<ApiResponse> SubmitPosition(SubmitPositionCommand request);
        Task<ApiResponse> DeletePosition(DeletePositionCommand request);
    }
}
