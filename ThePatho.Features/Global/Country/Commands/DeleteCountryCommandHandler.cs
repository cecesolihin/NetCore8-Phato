using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Country.Service;

namespace ThePatho.Features.Global.Country.Commands
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, ApiResponse>
    {
        private readonly ICountryService countryService;

        public DeleteCountryCommandHandler(ICountryService _countryService)
        {
            countryService = _countryService;
        }

        public async Task<ApiResponse> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            return await countryService.DeleteCountry(request);
        }
    }
}
