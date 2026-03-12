using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.LetterCategory.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.LetterCategory.Commands.Handlers
{
    public class ExportLetterCategoryCommandHandler : IRequestHandler<ExportLetterCategoryCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly ILetterCategoryService _service;
        public ExportLetterCategoryCommandHandler(ILetterCategoryService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportLetterCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
