using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.CareerType.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.CareerType.Commands.Handlers
{
    public class ExportCareerTypeCommandHandler : IRequestHandler<ExportCareerTypeCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly ICareerTypeService _service;
        public ExportCareerTypeCommandHandler(ICareerTypeService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportCareerTypeCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
