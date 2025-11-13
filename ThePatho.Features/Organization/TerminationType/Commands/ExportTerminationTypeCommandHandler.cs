using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.TerminationType.Service;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.TerminationType.Commands
{
    public class ExportTerminationTypeCommandHandler : IRequestHandler<ExportTerminationTypeCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly ITerminationTypeService service;

        public ExportTerminationTypeCommandHandler(ITerminationTypeService service)
        {
            this.service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportTerminationTypeCommand request, CancellationToken cancellationToken)
        {
            return await service.ExportTerminationTypeAsync(request.Type);
        }
    }
}