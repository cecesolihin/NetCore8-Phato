using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Rank.Service;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.Rank.Commands
{
    public class ExportRankCommandHandler : IRequestHandler<ExportRankCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IRankService service;

        public ExportRankCommandHandler(IRankService service)
        {
            this.service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportRankCommand request, CancellationToken cancellationToken)
        {
            return await service.ExportRankAsync(request.Type);
        }
    }
}