using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Position.DTO;
using ThePatho.Features.Organization.Position.Service;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class GetPositionByCriteriaCommandHandler : IRequestHandler<GetPositionByCriteriaCommand, ApiResponse<PositionDto>>
    {
        private readonly IPositionService positionService;
        public GetPositionByCriteriaCommandHandler(IPositionService _positionService)
        {
            positionService = _positionService;
        }
        public async Task<ApiResponse<PositionDto>> Handle(GetPositionByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await positionService.GetPositionByCriteria(request); 
        }
    }
}
