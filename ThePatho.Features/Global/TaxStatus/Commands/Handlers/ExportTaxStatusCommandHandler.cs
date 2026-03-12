using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.TaxStatus.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.TaxStatus.Commands.Handlers
{
    public class ExportTaxStatusCommandHandler : IRequestHandler<ExportTaxStatusCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly ITaxStatusService _service;
        public ExportTaxStatusCommandHandler(ITaxStatusService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportTaxStatusCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
