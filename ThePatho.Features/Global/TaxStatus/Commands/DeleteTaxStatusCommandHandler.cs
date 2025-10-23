using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TaxStatus.Service;

namespace ThePatho.Features.Global.TaxStatus.Commands
{
    public class DeleteTaxStatusCommandHandler : IRequestHandler<DeleteTaxStatusCommand, ApiResponse>
    {
        private readonly ITaxStatusService TaxStatusService;

        public DeleteTaxStatusCommandHandler(ITaxStatusService _TaxStatusService)
        {
            TaxStatusService = _TaxStatusService;
        }

        public async Task<ApiResponse> Handle(DeleteTaxStatusCommand request, CancellationToken cancellationToken)
        {
            return await TaxStatusService.DeleteTaxStatus(request);
        }
    }
}
