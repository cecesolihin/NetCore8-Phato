using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.City.DTO;
using ThePatho.Features.Global.City.Service;

namespace ThePatho.Features.Global.City.Commands
{
    public class GetCityByCriteriaCommandHandler : IRequestHandler<GetCityByCriteriaCommand, ApiResponse<CityItemDto>>
    {
        private readonly ICityService cityService;
        public GetCityByCriteriaCommandHandler(ICityService _cityService)
        {
            cityService = _cityService;
        }
        public async Task<ApiResponse<CityItemDto>> Handle(GetCityByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await cityService.GetCityByCriteria(request);
        }
    }
}
