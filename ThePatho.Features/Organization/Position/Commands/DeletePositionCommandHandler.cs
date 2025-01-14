using MediatR;
using System;
using ThePatho.Features.Organization.Position.Service;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand, bool>
    {
        private readonly IPositionService positionService;

        public DeletePositionCommandHandler(IPositionService _positionService)
        {
            positionService = _positionService;
        }

        public async Task<bool> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await positionService.DeletePosition(request);
                return true;
            }
            catch
            {
                // Log the error here if needed
                return false;
            }
        }
    }
}
