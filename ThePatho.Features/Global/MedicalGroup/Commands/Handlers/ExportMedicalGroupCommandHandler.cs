using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.MedicalGroup.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.MedicalGroup.Commands.Handlers
{
    public class ExportMedicalGroupCommandHandler : IRequestHandler<ExportMedicalGroupCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IMedicalGroupService _service;
        public ExportMedicalGroupCommandHandler(IMedicalGroupService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportMedicalGroupCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
