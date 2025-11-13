using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.MutationType.Service;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.MutationType.Commands
{
    public class ExportMutationTypeCommandHandler : IRequestHandler<ExportMutationTypeCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IMutationTypeService mutationTypeService;

        public ExportMutationTypeCommandHandler(IMutationTypeService _mutationTypeService)
        {
            mutationTypeService = _mutationTypeService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportMutationTypeCommand request, CancellationToken cancellationToken)
        {
            return await mutationTypeService.ExportMutationTypeAsync(request.Type);
        }
    }
}