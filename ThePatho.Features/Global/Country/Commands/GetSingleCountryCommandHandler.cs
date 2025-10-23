using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Country.Service;
using ThePatho.Features.Global.Country.DTO;

namespace ThePatho.Features.Global.Country.Commands
{
    public class GetSingleCountryCommandHandler : IRequestHandler<GetSingleCountryCommand, ApiResponse<CountryDto>>
    {
        private readonly ICountryService countryService;

        public GetSingleCountryCommandHandler(ICountryService _countryService)
        {
            countryService = _countryService;
        }

        public async Task<ApiResponse<CountryDto>> Handle(GetSingleCountryCommand request, CancellationToken cancellationToken)
        {
            return await countryService.GetSingleCountry(request);
        }
    }
}
