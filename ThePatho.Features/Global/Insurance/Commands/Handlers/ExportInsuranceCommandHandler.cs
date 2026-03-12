using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.Insurance.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Insurance.Commands.Handlers
{
    public class ExportInsuranceCommandHandler : IRequestHandler<ExportInsuranceCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IInsuranceService _service;
        public ExportInsuranceCommandHandler(IInsuranceService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportInsuranceCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
