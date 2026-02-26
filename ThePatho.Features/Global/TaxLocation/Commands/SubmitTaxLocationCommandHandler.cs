using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TaxLocation.Service;

namespace ThePatho.Features.Global.TaxLocation.Commands
{
    public class SubmitTaxLocationCommandHandler : IRequestHandler<SubmitTaxLocationCommand, ApiResponse>
    {
        private readonly ITaxLocationService TaxLocationService;

        public SubmitTaxLocationCommandHandler(ITaxLocationService _TaxLocationService)
        {
            TaxLocationService = _TaxLocationService;
        }

        public async Task<ApiResponse> Handle(SubmitTaxLocationCommand request, CancellationToken cancellationToken)
        {
            return await TaxLocationService.SubmitTaxLocation(request);
        }
    }
}
