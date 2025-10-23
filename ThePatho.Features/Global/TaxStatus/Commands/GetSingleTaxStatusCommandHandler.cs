using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TaxStatus.DTO;
using ThePatho.Features.Global.TaxStatus.Service;

namespace ThePatho.Features.Global.TaxStatus.Commands
{
    public class GetSingleTaxStatusCommandHandler : IRequestHandler<GetSingleTaxStatusCommand, ApiResponse<TaxStatusDto>>
    {
        private readonly ITaxStatusService TaxStatusService;
        public GetSingleTaxStatusCommandHandler(ITaxStatusService _TaxStatusService)
        {
            TaxStatusService = _TaxStatusService;
        }
        public async Task<ApiResponse<TaxStatusDto>> Handle(GetSingleTaxStatusCommand request, CancellationToken cancellationToken)
        {
            return await TaxStatusService.GetSingleTaxStatus(request);
        }
    }
}
