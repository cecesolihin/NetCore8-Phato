using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocation.Service;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.WorkLocation.Commands
{
    public class ExportWorkLocationCommandHandler : IRequestHandler<ExportWorkLocationCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IWorkLocationService service;

        public ExportWorkLocationCommandHandler(IWorkLocationService service)
        {
            this.service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportWorkLocationCommand request, CancellationToken cancellationToken)
        {
            return await service.ExportWorkLocationAsync(request.Type);
        }
    }
}