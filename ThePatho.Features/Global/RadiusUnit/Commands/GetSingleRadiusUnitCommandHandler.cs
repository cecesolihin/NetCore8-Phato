using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RadiusUnit.Service;
using ThePatho.Features.Global.RadiusUnit.DTO;

namespace ThePatho.Features.Global.RadiusUnit.Commands
{
    public class GetSingleRadiusUnitCommandHandler : IRequestHandler<GetSingleRadiusUnitCommand, ApiResponse<RadiusUnitDto>>
    {
        private readonly IRadiusUnitService Service;

        public GetSingleRadiusUnitCommandHandler(IRadiusUnitService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<RadiusUnitDto>> Handle(GetSingleRadiusUnitCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleRadiusUnit(request);
        }
    }
}
