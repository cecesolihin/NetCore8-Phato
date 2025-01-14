
using ThePatho.Features.Organization.Position.Commands;
using ThePatho.Features.Organization.Position.DTO;

namespace ThePatho.Features.Organization.Position.Service
{
    public interface IPositionService
    {
        Task<List<PositionDto>> GetPosition(GetPositionCommand request);
        Task<PositionDto> GetPositionByCriteria(GetPositionByCriteriaCommand request);
        Task<bool> SubmitPosition(SubmitPositionCommand request);
        Task<bool> DeletePosition(DeletePositionCommand request);
    }
}
