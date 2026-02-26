using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TaxLocation.Service;

namespace ThePatho.Features.Global.TaxLocation.Commands
{
    public class DeleteTaxLocationCommandHandler : IRequestHandler<DeleteTaxLocationCommand, ApiResponse>
    {
        private readonly ITaxLocationService TaxLocationService;

        public DeleteTaxLocationCommandHandler(ITaxLocationService _TaxLocationService)
        {
            TaxLocationService = _TaxLocationService;
        }

        public async Task<ApiResponse> Handle(DeleteTaxLocationCommand request, CancellationToken cancellationToken)
        {
            return await TaxLocationService.DeleteTaxLocation(request);
        }
    }
}
