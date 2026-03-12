using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.MaritalStatus.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.MaritalStatus.Commands.Handlers
{
    public class ExportMaritalStatusCommandHandler : IRequestHandler<ExportMaritalStatusCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IMaritalStatusService _service;
        public ExportMaritalStatusCommandHandler(IMaritalStatusService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportMaritalStatusCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
