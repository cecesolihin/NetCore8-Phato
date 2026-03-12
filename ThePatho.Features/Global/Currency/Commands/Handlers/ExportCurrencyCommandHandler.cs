using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.Currency.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Currency.Commands.Handlers
{
    public class ExportCurrencyCommandHandler : IRequestHandler<ExportCurrencyCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly ICurrencyService _service;
        public ExportCurrencyCommandHandler(ICurrencyService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportCurrencyCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
