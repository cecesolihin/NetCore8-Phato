using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.City.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.City.Commands.Handlers
{
    public class ExportCityCommandHandler : IRequestHandler<ExportCityCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly ICityService _service;
        public ExportCityCommandHandler(ICityService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportCityCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
