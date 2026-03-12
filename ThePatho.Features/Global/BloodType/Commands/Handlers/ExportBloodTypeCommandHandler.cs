using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.BloodType.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.BloodType.Commands.Handlers
{
    public class ExportBloodTypeCommandHandler : IRequestHandler<ExportBloodTypeCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IBloodTypeService _service;
        public ExportBloodTypeCommandHandler(IBloodTypeService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportBloodTypeCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
