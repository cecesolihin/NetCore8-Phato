using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocationGroup.Service;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.WorkLocationGroup.Commands
{
    public class ExportWorkLocationGroupCommandHandler : IRequestHandler<ExportWorkLocationGroupCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IWorkLocationGroupService service;

        public ExportWorkLocationGroupCommandHandler(IWorkLocationGroupService service)
        {
            this.service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportWorkLocationGroupCommand request, CancellationToken cancellationToken)
        {
            return await service.ExportWorkLocationGroupAsync(request.Type);
        }
    }
}