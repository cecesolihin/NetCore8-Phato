using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Country.Service;
using ThePatho.Features.Global.Country.DTO;

namespace ThePatho.Features.Global.Country.Commands
{
    public class GetCountryByCriteriaCommandHandler : IRequestHandler<GetCountryByCriteriaCommand, ApiResponse<CountryItemDto>>
    {
        private readonly ICountryService countryService;

        public GetCountryByCriteriaCommandHandler(ICountryService _countryService)
        {
            countryService = _countryService;
        }

        public async Task<ApiResponse<CountryItemDto>> Handle(GetCountryByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await countryService.GetCountryByCriteria(request);
        }
    }
}
