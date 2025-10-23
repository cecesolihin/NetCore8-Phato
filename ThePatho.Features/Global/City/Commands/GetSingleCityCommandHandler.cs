using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.City.DTO;
using ThePatho.Features.Global.City.Service;

namespace ThePatho.Features.Global.City.Commands
{
    public class GetSingleCityCommandHandler : IRequestHandler<GetSingleCityCommand, ApiResponse<CityDto>>
    {
        private readonly ICityService cityService;
        public GetSingleCityCommandHandler(ICityService _cityService)
        {
            cityService = _cityService;
        }
        public async Task<ApiResponse<CityDto>> Handle(GetSingleCityCommand request, CancellationToken cancellationToken)
        {
            return await cityService.GetSingleCity(request);
        }
    }
}
