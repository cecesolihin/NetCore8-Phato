using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Position.Service;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class SubmitPositionCommandHandler : IRequestHandler<SubmitPositionCommand, ApiResponse>
    {
        private readonly IPositionService positionService;

        public SubmitPositionCommandHandler(IPositionService _positionService)
        {
            positionService = _positionService;
        }

        public async Task<ApiResponse> Handle(SubmitPositionCommand request, CancellationToken cancellationToken)
        {
            return await positionService.SubmitPosition(request);
        }
    }
}
