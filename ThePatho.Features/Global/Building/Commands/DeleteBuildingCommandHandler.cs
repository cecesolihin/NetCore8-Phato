using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Building.Service;

namespace ThePatho.Features.Global.Building.Commands
{
    public class DeleteBuildingCommandHandler : IRequestHandler<DeleteBuildingCommand, ApiResponse>
    {
        private readonly IBuildingService buildingService;

        public DeleteBuildingCommandHandler(IBuildingService _buildingService)
        {
            buildingService = _buildingService;
        }

        public async Task<ApiResponse> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {
            return await buildingService.DeleteBuilding(request);
        }
    }
}
