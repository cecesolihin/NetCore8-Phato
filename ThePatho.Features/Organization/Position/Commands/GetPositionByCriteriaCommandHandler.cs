using MediatR;
using ThePatho.Features.Organization.Position.DTO;
using ThePatho.Features.Organization.Position.Service;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class GetPositionByCriteriaCommandHandler : IRequestHandler<GetPositionByCriteriaCommand, PositionDto>
    {
        private readonly IPositionService positionService;
        public GetPositionByCriteriaCommandHandler(IPositionService _positionService)
        {
            positionService = _positionService;
        }
        public async Task<PositionDto> Handle(GetPositionByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await positionService.GetPositionByCriteria(request); 

            return data;
        }
    }
}
