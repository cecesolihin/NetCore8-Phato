using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TaxLocation.Service;
using ThePatho.Features.Global.TaxLocation.DTO;

namespace ThePatho.Features.Global.TaxLocation.Commands
{
    public class GetTaxLocationByCriteriaCommandHandler : IRequestHandler<GetTaxLocationByCriteriaCommand, ApiResponse<TaxLocationItemDto>>
    {
        private readonly ITaxLocationService TaxLocationService;

        public GetTaxLocationByCriteriaCommandHandler(ITaxLocationService _TaxLocationService)
        {
            TaxLocationService = _TaxLocationService;
        }

        public async Task<ApiResponse<TaxLocationItemDto>> Handle(GetTaxLocationByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await TaxLocationService.GetTaxLocationByCriteria(request);
        }
    }
}
