using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.BranchBank.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.BranchBank.Commands.Handlers
{
    public class ExportBranchBankCommandHandler : IRequestHandler<ExportBranchBankCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IBranchBankService _service;
        public ExportBranchBankCommandHandler(IBranchBankService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportBranchBankCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
