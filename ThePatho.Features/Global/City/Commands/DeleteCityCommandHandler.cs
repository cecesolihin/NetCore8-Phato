using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.City.Service;

namespace ThePatho.Features.Global.City.Commands
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, ApiResponse>
    {
        private readonly ICityService cityService;

        public DeleteCityCommandHandler(ICityService _cityService)
        {
            cityService = _cityService;
        }

        public async Task<ApiResponse> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            return await cityService.DeleteCity(request);
        }
    }
}
