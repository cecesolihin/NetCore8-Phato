using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.TemplateKeyword.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.TemplateKeyword.Commands.Handlers
{
    public class ExportTemplateKeywordCommandHandler : IRequestHandler<ExportTemplateKeywordCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly ITemplateKeywordService _service;
        public ExportTemplateKeywordCommandHandler(ITemplateKeywordService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportTemplateKeywordCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
