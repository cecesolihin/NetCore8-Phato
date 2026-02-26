using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RadiusUnit.Service;

namespace ThePatho.Features.Global.RadiusUnit.Commands
{
    public class DeleteRadiusUnitCommandHandler : IRequestHandler<DeleteRadiusUnitCommand, ApiResponse>
    {
        private readonly IRadiusUnitService RadiusUnitService;

        public DeleteRadiusUnitCommandHandler(IRadiusUnitService _RadiusUnitService)
        {
            RadiusUnitService = _RadiusUnitService;
        }

        public async Task<ApiResponse> Handle(DeleteRadiusUnitCommand request, CancellationToken cancellationToken)
        {
            return await RadiusUnitService.DeleteRadiusUnit(request);
        }
    }
}
