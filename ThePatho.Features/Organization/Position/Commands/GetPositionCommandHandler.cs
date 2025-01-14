using MediatR;
using ThePatho.Features.Organization.Position.DTO;
using ThePatho.Features.Organization.Position.Service;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class GetPositionCommandHandler : IRequestHandler<GetPositionCommand, PositionItemDto>
    {
        private readonly IPositionService positionService;
        public GetPositionCommandHandler(IPositionService _positionService)
        {
            positionService =_positionService;
        }
        public async Task<PositionItemDto> Handle(GetPositionCommand request, CancellationToken cancellationToken)
        {
            var data = await positionService.GetPosition(request); 

            return new PositionItemDto
            {
                DataOfRecords = data.Count,
                PositionList = data,
            };
        }
    }
}
