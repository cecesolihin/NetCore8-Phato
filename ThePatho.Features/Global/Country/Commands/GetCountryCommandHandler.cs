using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Country.Service;
using ThePatho.Features.Global.Country.DTO;

namespace ThePatho.Features.Global.Country.Commands
{
    public class GetCountryCommandHandler : IRequestHandler<GetCountryCommand, ApiResponse<CountryItemDto>>
    {
        private readonly ICountryService countryService;

        public GetCountryCommandHandler(ICountryService _countryService)
        {
            countryService = _countryService;
        }

        public async Task<ApiResponse<CountryItemDto>> Handle(GetCountryCommand request, CancellationToken cancellationToken)
        {
            return await countryService.GetCountry(request);
        }
    }
}
