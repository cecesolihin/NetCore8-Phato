using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TaxStatus.DTO;
using ThePatho.Features.Global.TaxStatus.Service;

namespace ThePatho.Features.Global.TaxStatus.Commands
{
    public class GetTaxStatusCommandHandler : IRequestHandler<GetTaxStatusCommand, ApiResponse<TaxStatusItemDto>>
    {
        private readonly ITaxStatusService TaxStatusService;
        public GetTaxStatusCommandHandler(ITaxStatusService _TaxStatusService)
        {
            TaxStatusService = _TaxStatusService;
        }
        public async Task<ApiResponse<TaxStatusItemDto>> Handle(GetTaxStatusCommand request, CancellationToken cancellationToken)
        {
            return await TaxStatusService.GetTaxStatus(request);
        }
    }
}
