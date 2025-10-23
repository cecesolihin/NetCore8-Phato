using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Building.Service;
using ThePatho.Features.Global.Building.DTO;

namespace ThePatho.Features.Global.Building.Commands
{
    public class GetBuildingCommandHandler : IRequestHandler<GetBuildingCommand, ApiResponse<BuildingItemDto>>
    {
        private readonly IBuildingService buildingService;

        public GetBuildingCommandHandler(IBuildingService _buildingService)
        {
            buildingService = _buildingService;
        }

        public async Task<ApiResponse<BuildingItemDto>> Handle(GetBuildingCommand request, CancellationToken cancellationToken)
        {
            return await buildingService.GetBuilding(request);
        }
    }
}
