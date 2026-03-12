using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.Country.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Country.Commands.Handlers
{
    public class ExportCountryCommandHandler : IRequestHandler<ExportCountryCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly ICountryService _service;
        public ExportCountryCommandHandler(ICountryService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportCountryCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
