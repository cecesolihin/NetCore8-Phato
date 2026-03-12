using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.Building.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Building.Commands.Handlers
{
    public class ExportBuildingCommandHandler : IRequestHandler<ExportBuildingCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IBuildingService _service;
        public ExportBuildingCommandHandler(IBuildingService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportBuildingCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
