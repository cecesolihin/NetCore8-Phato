using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TaxLocation.Service;
using ThePatho.Features.Global.TaxLocation.DTO;

namespace ThePatho.Features.Global.TaxLocation.Commands
{
    public class GetSingleTaxLocationCommandHandler : IRequestHandler<GetSingleTaxLocationCommand, ApiResponse<TaxLocationDto>>
    {
        private readonly ITaxLocationService Service;

        public GetSingleTaxLocationCommandHandler(ITaxLocationService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<TaxLocationDto>> Handle(GetSingleTaxLocationCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleTaxLocation(request);
        }
    }
}
