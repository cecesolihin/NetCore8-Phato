using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobClass.Service;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.JobClass.Commands
{
    public class ExportJobClassCommandHandler : IRequestHandler<ExportJobClassCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IJobClassService _service;
        public ExportJobClassCommandHandler(IJobClassService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportJobClassCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportJobClassAsync(request.Type);
        }
    }
}