using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Building.Service;
using ThePatho.Features.Global.Building.DTO;

namespace ThePatho.Features.Global.Building.Commands
{
    public class GetSingleBuildingCommandHandler : IRequestHandler<GetSingleBuildingCommand, ApiResponse<BuildingDto>>
    {
        private readonly IBuildingService buildingService;

        public GetSingleBuildingCommandHandler(IBuildingService _buildingService)
        {
            buildingService = _buildingService;
        }

        public async Task<ApiResponse<BuildingDto>> Handle(GetSingleBuildingCommand request, CancellationToken cancellationToken)
        {
            return await buildingService.GetSingleBuilding(request);
        }
    }
}
