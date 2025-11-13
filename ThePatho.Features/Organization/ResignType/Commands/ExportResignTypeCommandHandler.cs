using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.ResignType.Service;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.ResignType.Commands
{
    public class ExportResignTypeCommandHandler : IRequestHandler<ExportResignTypeCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IResignTypeService service;

        public ExportResignTypeCommandHandler(IResignTypeService service)
        {
            this.service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportResignTypeCommand request, CancellationToken cancellationToken)
        {
            return await service.ExportResignTypeAsync(request.Type);
        }
    }
}