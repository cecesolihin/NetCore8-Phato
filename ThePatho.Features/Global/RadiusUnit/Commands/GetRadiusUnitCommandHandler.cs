using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RadiusUnit.Service;
using ThePatho.Features.Global.RadiusUnit.DTO;

namespace ThePatho.Features.Global.RadiusUnit.Commands
{
    public class GetRadiusUnitCommandHandler : IRequestHandler<GetRadiusUnitCommand, ApiResponse<RadiusUnitItemDto>>
    {
        private readonly IRadiusUnitService RadiusUnitService;

        public GetRadiusUnitCommandHandler(IRadiusUnitService _RadiusUnitService)
        {
            RadiusUnitService = _RadiusUnitService;
        }

        public async Task<ApiResponse<RadiusUnitItemDto>> Handle(GetRadiusUnitCommand request, CancellationToken cancellationToken)
        {
            return await RadiusUnitService.GetRadiusUnit(request);
        }
    }
}
