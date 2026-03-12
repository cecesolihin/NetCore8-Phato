using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.Room.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Room.Commands.Handlers
{
    public class ExportRoomCommandHandler : IRequestHandler<ExportRoomCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IRoomService _service;
        public ExportRoomCommandHandler(IRoomService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportRoomCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
