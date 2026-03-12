using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.Nationality.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Nationality.Commands.Handlers
{
    public class ExportNationalityCommandHandler : IRequestHandler<ExportNationalityCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly INationalityService _service;
        public ExportNationalityCommandHandler(INationalityService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportNationalityCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
