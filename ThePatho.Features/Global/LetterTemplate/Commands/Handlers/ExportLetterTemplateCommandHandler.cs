using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.LetterTemplate.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.LetterTemplate.Commands.Handlers
{
    public class ExportLetterTemplateCommandHandler : IRequestHandler<ExportLetterTemplateCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly ILetterTemplateService _service;
        public ExportLetterTemplateCommandHandler(ILetterTemplateService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportLetterTemplateCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
