using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Country.Service;

namespace ThePatho.Features.Global.Country.Commands
{
    public class SubmitCountryCommandHandler : IRequestHandler<SubmitCountryCommand, ApiResponse>
    {
        private readonly ICountryService countryService;

        public SubmitCountryCommandHandler(ICountryService _countryService)
        {
            countryService = _countryService;
        }

        public async Task<ApiResponse> Handle(SubmitCountryCommand request, CancellationToken cancellationToken)
        {
            return await countryService.SubmitCountry(request);
        }
    }
}
