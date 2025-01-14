using MediatR;
using ThePatho.Features.Organization.Position.Service;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class SubmitPositionCommandHandler : IRequestHandler<SubmitPositionCommand, string>
    {
        private readonly IPositionService positionService;

        public SubmitPositionCommandHandler(IPositionService _positionService)
        {
            positionService = _positionService;
        }

        public async Task<string> Handle(SubmitPositionCommand request, CancellationToken cancellationToken)
        {
            await positionService.SubmitPosition(request);
            if (request.Action == "ADD")
            {
                return "Position successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Position successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
