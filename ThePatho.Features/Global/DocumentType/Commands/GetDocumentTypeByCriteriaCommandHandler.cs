using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.DocumentType.Service;
using ThePatho.Features.Global.DocumentType.DTO;

namespace ThePatho.Features.Global.DocumentType.Commands
{
    public class GetDocumentTypeByCriteriaCommandHandler : IRequestHandler<GetDocumentTypeByCriteriaCommand, ApiResponse<DocumentTypeItemDto>>
    {
        private readonly IDocumentTypeService DocumentTypeService;

        public GetDocumentTypeByCriteriaCommandHandler(IDocumentTypeService _DocumentTypeService)
        {
            DocumentTypeService = _DocumentTypeService;
        }

        public async Task<ApiResponse<DocumentTypeItemDto>> Handle(GetDocumentTypeByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await DocumentTypeService.GetDocumentTypeByCriteria(request);
        }
    }
}





