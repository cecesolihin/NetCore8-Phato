using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.Bank.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Bank.Commands.Handlers
{
    public class ExportBankCommandHandler : IRequestHandler<ExportBankCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IBankService _service;
        public ExportBankCommandHandler(IBankService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportBankCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
