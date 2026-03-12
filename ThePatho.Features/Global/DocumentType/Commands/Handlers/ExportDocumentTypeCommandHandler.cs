using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.DocumentType.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.DocumentType.Commands.Handlers
{
    public class ExportDocumentTypeCommandHandler : IRequestHandler<ExportDocumentTypeCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IDocumentTypeService _service;
        public ExportDocumentTypeCommandHandler(IDocumentTypeService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
