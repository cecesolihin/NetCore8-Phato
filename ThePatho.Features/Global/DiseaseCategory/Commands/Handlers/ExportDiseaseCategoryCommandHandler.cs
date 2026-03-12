using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.DiseaseCategory.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.DiseaseCategory.Commands.Handlers
{
    public class ExportDiseaseCategoryCommandHandler : IRequestHandler<ExportDiseaseCategoryCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IDiseaseCategoryService _service;
        public ExportDiseaseCategoryCommandHandler(IDiseaseCategoryService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportDiseaseCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
