using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.GraduationType.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.GraduationType.Commands.Handlers
{
    public class ExportGraduationTypeCommandHandler : IRequestHandler<ExportGraduationTypeCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IGraduationTypeService _service;
        public ExportGraduationTypeCommandHandler(IGraduationTypeService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportGraduationTypeCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
