using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TaxStatus.DTO;
using ThePatho.Features.Global.TaxStatus.Service;

namespace ThePatho.Features.Global.TaxStatus.Commands
{
    public class GetTaxStatusByCriteriaCommandHandler : IRequestHandler<GetTaxStatusByCriteriaCommand, ApiResponse<TaxStatusItemDto>>
    {
        private readonly ITaxStatusService TaxStatusService;
        public GetTaxStatusByCriteriaCommandHandler(ITaxStatusService _TaxStatusService)
        {
            TaxStatusService = _TaxStatusService;
        }
        public async Task<ApiResponse<TaxStatusItemDto>> Handle(GetTaxStatusByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await TaxStatusService.GetTaxStatusByCriteria(request);
        }
    }
}
