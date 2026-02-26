using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RadiusUnit.Service;
using ThePatho.Features.Global.RadiusUnit.DTO;

namespace ThePatho.Features.Global.RadiusUnit.Commands
{
    public class GetRadiusUnitByCriteriaCommandHandler : IRequestHandler<GetRadiusUnitByCriteriaCommand, ApiResponse<RadiusUnitItemDto>>
    {
        private readonly IRadiusUnitService RadiusUnitService;

        public GetRadiusUnitByCriteriaCommandHandler(IRadiusUnitService _RadiusUnitService)
        {
            RadiusUnitService = _RadiusUnitService;
        }

        public async Task<ApiResponse<RadiusUnitItemDto>> Handle(GetRadiusUnitByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await RadiusUnitService.GetRadiusUnitByCriteria(request);
        }
    }
}
