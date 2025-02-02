using MediatR;
using System;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Organization.Position.Service;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand, ApiResponse>
    {
        private readonly IPositionService positionService;

        public DeletePositionCommandHandler(IPositionService _positionService)
        {
            positionService = _positionService;
        }

        public async Task<ApiResponse> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
           return await positionService.DeletePosition(request);
               
        }
    }
}
