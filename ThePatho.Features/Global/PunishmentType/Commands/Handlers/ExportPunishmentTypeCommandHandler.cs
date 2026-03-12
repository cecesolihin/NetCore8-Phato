using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.PunishmentType.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.PunishmentType.Commands.Handlers
{
    public class ExportPunishmentTypeCommandHandler : IRequestHandler<ExportPunishmentTypeCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IPunishmentTypeService _service;
        public ExportPunishmentTypeCommandHandler(IPunishmentTypeService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportPunishmentTypeCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
