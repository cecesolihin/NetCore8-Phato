using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Position.DTO;
using ThePatho.Features.Organization.Position.Service;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class GetPositionCommandHandler : IRequestHandler<GetPositionCommand, ApiResponse<PositionItemDto>>
    {
        private readonly IPositionService positionService;
        public GetPositionCommandHandler(IPositionService _positionService)
        {
            positionService =_positionService;
        }
        public async Task<ApiResponse<PositionItemDto>> Handle(GetPositionCommand request, CancellationToken cancellationToken)
        {
            return await positionService.GetPosition(request); 

        }
    }
}
