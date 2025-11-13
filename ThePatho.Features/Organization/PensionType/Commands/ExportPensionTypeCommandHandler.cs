using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.PensionType.Service;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.PensionType.Commands
{
    public class ExportPensionTypeCommandHandler : IRequestHandler<ExportPensionTypeCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IPensionTypeService service;

        public ExportPensionTypeCommandHandler(IPensionTypeService service)
        {
            this.service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportPensionTypeCommand request, CancellationToken cancellationToken)
        {
            return await service.ExportPensionTypeAsync(request.Type);
        }
    }
}