using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Building.Service;
using ThePatho.Features.Global.Building.DTO;

namespace ThePatho.Features.Global.Building.Commands
{
    public class GetBuildingByCriteriaCommandHandler : IRequestHandler<GetBuildingByCriteriaCommand, ApiResponse<BuildingItemDto>>
    {
        private readonly IBuildingService buildingService;

        public GetBuildingByCriteriaCommandHandler(IBuildingService _buildingService)
        {
            buildingService = _buildingService;
        }

        public async Task<ApiResponse<BuildingItemDto>> Handle(GetBuildingByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await buildingService.GetBuildingByCriteria(request);
        }
    }
}
