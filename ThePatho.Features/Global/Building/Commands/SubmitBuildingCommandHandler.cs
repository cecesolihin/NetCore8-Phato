using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Building.Service;

namespace ThePatho.Features.Global.Building.Commands
{
    public class SubmitBuildingCommandHandler : IRequestHandler<SubmitBuildingCommand, ApiResponse>
    {
        private readonly IBuildingService buildingService;

        public SubmitBuildingCommandHandler(IBuildingService _buildingService)
        {
            buildingService = _buildingService;
        }

        public async Task<ApiResponse> Handle(SubmitBuildingCommand request, CancellationToken cancellationToken)
        {
            return await buildingService.SubmitBuilding(request);
        }
    }
}
