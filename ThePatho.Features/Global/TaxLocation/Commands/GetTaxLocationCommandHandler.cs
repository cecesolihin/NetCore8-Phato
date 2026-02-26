using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TaxLocation.Service;
using ThePatho.Features.Global.TaxLocation.DTO;

namespace ThePatho.Features.Global.TaxLocation.Commands
{
    public class GetTaxLocationCommandHandler : IRequestHandler<GetTaxLocationCommand, ApiResponse<TaxLocationItemDto>>
    {
        private readonly ITaxLocationService TaxLocationService;

        public GetTaxLocationCommandHandler(ITaxLocationService _TaxLocationService)
        {
            TaxLocationService = _TaxLocationService;
        }

        public async Task<ApiResponse<TaxLocationItemDto>> Handle(GetTaxLocationCommand request, CancellationToken cancellationToken)
        {
            return await TaxLocationService.GetTaxLocation(request);
        }
    }
}
