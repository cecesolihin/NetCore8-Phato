using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.FamilyRelation.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.FamilyRelation.Commands.Handlers
{
    public class ExportFamilyRelationCommandHandler : IRequestHandler<ExportFamilyRelationCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IFamilyRelationService _service;
        public ExportFamilyRelationCommandHandler(IFamilyRelationService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportFamilyRelationCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
