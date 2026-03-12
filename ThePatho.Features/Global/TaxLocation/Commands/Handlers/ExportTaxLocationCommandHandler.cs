using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.TaxLocation.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.TaxLocation.Commands.Handlers
{
    public class ExportTaxLocationCommandHandler : IRequestHandler<ExportTaxLocationCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly ITaxLocationService _service;
        public ExportTaxLocationCommandHandler(ITaxLocationService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportTaxLocationCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
