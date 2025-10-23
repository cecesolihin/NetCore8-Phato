using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.City.Service;

namespace ThePatho.Features.Global.City.Commands
{
    public class SubmitCityCommandHandler : IRequestHandler<SubmitCityCommand, ApiResponse>
    {
        private readonly ICityService cityService;

        public SubmitCityCommandHandler(ICityService _cityService)
        {
            cityService = _cityService;
        }

        public async Task<ApiResponse> Handle(SubmitCityCommand request, CancellationToken cancellationToken)
        {
            return await cityService.SubmitCity(request);
        }
    }
}
