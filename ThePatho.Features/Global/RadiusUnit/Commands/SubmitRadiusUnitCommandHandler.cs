using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RadiusUnit.Service;

namespace ThePatho.Features.Global.RadiusUnit.Commands
{
    public class SubmitRadiusUnitCommandHandler : IRequestHandler<SubmitRadiusUnitCommand, ApiResponse>
    {
        private readonly IRadiusUnitService RadiusUnitService;

        public SubmitRadiusUnitCommandHandler(IRadiusUnitService _RadiusUnitService)
        {
            RadiusUnitService = _RadiusUnitService;
        }

        public async Task<ApiResponse> Handle(SubmitRadiusUnitCommand request, CancellationToken cancellationToken)
        {
            return await RadiusUnitService.SubmitRadiusUnit(request);
        }
    }
}
