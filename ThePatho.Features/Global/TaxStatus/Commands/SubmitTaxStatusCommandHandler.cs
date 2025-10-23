using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TaxStatus.Service;

namespace ThePatho.Features.Global.TaxStatus.Commands
{
    public class SubmitTaxStatusCommandHandler : IRequestHandler<SubmitTaxStatusCommand, ApiResponse>
    {
        private readonly ITaxStatusService TaxStatusService;

        public SubmitTaxStatusCommandHandler(ITaxStatusService _TaxStatusService)
        {
            TaxStatusService = _TaxStatusService;
        }

        public async Task<ApiResponse> Handle(SubmitTaxStatusCommand request, CancellationToken cancellationToken)
        {
            return await TaxStatusService.SubmitTaxStatus(request);
        }
    }
}
