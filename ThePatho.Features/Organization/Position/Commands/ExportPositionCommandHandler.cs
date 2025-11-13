using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Position.Service;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class ExportPositionCommandHandler : IRequestHandler<ExportPositionCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IPositionService positionService;

        public ExportPositionCommandHandler(IPositionService _positionService)
        {
            positionService = _positionService ?? throw new ArgumentNullException(nameof(_positionService));
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportPositionCommand request, CancellationToken cancellationToken)
        {
            return await positionService.ExportPositionAsync(request.Type);
        }
    }
}