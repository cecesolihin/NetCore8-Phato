using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.RadiusUnit.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.RadiusUnit.Commands.Handlers
{
    public class ExportRadiusUnitCommandHandler : IRequestHandler<ExportRadiusUnitCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IRadiusUnitService _service;
        public ExportRadiusUnitCommandHandler(IRadiusUnitService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportRadiusUnitCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
