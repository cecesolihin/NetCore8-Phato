using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.City.DTO;
using ThePatho.Features.Global.City.Service;

namespace ThePatho.Features.Global.City.Commands
{
    public class GetCityCommandHandler : IRequestHandler<GetCityCommand, ApiResponse<CityItemDto>>
    {
        private readonly ICityService cityService;
        public GetCityCommandHandler(ICityService _cityService)
        {
            cityService = _cityService;
        }
        public async Task<ApiResponse<CityItemDto>> Handle(GetCityCommand request, CancellationToken cancellationToken)
        {
            return await cityService.GetCity(request);
        }
    }
}
